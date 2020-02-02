﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONValidatorAlternativeVersion
{
    internal class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            pattern = new Choice(new Sequence(element, new Many(new Sequence(separator, element))), new Optional(element));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
