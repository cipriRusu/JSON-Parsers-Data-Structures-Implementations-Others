using ChessMoves.Paths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class Pawn : Piece, IPiece
    {
        public Pawn(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = typeof(Pawn);

        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.Pawn).GetEnumerator();
        public override IEnumerable<IPath> Captures() => new PathGenerator(this, PathType.PawnCapture).GetEnumerator();
        public override void PerformCapture(IUserMove move, IBoard chessBoard)
        {
            var targetPiece = chessBoard[move.Index];

            if (Opponent(PlayerColour) == targetPiece.PlayerColour)
            {
                chessBoard.PerformMove(move);
            }
        }
    }
}