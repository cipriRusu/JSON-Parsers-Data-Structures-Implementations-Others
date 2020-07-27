using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class CheckMateUserMove : UserMove
    {
        public CheckMateUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
