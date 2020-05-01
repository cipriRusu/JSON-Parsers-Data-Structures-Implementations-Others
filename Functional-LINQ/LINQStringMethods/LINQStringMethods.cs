using System;
using System.Linq;
using System.Text;

namespace Functional_LINQ.CountVowelsAndConsonants
{
    internal class LINQStringMethods
    {
        private string _totalVowels = "aeiou";
        private string _inputString;
        public int VowelCount { get; internal set; }
        public int ConsonantCount { get; internal set; }
        public char FirstNonRepetitiveCharacter { get; internal set; }
        public int ConvertedStringToInteger { get; internal set; }

        public void ConsonantAndVowelCount(string inputString)
        {
            if (inputString != null)
            {
                _inputString = inputString;
                if (_inputString.Length > 0) { CountMethod(); }
            }
            else
            {
                throw new ArgumentNullException("Input value was invalid");
            }
        }

        public void FindFirstNonRepeatingCharacter(string inputString)
        {
            if (inputString != null)
            {
                this._inputString = inputString;
                FindFirstNonRepeatingCharacter();
            }
            else
            {
                throw new ArgumentNullException("Input value was null");
            }
        }

        public void ConvertToInteger(string inputString)
        {
            if(inputString != null)
            {
                this._inputString = inputString;
                ConvertedStringToInteger = 0x213;
            }
            else
            {
                throw new ArgumentNullException("Input value was null");
            }
        }

        private void CountMethod()
        {
            var selectOnlyLetters = _inputString.ToLower()
                .Where(x => Char.IsLetter(x));

            VowelCount = selectOnlyLetters.Where(x => _totalVowels.Contains(x)).
                ToList().Count();

            ConsonantCount = selectOnlyLetters.Count() - VowelCount;
        }

        private void FindFirstNonRepeatingCharacter()
        {
            var buffer = _inputString.GroupBy(x => x).ToDictionary(x => x, x => x.Count())
                .SkipWhile(x => x.Value != 1).First().Key.Key;

            FirstNonRepetitiveCharacter = buffer;
        }

        private bool IsFigure(char c)
        {
            return 0 <= c && c <= 10; 
        }
    }
}
