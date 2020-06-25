using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace ChessMoves
{
    public class PieceComparer : IEqualityComparer<Piece>
    {
        public bool Equals([AllowNull] Piece x, [AllowNull] Piece y)
        {
            return x.PlayerColour == y.PlayerColour &&
                x.PieceType == y.PieceType &&
                x.CurrentPosition == y.CurrentPosition &&
                x.File == y.File &&
                x.Rank == y.Rank;
        }

        public int GetHashCode([DisallowNull] Piece input)
        {
            return input.GetHashCode();
        }
    }
}
