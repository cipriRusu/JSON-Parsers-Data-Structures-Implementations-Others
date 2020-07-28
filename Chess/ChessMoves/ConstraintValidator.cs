using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class ConstraintValidator
    {
        public Piece Piece { get; private set; }
        public IUserMove Move { get; private set; }

        public ConstraintValidator()
        {

        }

        private bool AllMoveConstraints(IUserMove move, Piece x) =>
            RankConstraint(move, x) ||
            FileConstraint(move, x) ||
            FileAndRankConstraint(move, x) ||
            NoConstraint(move);

        private bool NoConstraint(IUserMove move) =>
                move.SourceFile == '\0' &&
                move.SourceRank == '\0';

        private bool FileAndRankConstraint(IUserMove move, Piece x) =>
            move.SourceRank != '\0' &&
            move.SourceFile != '\0' &&
            move.SourceRank == x.Rank &&
            move.SourceFile == x.File;

        private bool FileConstraint(IUserMove move, Piece x) =>
            move.SourceFile != '\0' &&
            move.SourceRank == '\0' &&
            move.SourceFile == x.File;

        private bool RankConstraint(IUserMove move, Piece x) =>
            move.SourceRank != '\0' &&
            move.SourceFile == '\0' &&
            move.SourceRank == x.Rank;

    }
}
