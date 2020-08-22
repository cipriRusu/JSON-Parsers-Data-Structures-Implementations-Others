using ChessMoves;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public class MoveValidator
    {
        private IBoard board;
        private IUserMove move;

        public MoveValidator(IBoard board, IUserMove move)
        {
            this.board = board;
            this.move = move;
        }

        internal bool ValidatePath(IPath path)
        {
            switch (move)
            {
                case MoveUserMove _:
                    return IsMovePathValid(path);
                case CaptureUserMove _:
                    return IsCapturePathValid(path);
                default:
                    return false;
            }
        }
        public bool ValidateKingCastling(IUserMove move) => new CastingValidator(board).IsValid(move.PlayerColor, true);
        public bool ValidateQueenCastling(IUserMove move) => new CastingValidator(board).IsValid(move.PlayerColor, false);
        private bool IsMovePathValid(IPath path) => board.IsPathClear(path, 1, 0);
        private bool IsCapturePathValid(IPath path) => board.IsPathClear(path, 1, 1)
            && board[path.End.Item1, path.End.Item2].PlayerColour != move.PlayerColor;
    }
}
