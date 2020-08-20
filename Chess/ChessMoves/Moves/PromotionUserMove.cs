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

        public new void GetCurrentState(IBoard board)
        {
            var internalMove = new MoveType(NotationIndex, PlayerColor).Move;
            internalMove.GetCurrentState(board);

            if (board[Index] != null && board[Index].PieceType == PieceType.Pawn)
            {
                switch (PlayerColor)
                {
                    case Player.White when board[Index].Index.Item1 == WhiteEnd:
                        board[Index].Promote(board);
                        break;
                    case Player.Black when board[Index].Index.Item1 == BlackEnd:
                        board[Index].Promote(board);
                        break;
                }
            }
        }
    }
}
