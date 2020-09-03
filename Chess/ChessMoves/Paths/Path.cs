using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ChessMoves.Paths
{
    public class Path : IPath
    {
        internal IEnumerable<(int, int)> FullPath;
        public Path(IEnumerable<(int, int)> path, (int, int) pathStart)
        {
            if (path.Count() >= 2)
            {
                Start = pathStart;
                End = path.Last();
            }
            else
            {
                Start = pathStart;
                End = path.Single();
            }
        }

        public (int, int) Start { get; }
        public (int, int) End { get; }
        IEnumerable<(int, int)> IPath.Path => FullPath;
    }
}
