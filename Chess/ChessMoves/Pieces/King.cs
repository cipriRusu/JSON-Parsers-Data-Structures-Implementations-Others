using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace ChessMoves
{
    [Serializable]
    public class King : Piece, IPiece
    {
        public King(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) => PieceType = PieceType.King;

        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.King).GetEnumerator();

        public override IEnumerable<IPath> Captures() => Moves();
    }
}