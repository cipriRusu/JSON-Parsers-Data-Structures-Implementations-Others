using ChessGame.Paths;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class Queen : Piece, IPiece
    {
        public Queen(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = typeof(Queen);

        public override IEnumerable<IPath> Moves => new MoveGenerator(this, PathType.RowsAndColumns, PathType.Diagonals).GetEnumerator();
        public override IEnumerable<IPath> Captures => new CaptureGenerator(this, PathType.RowsAndColumns, PathType.Diagonals).GetEnumerator();
    }
}