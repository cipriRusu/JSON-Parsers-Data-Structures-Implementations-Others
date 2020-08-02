using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace ChessMoves
{
    [Serializable]
    internal class King : Piece, IChessPiece
    {
        public King(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) => PieceType = PieceType.King;

        public override Path Moves() => new Path(this, new PathType[] { PathType.King });

        public override Path Captures() => Moves();
    }
}