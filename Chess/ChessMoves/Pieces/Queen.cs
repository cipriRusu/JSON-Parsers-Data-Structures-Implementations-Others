using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class Queen : Piece, IPiece
    {
        public Queen(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = PieceType.Queen;
        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.RowsAndColumns, PathType.Diagonals).GetEnumerator();
        public override IEnumerable<IPath> Captures() => Moves();
    }
}