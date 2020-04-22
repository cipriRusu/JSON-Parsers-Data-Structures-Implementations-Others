using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Functional_LINQ
{
    class CombinedComparer<T> : IComparer<T>
    {
        readonly List<IComparer<T>> comparers = new List<IComparer<T>>();

        public CombinedComparer(IComparer<T> firstComparer, IComparer<T> secondComparer)
        {
            comparers.Add(firstComparer);
            comparers.Add(secondComparer);
        }

        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            foreach(var comparer in comparers)
            {
                var result = comparer.Compare(x, y);

                if(result != 0)
                {
                    return result;
                }
            }

            return 0;
        }
    }
}
