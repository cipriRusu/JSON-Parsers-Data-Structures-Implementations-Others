using ChessMoves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Moves
{
    public class Move
    {
        private IPiece[,] board;
        private IPiece piece;

        public Move(IPiece[,] board, IPiece currentMovablePiece)
        {
            this.board = board;
            this.piece = currentMovablePiece;
        }

        internal void ApplyMove(IUserMove move)
        {
            var (firstIndex, secondIndex) = piece.Index;

            board[move.Index.Item1, move.Index.Item2] =
            board[piece.Index.Item1, piece.Index.Item2];
            board[piece.Index.Item1, piece.Index.Item2].UpdateAfterMove(move);
            
            if(board[piece.Index.Item1, piece.Index.Item2] is ICastable)
            {
                var moved = (ICastable)board[piece.Index.Item1, piece.Index.Item2];
                moved.IsMoved = true;
            }

            board[firstIndex, secondIndex] = null;
        }
    }
}
