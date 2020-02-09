using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorAlternativeVersion
{
    class Value : IPattern
    {
        public readonly IPattern pattern;
        public Value()
        {
            var openbracket = new Character('[');
            var closedbracket = new Character(']');
            var openAccolade = new Character('{');
            var closedAccolade = new Character('}');
            var comma = new Character(',');
            var separator = new Character(':');
            var whitespace = new Many(new Any(" \n\r\t"));

            var pattern =
                new Choice(
                    new String(),
                    new Number(),
                    new Text("true"),
                    new Text("false"),
                    new Text("null"));

            var array = new List(pattern, whitespace);
            
            pattern.Add(array);

            this.pattern = new Sequence(whitespace, pattern, whitespace);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
