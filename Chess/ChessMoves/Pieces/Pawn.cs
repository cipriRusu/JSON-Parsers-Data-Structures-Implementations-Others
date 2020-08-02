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

        public override Path Moves() => new Path(this, new PathType[] { PathType.Pawn }, PlayerColour);

        public override Path Captures() => new Path(this, new PathType[] { PathType.PawnCapture}, PlayerColour);

        public override void PerformCapture((int, int) targetCapture, IBoardState chessBoard)
        {
            var targetPiece = chessBoard[targetCapture];

            if(Opponent(PlayerColour) == targetPiece.PlayerColour)
            {
                chessBoard.PerformMove(this, targetCapture);
            }
        }
    }
}