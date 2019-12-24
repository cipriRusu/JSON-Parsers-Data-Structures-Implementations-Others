using System;
using System.Collections.Generic;
using System.Text;

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
            
            return true;
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
            var possibleEscapeChars = new char[] { '"', '\\', '/', 'b', 'f', 'n', 'r', 't' };

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
    }
}
