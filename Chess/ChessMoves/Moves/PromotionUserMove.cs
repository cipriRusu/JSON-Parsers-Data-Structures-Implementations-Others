using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PromotionUserMove : UserMove, IUserMove
    {
        public PromotionUserMove(string input, Player playerTurn) : base(input, playerTurn)
        {
        }
    }
}
