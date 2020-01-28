using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorAlternativeVersion
{
    internal class Text : IPattern
    {
        private readonly string prefixValue;
        public Text(string prefix)
        { prefixValue = prefix; }

        public IMatch Match(string text)
        {
            return !IsAnyValueNull(prefixValue, text) && IsPrefixLeadingString(prefixValue, text)
                ? new Match(text.Substring(prefixValue.Length), true)
                : new Match(text, false);
        }

        private bool IsAnyValueNull(string prefixValue, string text)
        {
            return prefixValue == null || text == null;
        }

        private bool IsPrefixLeadingString(string prefixValue, string text)
        {
            return text.Contains(prefixValue) && text.Substring(0, prefixValue.Length).Equals(prefixValue);
        }
    }
}
