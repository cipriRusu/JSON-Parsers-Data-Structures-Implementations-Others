using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ChessMoves.Paths
{
    class PathComparer : IEqualityComparer<IPath>
    {
        public bool Equals([AllowNull] IPath x, [AllowNull] IPath y)
        {
            return
                x.Start == y.Start &&
                x.End == y.End && ElementsChecker(x, y);
        }

        private bool ElementsChecker(IPath x, IPath y)
        {
            for(int i = 0; i < x.Path.Count(); i++)
            {
                if(x.Path.ElementAt(i) != y.Path.ElementAt(i))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode([DisallowNull] IPath input)
        {
            return input.GetHashCode();
        }
    }
}
