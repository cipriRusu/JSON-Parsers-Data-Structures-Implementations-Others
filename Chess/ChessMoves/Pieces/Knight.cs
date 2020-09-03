using ChessGame.Paths;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    public class Knight : Piece, IPiece
    {
        public Knight(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) =>
            PieceType = typeof(Knight);

        public override IEnumerable<IPath> Moves => new MoveGenerator(this, PathType.Knight).GetEnumerator();
        public override IEnumerable<IPath> Captures => new CaptureGenerator(this, PathType.Knight).GetEnumerator();
    }
}