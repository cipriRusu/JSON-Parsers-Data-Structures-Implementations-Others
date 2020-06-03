using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.SudokuBoardChecker
{
    public static class EnumerableChecker
    {
        public static bool ContainsAllDigits(this IEnumerable<int> input) =>
                Enumerable.Range(1, 9).All(x => input.Contains(x));
    }
}
