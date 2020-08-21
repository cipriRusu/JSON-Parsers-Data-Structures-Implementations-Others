using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class QueenCastlingUserMove : UserMove, IUserMove
    {
        public QueenCastlingUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
