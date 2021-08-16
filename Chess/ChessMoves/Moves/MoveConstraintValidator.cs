using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class MoveConstraintValidator
    {
        public IPiece Piece { get; private set; }
        public IUserMove Move { get; private set; }
        public bool IsValid { get; private set; }

        public MoveConstraintValidator(IPiece piece, IUserMove move)
        {
            Piece = piece;
            Move = move;
            IsValid = AllMoveConstraints(Move, Piece);
        }

        private bool AllMoveConstraints(IUserMove move, IPiece x) =>
            RankConstraint(move, x) ||
            FileConstraint(move, x) ||
            FileAndRankConstraint(move, x) ||
            NoConstraint(move);

        private bool NoConstraint(IUserMove move) =>
                move.File == '\0' &&
                move.Rank == '\0';

        private bool FileAndRankConstraint(IUserMove move, IPiece x) =>
            move.Rank != '\0' &&
            move.File != '\0' &&
            move.Rank == x.Rank &&
            move.File == x.File;

        private bool FileConstraint(IUserMove move, IPiece x) =>
            move.File != '\0' &&
            move.Rank == '\0' &&
            move.File == x.File;

        private bool RankConstraint(IUserMove move, IPiece x) =>
            move.Rank != '\0' &&
            move.File == '\0' &&
            move.Rank == x.Rank;

    }
}
