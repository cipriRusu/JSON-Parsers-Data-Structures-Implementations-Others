using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    internal class Knight : Piece
    {
        public Knight((int, int) currentPosition, Player playerColour) :
            base(currentPosition, playerColour)
        { base.PieceType = PieceType.Knight; }

        public Knight(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour)
        {
            base.PieceType = PieceType.Knight;
            base.CurrentPosition = base.customIndex.GetMatrixIndex(chessBoardIndex);
            base.PlayerColour = playerColour;
        }

        public override Path GetLegalMoves() => new Path(CurrentPosition, new PathType[] { PathType.Knight });
    }
}