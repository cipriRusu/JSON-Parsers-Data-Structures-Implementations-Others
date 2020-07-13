using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class MoveHandler
    {
        private readonly UserMove move;
        private readonly ChessBoard board;

        public MoveHandler(UserMove move, ChessBoard board)
        {
            this.move = move;
            this.board = board;
        }

        public Piece GetHandledPiece()
        {
            foreach (var i in Enumerable.Range(0, ChessBoard.CHESSBOARD_SIZE))
            {
                foreach (var j in Enumerable.Range(0, ChessBoard.CHESSBOARD_SIZE))
                {
                    if (PieceConstraint(move, i, j) && 
                        (RankConstraint(move, i, j) || 
                        FileConstraint(move, i, j) ||
                        FileAndRankConstraint(move, i, j) ||
                        NoConstraint(move)))
                    {
                        if(board[i, j].IsMoveValid(board, move))
                        {
                            return board[i, j];
                        }

                    }
                }
            }

            return null;
        }

        private bool NoConstraint(UserMove move) =>
            move.SourceFile == '\0' && move.SourceRank == '\0';

        private bool FileConstraint(UserMove move, int i, int j) =>
            move.SourceFile != '\0' && move.SourceRank == '\0' && move.SourceFile == board[i, j].File;

        private bool RankConstraint(UserMove move, int i, int j) =>
            move.SourceRank != '\0' && move.SourceFile == '\0' && move.SourceRank == board[i, j].Rank;

        private bool FileAndRankConstraint(UserMove move, int i, int j) =>
            move.SourceRank != '\0' &&
            move.SourceFile != '\0' &&
            move.SourceRank == board[i, j].Rank &&
            move.SourceFile == board[i, j].File;

        private bool PieceConstraint(UserMove move, int i, int j)
        {
            return
                board[i, j] != null &&
                board[i, j].PlayerColour == move.PlayerColor &&
                board[i, j].PieceType == move.PieceType;
        }
    }
}
