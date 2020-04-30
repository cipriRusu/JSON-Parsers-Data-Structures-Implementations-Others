using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.FirstNonRepeatingCharacter
{
    internal class FirstNonRepeatingCharacter
    {
        public char FirstNonRepChar { get; internal set; }

        private string input;

        public FirstNonRepeatingCharacter(string input)
        {
            if (input != null)
            {
                this.input = input;
                FindFirstNonRepeatingCharacter();
            }
            else
            {
                throw new ArgumentNullException("Input value was null");
            }
        }

        private void FindFirstNonRepeatingCharacter()
        {
            var buffer = input.GroupBy(x => x).ToDictionary(x => x, x => x.Count())
                .SkipWhile(x => x.Value != 1).ToDictionary(x => x.Key, y => y.Value);

            FirstNonRepChar = buffer.Keys.First().Key;
        }
    }
}
