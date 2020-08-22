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

        private bool IsMovePathValid(IPath path) => path.Path.Skip(1).All(x => board[x.Item1, x.Item2] == null);

        private bool IsCapturePathValid(IPath path) => path.Path.Skip(1).SkipLast(1)
            .All(x => board[x.Item1, x.Item2] == null) && 
            board[path.End.Item1, path.End.Item2].PlayerColour != move.PlayerColor;

        public bool ValidateKingCastling(IUserMove move)
        {
            new CastingValidator(board).IsValid(move.PlayerColor, true);

            return false;
        }

        internal bool ValidateQueenCastling(IUserMove move)
        {
            new CastingValidator(board).IsValid(move.PlayerColor, false);

            return false;
        }
    }
}
