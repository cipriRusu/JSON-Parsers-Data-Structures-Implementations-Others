using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.PythagorheicTriple
{
    internal class PythagorhicTriple
    {
        internal IEnumerable<(int a, int b, int c)> GetTriple(int[] input)
        {
            var triplets = input.SelectMany((a, b) => input.Skip(b + 1).SelectMany((n, t) =>
            input.SkipWhile(q => q + 1 > n).Select(j => (a, n, j))));

            return triplets.Where(x => Math.Pow(x.a, 2) == Math.Pow(x.n, 2) + Math.Pow(x.j, 2));
        }
    }
}