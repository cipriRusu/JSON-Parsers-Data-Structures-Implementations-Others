using ChessGame;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    public class Rock : Piece, IPiece
    {
        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) =>
            PieceType = typeof(Rock);

        public override IEnumerable<IPath> Moves => new PathGenerator(this, PathType.RowsAndColumns).GetEnumerator();
        public override IEnumerable<IPath> Captures => Moves;
    }
}