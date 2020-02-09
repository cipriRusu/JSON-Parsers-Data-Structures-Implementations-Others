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

            var array = new Sequence(
                openbracket,
                new List(pattern, new Sequence(comma, whitespace)),
                closedbracket);

            var objectValues =
                 new Sequence(
                     whitespace,
                     new String(),
                     whitespace,
                     separator,
                     whitespace,
                     pattern);

            var obj =
                new Sequence(
                    openAccolade,
                    whitespace,
                    new List(objectValues, comma),
                    whitespace,
                    closedAccolade);

            pattern.Add(array);
            pattern.Add(obj);

            this.pattern = new Sequence(whitespace, pattern, whitespace);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
