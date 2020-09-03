using ChessGame;
using ChessGame.Paths;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class King : Piece, IPiece
    {
        public King(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) => PieceType = typeof(King);

        public override IEnumerable<IPath> Moves => new MoveGenerator(this, PathType.King).GetEnumerator();
        public override IEnumerable<IPath> Captures => new CaptureGenerator(this, PathType.King).GetEnumerator();
    }
}