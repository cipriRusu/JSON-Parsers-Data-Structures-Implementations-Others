using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class EnPassantUserMove : UserMove
    {
        public EnPassantUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
