using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class Queen : Piece, IChessPiece
    {
        public Queen(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = PieceType.Queen;

        public override IPath Moves() => new Path(this, PathType.RowsAndColumns, PathType.Diagonals);

        public override IPath Captures() => Moves();
    }
}