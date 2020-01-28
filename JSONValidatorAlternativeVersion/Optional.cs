using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorAlternativeVersion
{
    internal class Optional : IPattern
    {
        private readonly IPattern currentPattern;

        public Optional(IPattern pattern)
        {
            currentPattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = currentPattern.Match(text);

            if(match.Success())
            {
                return new Match(match.RemainingText(), match.Success());
            }

            return new Match(text, true);
        }
    }
}
