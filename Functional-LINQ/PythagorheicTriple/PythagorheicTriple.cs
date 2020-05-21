using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.PythagorheicTriple
{
    internal class PythagorheicTriple
    {
        public PythagorheicTriple() => PytagorheicTriples = new Dictionary<int, int[]>();

        public Dictionary<int, int[]> PytagorheicTriples { get; set; }

        public void ComputeTriples(int[] input)
        {
            var sortedInput = input
                .Where(x => x > 0)
                .Distinct()
                .OrderByDescending(x => x);

            PytagorheicTriples = sortedInput
            .Select(x => new
            {
                Result = x,
                Expressions = sortedInput
                .Where(current => current < x)
                .Select(nestedCurrent => sortedInput
                .SkipWhile(x => x > nestedCurrent)
                    .Select(z => new int[] { nestedCurrent, z })
                    .Skip(1)
                    .Where(expression => IsPythaghorean(x, expression)))
                .Where(x => x.Count() > 0)
            }).Where(x => x.Expressions.Count() > 0)
            .ToDictionary(x => x.Result, x => x.Expressions.Single().Single());
        }

        private static bool IsPythaghorean(int result, int[] expression) =>
            Math.Pow(result, 2) == 
            Math.Pow(expression.First(), 2) + 
            Math.Pow(expression.Last(), 2);
    }
}