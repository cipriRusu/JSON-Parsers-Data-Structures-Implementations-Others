using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class ConstraintValidator
    {
        public IChessPiece Piece { get; private set; }
        public IUserMove Move { get; private set; }
        public bool IsValid { get; private set; }

        public ConstraintValidator(IChessPiece piece, IUserMove move)
        {
            Piece = piece;
            Move = move;
            IsValid = AllMoveConstraints(Move, Piece);
        }

        private bool AllMoveConstraints(IUserMove move, IChessPiece x) =>
            RankConstraint(move, x) ||
            FileConstraint(move, x) ||
            FileAndRankConstraint(move, x) ||
            NoConstraint(move);

        private bool NoConstraint(IUserMove move) =>
                move.SourceFile == '\0' &&
                move.SourceRank == '\0';

        private bool FileAndRankConstraint(IUserMove move, IChessPiece x) =>
            move.SourceRank != '\0' &&
            move.SourceFile != '\0' &&
            move.SourceRank == x.Rank &&
            move.SourceFile == x.File;

        private bool FileConstraint(IUserMove move, IChessPiece x) =>
            move.SourceFile != '\0' &&
            move.SourceRank == '\0' &&
            move.SourceFile == x.File;

        private bool RankConstraint(IUserMove move, IChessPiece x) =>
            move.SourceRank != '\0' &&
            move.SourceFile == '\0' &&
            move.SourceRank == x.Rank;

    }
}
