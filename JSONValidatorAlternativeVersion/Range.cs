using System;

namespace JSONValidatorAlternativeVersion
{
    internal class Range : IPattern
    {
        private char startChar;
        private char endChar;

        public Range(char inputStartChar, char inputEndChar)
        {
            this.startChar = inputStartChar;
            this.endChar = inputEndChar;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && 
                   startChar <= text[0] &&
                   text[0] <= endChar
                ? new Match(text.Substring(1), true)
                : new Match(text, false);
        }
    }
}
