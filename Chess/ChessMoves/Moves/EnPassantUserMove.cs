using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChessMoves.Moves
{
    public class EnPassantUserMove : UserMove, IUserMove
    {
        public EnPassantUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public void GetCurrentState(IBoardState board)
        {
            if (board.CheckPassant(this, out IChessPiece piece))
            {
                board.PerformPassant(this, piece);
            }
            else
            {
                throw new UserMoveException("En passant move illegal!");
            }

            switch (PlayerColor)
            {
                case Player.White:
                    break;
                case Player.Black:
                    break;
            }
        }
    }
}
