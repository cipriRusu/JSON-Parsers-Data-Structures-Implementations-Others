using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorAlternativeVersion
{
    internal class Number : IPattern
    {
        private readonly IPattern pattern;
        public Number()
        {
            pattern = new Sequence(
                    new Optional(new Character('-')), 
                    new OneOrMore(new Range('1', '9')),
                    new Many(new Choice(new Character('.'), 
                            new OneOrMore(new Range('0', '9')
                        ))));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
