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
            pattern = new Optional(
                new Sequence(
                    element,
                    new Many(new Sequence(separator, element))
                )
            );
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}