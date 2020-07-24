using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    internal class SpecialMoveHandler
    {
        private readonly UserMove move;
        private readonly ChessBoard chessBoard;

        public SpecialMoveHandler(UserMove move, ChessBoard chessBoard)
        {
            this.move = move;
            this.chessBoard = chessBoard;

            MoveHandler();
        }

        private void MoveHandler()
        {
            if (move.IsCastling)
            {
                new Castling(chessBoard, move);
            }
            else if (move.IsPromotion)
            {
                new Promotion(chessBoard, move);
            }
            else if (move.IsEnPassant)
            {
                new EnPassant(chessBoard, move);
            }
        }
    }
}