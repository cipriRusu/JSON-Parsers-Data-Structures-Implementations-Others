using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace ChessMoves
{
    public class PieceComparer : IEqualityComparer<IPiece>
    {
        public bool Equals([AllowNull] IPiece x, [AllowNull] IPiece y)
        {
            return x.Player == y.Player &&
                x.GetType() == y.GetType() &&
                x.Index == y.Index &&
                x.File == y.File &&
                x.Rank == y.Rank;
        }

        public int GetHashCode([DisallowNull] IPiece input)
        {
            return input.GetHashCode();
        }
    }
}
