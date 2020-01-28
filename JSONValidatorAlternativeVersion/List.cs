using System;

namespace JSONValidatorAlternativeVersion
{
    internal class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            var listSequence = new Sequence(
                new Many(
                    new Choice(
                        new Sequence(separator, element, separator),
                        new Sequence(separator, element), element)));
            this.pattern = listSequence;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
