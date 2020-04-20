using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Functional_LINQ
{
    public class ProjectedComparer<TElement, TKey> : IComparer<TElement>
    {
        Func<TElement, TKey> keySelector;
        IComparer<TKey> comparer;

        public ProjectedComparer(Func<TElement, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.comparer = comparer;
            this.keySelector = keySelector;
        }

        public int Compare([AllowNull] TElement x, [AllowNull] TElement y)
        {
            var firstKey = keySelector(x);
            var secondKey = keySelector(y);

            return comparer.Compare(firstKey, secondKey);
        }
    }
}
