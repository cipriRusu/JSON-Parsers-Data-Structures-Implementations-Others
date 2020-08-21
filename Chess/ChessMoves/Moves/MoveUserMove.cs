using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveUserMove : UserMove, IUserMove
    {
        public MoveUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
        public override bool ContainsValidPath(IEnumerable<IPath> allPaths) => allPaths.Any(x => x.End == Index);
    }
}
