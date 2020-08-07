using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    public class Rock : Piece, IChessPiece
    {
        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = PieceType.Rock;

        public override IPath Moves() => new Path(this, PathType.RowsAndColumns);

        public override IPath Captures() => Moves();
    }
}