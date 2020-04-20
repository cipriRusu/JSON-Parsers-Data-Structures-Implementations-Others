using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Functional_LINQ
{
    class CombinedComparer<T> : IComparer<T>
    {
        IComparer<T> firstComparer;
        IComparer<T> secondComparer;

        public CombinedComparer(IComparer<T> firstComparer, IComparer<T> secondComparer)
        {
            this.firstComparer = firstComparer;
            this.secondComparer = secondComparer;
        }

        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            var firstResult = firstComparer.Compare(x, y);
            if(firstResult != 0)
            {
                return firstResult;
            }
            return secondComparer.Compare(x, y);
        }
    }
}
