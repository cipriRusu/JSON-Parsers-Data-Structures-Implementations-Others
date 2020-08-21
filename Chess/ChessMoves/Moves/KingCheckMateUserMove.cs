using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class KingCheckMateUserMove : UserMove, IUserMove
    {
        public KingCheckMateUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
