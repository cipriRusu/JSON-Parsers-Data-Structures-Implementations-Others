using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class CheckMateUserMove : UserMove, IUserMove
    {
        public CheckMateUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
