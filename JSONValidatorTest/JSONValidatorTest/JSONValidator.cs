using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorTest
{
    public class ValidateJsonInput
    {
        public static bool JsonStringValidator(string inputJsonString)
        {
            return IsStringDelimitedByQuotes(inputJsonString);
        }

        private static bool IsStringDelimitedByQuotes(string input)
        {
            return input[0].Equals('"') && input[input.Length - 1].Equals('"') ? true : false;
        }
    }
}
