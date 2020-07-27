using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class CastlingUserMove : UserMove, IMove
    {
        public CastlingUserMove(string input, Player turnToMove) : base(input, turnToMove) { }
    }
}
