using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    public class Bishop : Piece, IChessPiece
    {
        public Bishop(string matrixPosition, Player playerColour) : 
            base(matrixPosition, playerColour) => PieceType = PieceType.Bishop;

        public override IPath Moves() => new Path(this, PathType.Diagonals);
        public override IPath Captures() => Moves();
    }
}