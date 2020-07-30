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

        public bool CanCapture((int, int) target, IBoardState board) => Captures().Any(x => x.Single() == target);
        public bool CanReach((int, int) destination, IBoardState board) => Moves().Any(x => x.Single() == destination);

        public override Path Moves() => new Path(CurrentPosition, new PathType[] { PathType.Knight });
        public override Path Captures() => Moves();
        public override void PerformMove((int, int) targetMove, IBoardState chessBoard)
        {
            var validPath = Moves().Where(x => x.Single() == targetMove).SelectMany(x => x);
            chessBoard.PerformMove(this, targetMove);
        }
    }
}