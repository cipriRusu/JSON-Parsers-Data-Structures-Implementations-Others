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

            HandleCastling();
        }

        private void HandleCastling()
        {
            new Castling(chessBoard, move);
        }
    }
}