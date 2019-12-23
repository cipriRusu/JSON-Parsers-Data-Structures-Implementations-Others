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

            return true;
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
