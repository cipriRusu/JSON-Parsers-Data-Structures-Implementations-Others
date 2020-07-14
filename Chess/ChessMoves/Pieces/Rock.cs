using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    internal class Rock : Piece, IChessPiece
    {
        public Rock((int, int) currentPosition, Player playerColour) : base(currentPosition, playerColour)
        { base.PieceType = PieceType.Rock; }

        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour)
        {
            PieceType = PieceType.Rock;
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
        }

        public override Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.RowsAndColumns });

        public override Path Captures() => Moves();
    }
}