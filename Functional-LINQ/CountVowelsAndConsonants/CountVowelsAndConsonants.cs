using System;
using System.Linq;
using System.Text;

namespace Functional_LINQ.CountVowelsAndConsonants
{
    internal class CountVowelsAndConsonants
    {
        private string _totalVowels = "aeiou";
        private string _inputString;
        public int VowelCount { get; internal set; }
        public int ConsonantCount { get; internal set; }

        public CountVowelsAndConsonants(string inputString)
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

        private void CountMethod()
        {
            var selectOnlyLetters = _inputString.ToLower()
                .Where(x => Char.IsLetter(x));

            VowelCount = selectOnlyLetters.
                Where(x => _totalVowels.Contains(x)).
                ToList().Count();

            ConsonantCount = selectOnlyLetters.Count() - VowelCount;
        }
    }
}
