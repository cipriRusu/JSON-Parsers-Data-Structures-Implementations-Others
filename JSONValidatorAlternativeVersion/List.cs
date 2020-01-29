using System;

namespace JSONValidatorAlternativeVersion
{
    internal class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            var alternateSequencePattern =
                new Sequence(
                    new Optional(element),
                    new Many(new Sequence(separator, element)));

            this.pattern = alternateSequencePattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
