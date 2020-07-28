using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    internal class Pawn : Piece, IChessPiece
    {
        public Pawn(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = PieceType.Pawn;

        public override bool CanCapture((int, int) target) => Captures().Any(x => x.Last() == target);

        public override Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.Pawn }, PlayerColour);

        public override Path Captures() => new Path(CurrentPosition, new PathType[] { PathType.PawnCapture}, PlayerColour);

        public override void PerformCapture((int, int) targetCapture, ChessBoard chessBoard)
        {
            var targetPiece = chessBoard[targetCapture];

            if(Opponent(PlayerColour) == targetPiece.PlayerColour)
            {
                chessBoard.PerformMove(this, targetCapture);
            }
        }
    }
}