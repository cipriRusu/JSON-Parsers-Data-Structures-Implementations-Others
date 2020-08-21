using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChessMoves.Moves
{
    public class EnPassantUserMove : UserMove, IUserMove
    {
        public EnPassantUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
