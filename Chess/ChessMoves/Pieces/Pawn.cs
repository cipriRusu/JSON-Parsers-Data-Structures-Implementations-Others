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

        public Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.Pawn }, PlayerColour);

        public Path Captures() => new Path(CurrentPosition, new PathType[] { PathType.PawnCapture}, PlayerColour);

        public bool CanReach((int, int) destination) => Moves().Any(x => x.Last() == destination);

        public void PerformMove((int, int) targetMove, ChessBoard chessBoard) 
        {
            var validPath = Moves().Where(x => x.Last() == targetMove).SelectMany(x => x);

            if(chessBoard.IsPathClear(validPath.Skip(1)))
            {
                chessBoard.PerformMove(this, targetMove);
            }
        }
    }
}