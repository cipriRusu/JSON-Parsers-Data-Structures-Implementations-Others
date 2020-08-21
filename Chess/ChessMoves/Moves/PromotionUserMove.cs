using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PromotionUserMove : UserMove, IUserMove
    {
        private int WhiteEnd = 0;
        private int BlackEnd = 7;
        public PromotionUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
