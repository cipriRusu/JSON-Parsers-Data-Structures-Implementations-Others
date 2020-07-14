using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    internal class Bishop : Piece, IChessPiece
    {
        public Bishop(string matrixPosition, Player playerColour) :
            base(matrixPosition, playerColour)
        { PieceType = PieceType.Bishop; }

        public Bishop((int, int) pieceIndex, Player playerColour) :
            base(pieceIndex, playerColour)
        {
            PieceType = PieceType.Bishop;
            base.CurrentPosition = pieceIndex;
            base.PlayerColour = playerColour;
        }

        public override Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.Diagonals });

        public override Path Captures() => Moves();
    }
}