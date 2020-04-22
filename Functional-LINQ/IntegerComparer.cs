using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Functional_LINQ
{
    public partial class LINQImplementationTest
    {
        public class IntegerComparer : IComparer<int>
        {
            public int Compare([AllowNull] int x, [AllowNull] int y)
            {
                return x.CompareTo(y);
            }
        }
    }
}
