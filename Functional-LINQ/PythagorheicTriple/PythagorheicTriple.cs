using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional_LINQ.PythagorheicTriple
{
    internal class PythagorheicTriple
    {
        public PythagorheicTriple() => PythagoreicTriples = Enumerable.Empty<int[][]>();
        public IEnumerable<int[][]> PythagoreicTriples { get; set; }
        public IEnumerable<IEnumerable<int>> PythaghoreicTriples { get; private set; }

        public void GeneratePythaghoreicTriple(int first, int second, int third)
        {
            var input = new int[] { first, second, third };

            var AllCombinations = input.Select(x => Enumerable.Repeat(x, 1).Union(input))
                .Select(x => new { firstPermutation = x, 
                    secondPermutation = x.Take(1).Union(x.Skip(1).Reverse()).ToArray()}).ToArray();
        }
    }
}
