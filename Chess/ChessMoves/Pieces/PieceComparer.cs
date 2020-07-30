using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace ChessMoves
{
    public class PieceComparer : IEqualityComparer<IChessPiece>
    {
        public bool Equals([AllowNull] IChessPiece x, [AllowNull] IChessPiece y)
        {
            return x.PlayerColour == y.PlayerColour &&
                x.PieceType == y.PieceType &&
                x.CurrentPosition == y.CurrentPosition &&
                x.File == y.File &&
                x.Rank == y.Rank;
        }

        public int GetHashCode([DisallowNull] IChessPiece input)
        {
            return input.GetHashCode();
        }
    }
}
