using ChessGame;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    public class Rock : Piece, IPiece, IRock, ICastable
    {
        private int BLACKSIDEINDEX = 0;
        private int WHITESIDEINDEX = 7;
        public bool IsKingSide => Index.Item2 >= 4;
        public bool IsMoved { get; set; }

        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) =>
            PieceType = typeof(Rock);
        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.RowsAndColumns).GetEnumerator();
        public override IEnumerable<IPath> Captures() => Moves();

        public bool CanPerformCastling(IBoard board)
        {
            if (IsMoved) return false;

            return false;
        }
    }
}