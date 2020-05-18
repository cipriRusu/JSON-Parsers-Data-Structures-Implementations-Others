using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.PythagorheicTriple
{
    internal class PythagorheicTriple
    {
        public PythagorheicTriple() => PytagorheicTriples = new Dictionary<int, IEnumerable<int>[]>();

        public Dictionary<int, IEnumerable<int>[]> PytagorheicTriples { get; set; }

        public void ComputeTriples(int[] input)
        {
            InputArrayExceptions(input);

            PytagorheicTriples = input.Select(x => new
            {
                result = x,
                permutations =
                GetAllPermutations(input
                .Except(Enumerable.Repeat(x, 1)), 2)
                .Where(y => IsPythaghorean(x, y)).ToArray()
            })
            .Where(x => x.permutations.Count() > 0)
            .ToLookup(x => x.result, x => x.permutations)
            .ToDictionary(x => x.Key, x => x.First());
        }

        private static bool IsPythaghorean(int x, IEnumerable<int> y)
        {
            EnumerableExceptions(y);
            return Math.Pow(x, 2) == Math.Pow(y.First(), 2) + Math.Pow(y.Last(), 2);
        }

        private static IEnumerable<IEnumerable<T>> GetAllPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetAllPermutations(list, length - 1).SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        private static void EnumerableExceptions(IEnumerable<int> input)
        {
            foreach (var v in input.Where(number => number < 0).Select(number => new { }))
            {
                throw new ArgumentException("Pythaghorean triplet must contain only positive integers");
            }
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