using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    internal class Queen : Piece, IChessPiece
    {
        public Queen(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = PieceType.Queen;

        public Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.RowsAndColumns, PathType.Diagonals });

        public Path Captures() => Moves();
    }
}