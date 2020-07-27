using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveUserMove : UserMove, IMove
    {
        public MoveUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
