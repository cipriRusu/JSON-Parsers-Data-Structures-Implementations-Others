using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorAlternativeVersion
{
    internal class Text : IPattern
    {
        private readonly string prefixValue;
        public Text(string prefix)
        {
            prefixValue = prefix ?? null;
        }

        public IMatch Match(string text)
        {
            return text == null || prefixValue == null ? new Match(null, false)
                : text.Contains(prefixValue) &&
                text.Substring(0, prefixValue.Length) == prefixValue
                ? new Match(text.Substring(prefixValue.Length), true)
                : new Match(text, false);
        }
    }
}
