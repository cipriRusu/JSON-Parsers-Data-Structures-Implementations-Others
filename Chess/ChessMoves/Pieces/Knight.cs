using ChessMoves.Paths;
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

        public bool CanCapture((int, int) target, IBoardState board) => Captures().Any(x => x.End == target);
        public bool CanReach((int, int) destination, IBoardState board) => Moves().Any(x => x.End == destination);

        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.Knight).GetEnumerator();
        public override IEnumerable<IPath> Captures() => Moves();
        public override void PerformMove(IUserMove move, IBoardState chessBoard)
        {
            var validPath = Moves().Where(x => x.End == move.MoveIndex);
            chessBoard.PerformMove(this, move);
        }
    }
}