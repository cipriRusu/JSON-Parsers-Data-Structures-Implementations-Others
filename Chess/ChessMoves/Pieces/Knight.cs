using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    public class Knight : Piece, IChessPiece
    {
        public Knight(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) =>
            PieceType = PieceType.Knight;

        public bool CanCapture((int, int) target, IBoardState board) => Captures().Any(x => x.Single() == target);
        public bool CanReach((int, int) destination, IBoardState board) => Moves().Any(x => x.Single() == destination);

        public override IPath Moves() => new Path(this, PathType.Knight);
        public override IPath Captures() => Moves();
        public override void PerformMove(IUserMove move, IBoardState chessBoard)
        {
            var validPath = Moves().Where(x => x.Single() == move.MoveIndex).SelectMany(x => x);
            chessBoard.PerformMove(this, move);
        }
    }
}