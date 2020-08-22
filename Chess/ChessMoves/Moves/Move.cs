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

        public Move(IPiece[,] board) => this.board = board;

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

            if (board[piece.Index.Item1, piece.Index.Item2] is ICastable)
            {
                var moved = (ICastable)board[piece.Index.Item1, piece.Index.Item2];
                moved.IsMoved = true;
            }

            board[firstIndex, secondIndex] = null;
        }

        internal void ApplyKingCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    (board[7, 5], board[7, 7]) = (board[7, 7], board[7, 5]);
                    (board[7, 6], board[7, 4]) = (board[7, 4], board[7, 6]);
                    board[7, 5].UpdateAfterMove(move);
                    board[7, 6].UpdateAfterMove(move);
                    break;

                case Player.Black:
                    (board[0, 5], board[0, 7]) = (board[0, 7], board[0, 5]);
                    (board[0, 6], board[0, 4]) = (board[0, 4], board[0, 6]);
                    board[0, 5].UpdateAfterMove(move);
                    board[0, 6].UpdateAfterMove(move);
                    break;
                default:
                    break;
            }
        }

        internal void ApplyQueenCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    (board[7, 3], board[7, 0]) = (board[7, 0], board[7, 3]);
                    (board[7, 2], board[7, 4]) = (board[7, 4], board[7, 2]);
                    board[7, 3].UpdateAfterMove(move);
                    board[7, 2].UpdateAfterMove(move);
                    break;
                case Player.Black:
                    (board[0, 3], board[0, 0]) = (board[0, 0], board[0, 3]);
                    (board[0, 2], board[0, 4]) = (board[0, 4], board[0, 2]);
                    board[0, 3].UpdateAfterMove(move);
                    board[0, 2].UpdateAfterMove(move);
                    break;
                default:
                    break;
            }
        }
    }
}
