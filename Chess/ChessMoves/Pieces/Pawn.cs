using ChessGame.Interfaces;
using ChessGame.Paths;
using ChessMoves.Paths;
using System.Collections.Generic;

namespace ChessMoves
{
    public class Pawn : Piece, IPiece
    {
        public Pawn(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) =>
            PieceType = typeof(Pawn);
        public override IEnumerable<IPath> Moves => new MoveGenerator(this, PathType.Pawn).GetEnumerator();
        public override IEnumerable<IPath> Captures => new CaptureGenerator(this, PathType.PawnCapture).GetEnumerator();
    }
}