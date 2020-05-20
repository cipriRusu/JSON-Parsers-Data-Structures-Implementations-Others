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
            var sortedInput = input.OrderByDescending(x => x).ToHashSet();

            PytagorheicTriples = sortedInput.Select(x =>
            new
            {
                r = x,
                s = sortedInput.Where(a => a < x)
                .Select(y => new
                {
                    t = y,
                    q = sortedInput.SkipWhile(x => x >= y)
                    .Where(a => Math.Pow(y, 2) + Math.Pow(a, 2) == Math.Pow(x, 2))
                }).Where(x => x.q.Count() > 0)
            }).Where(x => x.s.Count() > 0)
            .ToDictionary(x => x.r, x => new int[]
            {
                x.s.First().t,
                x.s.First().q.First()
            });
        }
    }
}