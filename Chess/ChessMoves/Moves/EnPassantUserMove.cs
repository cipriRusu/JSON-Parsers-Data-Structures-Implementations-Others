using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChessMoves.Moves
{
    public class EnPassantUserMove : UserMove, IUserMove
    {
        public EnPassantUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public new void GetCurrentState(IBoardState board)
        {
            if(board.CheckPassant(this))
            {
                board.PerformPassant(this);
            }
            else
            {
                throw new UserMoveException("Illegal EnPassant move!!");
            }
        }
    }
}
