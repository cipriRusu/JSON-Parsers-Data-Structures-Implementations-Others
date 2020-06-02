using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Functional_LINQ.WordsFreq
{
    public class WordsFrequency
    {
        internal Dictionary<string, int> WordFrequency(string input)
        {
            return input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToLookup(x => new string(x.Where(c => char.IsLetter(c)).ToArray()).ToLower())
                .Where(kv => kv.Key != string.Empty).OrderByDescending(x => x.Count())
                .ToDictionary(x => x.Key, y => y.Count());
        }
    }
}
