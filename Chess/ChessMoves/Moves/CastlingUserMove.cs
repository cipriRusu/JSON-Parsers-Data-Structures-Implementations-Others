using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class CastlingUserMove : UserMove, IUserMove
    {
        public CastlingUserMove(string input, Player turnToMove) : base(input, turnToMove) { }
    }
}
