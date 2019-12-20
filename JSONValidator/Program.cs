using System;

namespace JSONValidator
{
    public class Program
    {
        static void Main()
        {

        }

        public static bool ValidateJson(string inputValue)
        {
            return ValidateJsonString(inputValue);
        }

        private static bool ValidateJsonString(string inputValue)
        {
            for (int i = 0; i < inputValue.Length; i++)
            {
                return inputValue[0] == '\"' && inputValue[inputValue.Length - 1] == '\"';
            }

            return false;
        }
    }
}
