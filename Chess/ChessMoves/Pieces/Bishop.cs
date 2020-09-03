using ChessGame.Interfaces;
using ChessGame.Paths;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    public class Bishop : Piece, IPiece
    {
        public Bishop(string matrixPosition, Player playerColour) :
            base(matrixPosition, playerColour) => PieceType = typeof(Bishop);

        public override IEnumerable<IPath> Moves => new MoveGenerator(this, PathType.Diagonals).GetEnumerator();
        public override IEnumerable<IPath> Captures => new CaptureGenerator(this, PathType.Diagonals).GetEnumerator();
    }
}