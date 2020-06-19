using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ChessMoves
{
    internal class UserMoveComparer : IEqualityComparer<UserMove>
    {
        public bool Equals([AllowNull] UserMove x, [AllowNull] UserMove y)
        {
            return
                x.PlayerColor == y.PlayerColor &&
                x.PieceType == y.PieceType &&
                x.MoveIndex.Item1.Equals(y.MoveIndex.Item1)
                .Equals(x.MoveIndex.Item2.Equals(y.MoveIndex.Item2));
        }

        public int GetHashCode([DisallowNull] UserMove input)
        {
            return input.GetHashCode();
        }
    }
}