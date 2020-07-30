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

        public void GetCurrentState(IBoardState board)
        {
            var internalMove = new MoveType(NotationIndex, PlayerColor).Move;
            internalMove.GetCurrentState(board);

            if (board[MoveIndex] != null && board[MoveIndex].PieceType == PieceType.Pawn)
            {
                switch (PlayerColor)
                {
                    case Player.White when board[MoveIndex].CurrentPosition.Item1 == WhiteEnd:
                        board[MoveIndex].Promote(board);
                        break;
                    case Player.Black when board[MoveIndex].CurrentPosition.Item1 == BlackEnd:
                        board[MoveIndex].Promote(board);
                        break;
                }
            }
        }
    }
}
