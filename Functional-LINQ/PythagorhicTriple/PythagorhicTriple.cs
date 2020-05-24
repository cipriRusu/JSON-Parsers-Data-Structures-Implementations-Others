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
            InputArrayExceptions(input);

            var sortedInput = input.Where(x => x > 0).OrderByDescending(y => y);

            var triples = sortedInput
                .SelectMany((a, b) => sortedInput
                    .Skip(b + 1)
                    .SelectMany((n, t) => sortedInput
                        .SkipWhile(q => q + 1 > n)
                        .Select(j => (a, n, j))));

            return CheckTriple(triples);
        }

        private static IEnumerable<(int a, int b, int c)> CheckTriple(IEnumerable<(int a, int n, int j)> triplets)
        {
            return triplets.Where(
                x => Math.Pow(x.a, 2) ==
                     Math.Pow(x.n, 2) + 
                     Math.Pow(x.j, 2));
        }

        private static void InputArrayExceptions(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Input value is null");
            }
        }
    }
}