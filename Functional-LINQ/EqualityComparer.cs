using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Functional_LINQ
{
    public partial class FunctionalLINQTest
    {
        public class EqualityComparer<T> : IEqualityComparer<T>
        {
            public bool Equals([AllowNull] T x, [AllowNull] T y)
            {
                return x.Equals(y);
            }

            public int GetHashCode([DisallowNull] T obj)
            {
                return GetHashCode();
            }
        }
    }
}
