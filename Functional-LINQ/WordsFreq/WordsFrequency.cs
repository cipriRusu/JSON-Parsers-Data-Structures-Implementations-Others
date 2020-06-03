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
            var stringSplitPoints = new char[] { ' ', '.', ',', ':', '!', '?', '\n' };

            return input
                .ToLower()
                .Split(stringSplitPoints, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(x => x).OrderByDescending(y => y.Count())
                .ToDictionary(x => x.Key, y => y.Count());
        }
    }
}
