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

        public override IPath Moves() => new Path(CurrentPosition, new PathType[] { PathType.Pawn }, PlayerColour);

        public override IPath Captures() => new Path(CurrentPosition, new PathType[] { PathType.PawnCapture}, PlayerColour);

        public override void PerformCapture(IUserMove move, IBoardState chessBoard)
        {
            var targetPiece = chessBoard[move.MoveIndex];

            if(Opponent(PlayerColour) == targetPiece.PlayerColour)
            {
                chessBoard.PerformMove(this, move);
            }
        }
    }
}