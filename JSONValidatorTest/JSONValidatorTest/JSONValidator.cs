using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorTest
{
    public class ValidateJsonInput
    {
        public static bool JsonStringValidator(string inputJsonString)
        {
            if (inputJsonString.Length > 1)
            {
                return (inputJsonString[0] == '\"') && inputJsonString[inputJsonString.Length - 1] == '\"';
            }

            return false;
        }
    }
}
