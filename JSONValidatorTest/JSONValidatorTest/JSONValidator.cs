using System;

namespace JSONValidatorTest
{
    public class ValidateJsonInput
    {
        public static bool JsonStringValidator(string inputJsonString)
        {
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

            if (IsUnicodeValuePresent(inputJsonString))
            {
                return IsUnicodeValueValid(inputJsonString);
            }

            return true;
        }

        public static bool JsonNumberValidator(string inputJsonNumber)
        {
            return true;
        }

        private static bool IsUnicodeValueValid(string input)
        {
            const int PREFIXOFFSETVALUE = 2;
            const int UNICODEVALUELENGTH = 4;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u')
                {
                    var extractedUnicode = input.Substring(i+ PREFIXOFFSETVALUE, UNICODEVALUELENGTH);
                    if (!IsExtractedUnicodeStringValid(extractedUnicode))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsUnicodeValuePresent(string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u')
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsEscapeValueValid(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && !IsEscapeCharValid(input[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsEscapeCharValid(char input)
        {
            var possibleEscapeChars = new char[] { '"', '\\', '/', 'b', 'f', 'n', 'r', 't', 'u'};

            for (int i = 0; i < possibleEscapeChars.Length; i++)
            {
                if (input == possibleEscapeChars[i])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsStringDelimitedByQuotes(string input)
        {
            return input[0].Equals('"') && input[input.Length - 1].Equals('"') ? true : false;
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

        private static bool IsExtractedUnicodeStringValid(string input)
        {
            input = input.ToLower();
            for (int i = 0; i < input.Length; i++)
            {
                if (!(input[i] >= '0' && input[i] <= '9' || input[i] >= 'a' && input[i] <= 'f'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
