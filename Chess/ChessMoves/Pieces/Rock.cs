using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    internal class Rock : Piece
    {
        public Rock((int, int) currentPosition, Player playerColour) : base(currentPosition, playerColour)
        { base.PieceType = PieceType.Rock; }

        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour)
        {
            PieceType = PieceType.Rock;
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
        }

        public override Path GetLegalMoves() => new Path(CurrentPosition, new PathType[] { PathType.RowsAndColumns });
    }
}