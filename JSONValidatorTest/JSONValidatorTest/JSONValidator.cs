using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace JSONValidatorTest
{
    public class ValidateJsonInput
    {
        static readonly Range digit = new Range('0', '9');

        private enum NumberState
        {
            Invalid,
            StartState,
            NaturalNumberState,
            NegativeNumberState,
            NegativeNumberStateLeadingZero,
            NegativeNumberStateNoLeadingZero,
            NegativeNumberStateLeadingZeroBeforeDecimalPoint,
            NextToDecimalPointState,
            AfterDecimalPoint,
            ExponentialState,
            PostExponentialState,
        }

        public static bool JsonStringValidator(string inputJsonString)
        {
            if (string.IsNullOrEmpty(inputJsonString))
            {
                return false;
            }

            if (!IsStringDelimitedByQuotes(inputJsonString))
            {
                return false;
            }

            if (IsStringContainingExtraQuotations(inputJsonString))
            {
                return false;
            }

            if (!IsEscapeValueValid(inputJsonString))
            {
                return false;
            }

            if (!IsUnicodeValueValid(inputJsonString))
            {
                return false;
            }

            return true;
        }

        public static bool JsonNumberValidator(string inputJsonNumber)
        {
            if (string.IsNullOrEmpty(inputJsonNumber)) return false;

            var currentState = NumberState.StartState;

            foreach (var current in inputJsonNumber)
            {
                switch (currentState)
                {
                    case NumberState.StartState:
                        currentState = HandleStartState(current);
                        break;
                    case NumberState.NaturalNumberState:
                        currentState = HandleNaturalNumberState(current);
                        break;
                    case NumberState.NegativeNumberState:
                        currentState = HandleNegativeNumberState(current);
                        break;
                    case NumberState.NegativeNumberStateLeadingZero:
                        currentState = HandleNegativeNumberStateLeadingZero(current);
                        break;
                    case NumberState.NegativeNumberStateNoLeadingZero:
                        currentState = HandleNegativeNumberStateNoLeadingZero(current);
                        break;
                    case NumberState.NegativeNumberStateLeadingZeroBeforeDecimalPoint:
                        currentState = HandleNegativeNumberStateLeadingZeroBeforeDecimalPoint(current);
                        break;
                    case NumberState.NextToDecimalPointState:
                        currentState = HandleNextToDecimalPointState(current);
                        break;
                    case NumberState.AfterDecimalPoint:
                        currentState = HandleAfterDecimalPointState(current);
                        break;
                    case NumberState.ExponentialState:
                        currentState = HandleExponentialState(current);
                        break;
                    case NumberState.PostExponentialState:
                        currentState = HandlePostExponentialState(current);
                        break;
                }
            }

            if (currentState == NumberState.ExponentialState ||
                currentState == NumberState.NextToDecimalPointState) { return false; }

            return currentState != NumberState.Invalid;
        }


        private static bool IsUnicodeValueValid(string input)
        {
            const int UNICODEVALUELENGTH = 6;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && i + 1 == input.Length - 1)
                {
                    return false;
                }

                if (input[i] == '\\' && input[i + 1] == 'u')
                {
                    return input.Length - i >= UNICODEVALUELENGTH
                           && IsHexaValue(input.Substring(i + 2, 4));
                }
            }

            return true;
        }

        private static bool IsEscapeValueValid(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && i + 1 == input.Length - 1)
                {
                    return false;
                }

                if (input[i] == '\\' && (i + 1 == input.Length || !IsEscapeCharValid(input[i + 1])))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsEscapeCharValid(char input)
        {
            return "\"\\/bfnrtu".Contains(input);
        }

        private static bool IsStringDelimitedByQuotes(string input)
        {
            return input.Length >= 2
                   && input[0].Equals('"')
                   && input[input.Length - 1].Equals('"');
        }

        private static bool IsStringContainingExtraQuotations(string input)
        {
            for (int i = 1; i < input.Length - 2; i++)
            {
                if (input[i] == '"')
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsHexaValue(string input)
        {
            foreach (var c in input)
            {
                if (!IsInRange(c, new[]
                    {
                        new Range('0', '9'),
                        new Range('a', 'f'),
                        new Range('A', 'F')
                    })
                )

                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsInRange(char c, Range[] ranges)
        {
            foreach (var r in ranges)
            {
                if (r.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        private struct Range
        {
            private readonly char start;
            private readonly char end;

            public Range(char start, char end)
            {
                this.start = start;
                this.end = end;
            }

            public bool Contains(char c)
            {
                return start <= c && c <= end;
            }
        }

        private static NumberState HandleStartState(char current)
        {
            if (current.Equals('-')) return NumberState.NegativeNumberState;

            if (current.Equals('0')) return NumberState.Invalid;

            if (digit.Contains(current)) return NumberState.NaturalNumberState;

            if (IsCharacterExponentialSign(current)) return NumberState.ExponentialState;

            return NumberState.Invalid;
        }

        private static NumberState HandleNaturalNumberState(char current)
        {
            if (digit.Contains(current)) return NumberState.NaturalNumberState;

            if (current.Equals('.')) return NumberState.NextToDecimalPointState;

            if (IsCharacterExponentialSign(current)) return NumberState.ExponentialState;

            return NumberState.Invalid;
        }

        private static NumberState HandleNegativeNumberState(char current)
        {
            if (current.Equals('0')) return NumberState.NegativeNumberStateLeadingZero;

            if (digit.Contains(current)) return NumberState.NegativeNumberStateNoLeadingZero;

            return NumberState.Invalid;
        }

        private static NumberState HandleNegativeNumberStateLeadingZero(char current)
        {
            if (current.Equals('.')) return NumberState.AfterDecimalPoint;

            return NumberState.Invalid;
        }

        private static NumberState HandleNegativeNumberStateNoLeadingZero(char current)
        {
            if (digit.Contains(current)) return NumberState.NegativeNumberStateNoLeadingZero;

            if (current == '.') return NumberState.NextToDecimalPointState;

            return NumberState.Invalid;
        }

        private static NumberState HandleNegativeNumberStateLeadingZeroBeforeDecimalPoint(char current)
        {
            if (digit.Contains(current)) return NumberState.AfterDecimalPoint;

            return NumberState.Invalid;
        }

        private static NumberState HandleAfterDecimalPointState(char current)
        {
            if (digit.Contains(current)) return NumberState.AfterDecimalPoint;

            if (IsCharacterExponentialSign(current)) return NumberState.ExponentialState;

            return NumberState.Invalid;
        }

        private static NumberState HandleNextToDecimalPointState(char current)
        {
            if (digit.Contains(current)) return NumberState.AfterDecimalPoint;

            if (IsCharacterExponentialSign(current)) return NumberState.Invalid;

            return NumberState.Invalid;
        }

        private static NumberState HandleExponentialState(char current)
        {
            if (IsCharacterPlusOrMinus(current)) return NumberState.ExponentialState;

            if (current.Equals('.')) return NumberState.Invalid;

            if (digit.Contains(current)) return NumberState.PostExponentialState;

            return NumberState.Invalid;
        }

        private static NumberState HandlePostExponentialState(char current)
        {
            if (digit.Contains(current)) return NumberState.PostExponentialState;

            if (current.Equals('.')) return NumberState.Invalid;

            return NumberState.Invalid;
        }

        private static bool IsCharacterExponentialSign(char current)
        {
            return current == 'E' || current == 'e';
        }

        private static bool IsCharacterPlusOrMinus(char current)
        {
            return current == '+' || current == '-';
        }
    }
}