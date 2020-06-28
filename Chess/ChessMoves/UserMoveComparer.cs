using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ChessMoves
{
    internal class UserMoveComparer : IEqualityComparer<UserMove>
    {
        public bool Equals([AllowNull] UserMove x, [AllowNull] UserMove y)
        {
            return
                x.SourceFile == y.SourceFile &&
                x.SourceRank == y.SourceRank &&
                x.PlayerColor == y.PlayerColor &&
                x.PieceType == y.PieceType &&
                x.UserMoveType == y.UserMoveType &&
                x.MoveIndex.Item1.Equals(y.MoveIndex.Item1) && x.MoveIndex.Item2.Equals(y.MoveIndex.Item2);
        }

        public int GetHashCode([DisallowNull] UserMove input)
        {
            return input.GetHashCode();
        }
    }
}