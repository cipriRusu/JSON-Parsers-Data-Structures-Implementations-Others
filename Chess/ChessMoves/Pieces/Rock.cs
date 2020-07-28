using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    internal class Rock : Piece, IChessPiece
    {
        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = PieceType.Rock;

        public Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.RowsAndColumns });

        public Path Captures() => Moves();
    }
}