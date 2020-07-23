using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    internal class SpecialMoveHandler
    {
        private UserMove move;
        private ChessBoard chessBoard;

        public SpecialMoveHandler(UserMove move, ChessBoard chessBoard)
        {
            this.move = move;
            this.chessBoard = chessBoard;

            MoveHandler();
        }

        private void MoveHandler()
        {
            if (move.UserMoveType == UserMoveType.KingCastling ||
                move.UserMoveType == UserMoveType.QueenCastling)
            {
                new Castling(chessBoard, move);
            }
            if (move.IsPromotion)
            {
                new Promotion(chessBoard, move);
            }
        }
    }
}