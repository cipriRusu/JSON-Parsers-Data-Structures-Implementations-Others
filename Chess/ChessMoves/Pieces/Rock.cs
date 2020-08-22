using ChessGame;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    public class Rock : Piece, IPiece, IRock, ICastable
    {
        public bool IsKingSide => Index.Item2 >= 4;
        public bool IsMoved { get; set; }
        public CastlingDirection CastlingDirection 
        {
            get => IsKingSide ? CastlingDirection.KingSide : CastlingDirection.QueenSide;
            set => CastlingDirection = value;
        }

        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) =>
            PieceType = typeof(Rock);
        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.RowsAndColumns).GetEnumerator();
        public override IEnumerable<IPath> Captures() => Moves();

        public bool CanPerformCastling(IBoard board)
        {
            if (IsMoved) return false;

            if(CastlingDirection == CastlingDirection.KingSide)
            {
                var path = new PathGenerator(this, PathType.KingCastling).GetEnumerator().Single();
                return board.IsPathClear(path);
            }
            else
            {
                var path = new PathGenerator(this, PathType.QueenCastling).GetEnumerator().Single();
                return board.IsPathClear(path);
            }
        }
    }
}