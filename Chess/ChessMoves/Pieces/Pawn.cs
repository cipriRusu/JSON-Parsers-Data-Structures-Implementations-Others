using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    internal class Pawn : Piece, IChessPiece
    {
        public Pawn(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = PieceType.Pawn;

        public override Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.Pawn }, PlayerColour);

        public override Path Captures() => new Path(CurrentPosition, new PathType[] { PathType.PawnCapture}, PlayerColour);
    }
}