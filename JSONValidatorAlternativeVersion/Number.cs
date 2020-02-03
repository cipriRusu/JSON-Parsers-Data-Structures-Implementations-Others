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
            var plus = new Character('+');
            var minus = new Character('-');
            var zero = new Character('0');
            var point = new Character('.');
            var exponent = new Choice(new Character('E'), new Character('e'));
            var digit = new Range('0', '9');
            var onenine = new Range('1', '9');
            var digits = new OneOrMore(digit);
            var natural = new OneOrMore(onenine);

            var integer = new Sequence(
                new Optional(minus),
                new Optional(new Sequence(zero, point)), 
                natural); 

            var fractional = new Sequence(point, digits);

            var exponential = new Sequence(exponent, new Choice(plus, minus), digits);

            pattern = 
                new Sequence(integer, new Optional(fractional), new Optional(exponential));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
