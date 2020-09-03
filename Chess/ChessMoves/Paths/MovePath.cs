using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Paths
{
    public class MovePath : Path
    {
        public MovePath(IEnumerable<(int, int)> path, (int, int) pathStart) : base(path, pathStart)
        {
            FullPath = path.Skip(1);
        }
    }
}
