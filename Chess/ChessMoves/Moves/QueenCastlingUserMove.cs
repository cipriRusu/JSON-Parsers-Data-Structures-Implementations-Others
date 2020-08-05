using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class QueenCastlingUserMove : UserMove, IUserMove
    {
        public QueenCastlingUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public new void GetCurrentState(IBoardState board)
        {
            if(board.IsCastlingValid(this))
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
