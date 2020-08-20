using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChessMoves.Moves
{
    public class EnPassantUserMove : UserMove, IUserMove
    {
        public EnPassantUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public new void GetCurrentState(IBoard board)
        {
            if(board.CheckPassant(this, out IPiece chessPiece))
            {
                board.PerformPassant(this, chessPiece);
            }
            else
            {
                throw new UserMoveException("Illegal EnPassant move!!");
            }
        }
    }
}
