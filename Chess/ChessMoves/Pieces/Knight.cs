using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    public class Knight : Piece, IPiece
    {
        public Knight(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) =>
            PieceType = typeof(Knight);

        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.Knight).GetEnumerator();
        public override IEnumerable<IPath> Captures() => Moves();
    }
}