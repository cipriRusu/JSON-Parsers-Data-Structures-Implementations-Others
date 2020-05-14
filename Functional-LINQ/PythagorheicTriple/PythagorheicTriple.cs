using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional_LINQ.PythagorheicTriple
{
    internal class PythagorheicTriple
    {
        public PythagorheicTriple() => PythagoreicTriples = Enumerable.Empty<int[]>();
        public IEnumerable<int[]> PythagoreicTriples { get; set; }

        public void GeneratePythaghoreicTriple(int first, int second, int third)
        {
            ArgumentExceptions(first, second, third);

            var input = new int[] { first, second, third };

            var AllCombinations =
                input.Select(x => Enumerable.Repeat(x, 1).Union(input)).Select(x =>
                new { f = x.ToArray(), s = x.Take(1).Union(x.Skip(1).Reverse()).ToArray() });

            PythagoreicTriples = 
                AllCombinations.Select(x => x.f).Concat(AllCombinations.Select(x => x.s))
                .Where(x => (x[0] ^ 2).Equals(x[1] ^ (2 + x[2]) ^ 2));
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
