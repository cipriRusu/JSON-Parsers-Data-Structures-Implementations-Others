using ChessMoves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Moves
{
    public class Move
    {
        private IPiece[,] board;
        private IPiece currentMovablePiece;

        public Move(IPiece[,] board, IPiece currentMovablePiece)
        {
            this.board = board;
            this.currentMovablePiece = currentMovablePiece;
        }

        internal void ApplyMove(IUserMove move)
        {
            var (firstIndex, secondIndex) = currentMovablePiece.Index;

            board[move.Index.Item1, move.Index.Item2] =
            board[currentMovablePiece.Index.Item1, currentMovablePiece.Index.Item2];

            board[firstIndex, secondIndex] = null;
        }
    }
}
