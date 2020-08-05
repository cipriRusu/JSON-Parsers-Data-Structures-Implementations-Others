using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChessMoves.Moves
{
    public class KingCastlingUserMove : UserMove, IUserMove
    {
        public KingCastlingUserMove(string input, Player turnToMove) : base(input, turnToMove) { }

        public new void GetCurrentState(IBoardState board)
        {
            if (board.CheckCastling(this))
            {
                board.PerformCastling(this);
            }
            else
            {
                throw new UserMoveException("Illegal castling move");
            }
        }
    }
}
