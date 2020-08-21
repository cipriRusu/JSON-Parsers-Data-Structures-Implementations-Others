using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class KingCheckUserMove : UserMove, IUserMove
    {
        public KingCheckUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
