using System;

namespace JSONValidatorAlternativeVersion
{
    internal class Choice : IPattern
    {
        private readonly IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        { this.patterns = patterns; }

        public IMatch Match(string text)
        {
            IMatch match = new Match(text, true);

            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (match.Success())
                {
                    return match;
                }
            }

            return match;
        }
    }
}
