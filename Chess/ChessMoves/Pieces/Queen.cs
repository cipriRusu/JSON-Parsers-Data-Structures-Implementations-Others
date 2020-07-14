using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    internal class Queen : Piece
    {
        public Queen((int, int) currentPosition, Player playerColour) :
            base(currentPosition, playerColour)
        { base.PieceType = PieceType.Queen; }

        public Queen(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour)
        {
            base.PieceType = PieceType.Queen;
            base.CurrentPosition = base.customIndex.GetMatrixIndex(chessBoardIndex);
            base.PlayerColour = playerColour;
        }

        public override Path GetLegalMoves() => 
            new Path(CurrentPosition, new PathType[] { PathType.RowsAndColumns, PathType.Diagonals });
    }
}