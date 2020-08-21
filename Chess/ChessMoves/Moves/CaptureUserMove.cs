using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CaptureUserMove : UserMove, IUserMove
    {
        public CaptureUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
        public override bool HasPath(IEnumerable<IPath> allPaths) => allPaths.Any(x => x.End == Index);
    }
}
