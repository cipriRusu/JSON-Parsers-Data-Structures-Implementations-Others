using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional_LINQ.PythagorheicTriple
{
    internal class PythagorheicTriple
    {
        public PythagorheicTriple() => PytagorheicTriples = Enumerable.Empty<int[]>();
        public IEnumerable<int[]> PytagorheicTriples { get; set; }

        public void GeneratePythaghoreicTriple(int first, int second, int third)
        {
            ArgumentExceptions(first, second, third);

            var input = new int[] { first, second, third };

            var AllCombinations =
                input.Select(x => Enumerable.Repeat(x, 1).Union(input)).Select(x =>
                new { f = x.ToArray(), s = x.Take(1).Union(x.Skip(1).Reverse()).ToArray() });

            PytagorheicTriples = AllCombinations
                .Select(x => x.f)
                .Concat(AllCombinations.Select(x => x.s))
                .Where(x => (
                Math.Pow(x[0], 2) + 
                Math.Pow(x[1], 2)).Equals(Math.Pow(x[2], 2)));
        }

        private static void ArgumentExceptions(int first, int second, int third)
        {
            if (first <= 0 || second <= 0 || third <= 0)
            {
                throw new ArgumentException("Input value(s) cannot be null");
            }
        }
    }
}
