using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    internal class Knight : Piece, IChessPiece
    {
        public Knight(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) =>
            PieceType = PieceType.Knight;

        public Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.Knight });
        public Path Captures() => Moves();
        public bool CanReach((int, int) destination) => Moves().Any(x => x.Single() == destination);
        public void PerformMove((int, int) targetMove, ChessBoard chessBoard)
        {
            var validPath = Moves().Where(x => x.Last() == targetMove).SelectMany(x => x);

            chessBoard.PerformMove(this, targetMove);
        }
    }
}