using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional_LINQ.CountVowelsAndConsonants
{
    internal class LINQStringMethods
    {
        private readonly string _totalVowels = "aeiou";
        private string _inputString;
        public int VowelCount { get; internal set; }
        public int ConsonantCount { get; internal set; }
        public char FirstNonRepetitiveCharacter { get; internal set; }
        public int ConvertedStringToInteger { get; internal set; }
        public char MaximumAparitionCharacter { get; internal set; }
        public string Palindromes { get; internal set; }

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
            if (inputString != null)
            {
                _inputString = inputString;
                ConvertedStringToInteger = inputString.Aggregate(0, (x, y) => x * 10 + y - '0');
            }
            else
            {
                throw new ArgumentNullException("Input value was null");
            }
        }

        public void MaxApparitionChar(string inputString)
        {
            if (inputString != null)
            {
                MaximumAparitionCharacter =
                    inputString.SelectMany((x, y) => inputString.Select(x => x))
                    .GroupBy(x => x).First().Key;
            }
            else
            {
                throw new ArgumentNullException("Input value was null");
            }
        }
        public void GetPalindromes(string inputString)
        {
            if (inputString != null)
            {
                var completeQuery = inputString.Select((FirstCharacter, FirstIndex) =>
                inputString.Substring(FirstIndex).Select((SecondCharacter, SecondIndex) =>
                inputString.Substring(FirstIndex, SecondIndex + 1)));

                var palindromesOnly = completeQuery.SelectMany(x => x).Where(x => IsPalindrome(x));
                Palindromes = string.Join(",", palindromesOnly);
            }
            else
            {
                throw new ArgumentNullException("Input value is null");
            }
        }

        private bool IsPalindrome(string input)
        {
            return input.ToString() == new string(input.Reverse().ToArray());
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
    }
}