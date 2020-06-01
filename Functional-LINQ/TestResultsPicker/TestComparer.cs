using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Functional_LINQ.TestResultsPicker
{
    internal class TestComparer : IEqualityComparer<IEnumerable<TestResults>>
    {
        public bool Equals([AllowNull] IEnumerable<TestResults> firstCollection,
            [AllowNull] IEnumerable<TestResults> secondCollection) => firstCollection != null &&
            firstCollection.Select(firstElement => secondCollection != null && secondCollection.Contains(firstElement))
            .All(isElementPresent => isElementPresent == true);

        public int GetHashCode([DisallowNull] IEnumerable<TestResults> input) =>
            input.GetHashCode();
    }
}