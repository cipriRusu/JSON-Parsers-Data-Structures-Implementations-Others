using ChessGame;
using ChessMoves.Moves;
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

        public bool CanCastle(IBoard board)
        {
            if (IsMoved) throw new UserMoveException(null, "Castling cannot be performed due to moved state");

            if(CastlingDirection == CastlingDirection.KingSide)
            {
                var path = new PathGenerator(this, PathType.KingSideCastling).GetEnumerator().Single();
                return board.IsPathClear(path, 1, 1) ? true : throw new UserMoveException(null, "Unclear path!");
            }
            else
            {
                var path = new PathGenerator(this, PathType.QueenSideCastling).GetEnumerator().Single();
                return board.IsPathClear(path, 1, 1) ? true : throw new UserMoveException(null, "Unclear path!");
            }
        }

        public override void UpdateAfterMove(IUserMove move)
        {
            if(move is QueenCastlingUserMove)
            {
                Index = (Index.Item1, Index.Item2 + 3);
            }
            if(move is KingCastlingUserMove)
            {
                Index = (Index.Item1, Index.Item2 - 2);
            }
            else
            {
                base.UpdateAfterMove(move);
            }
        }
    }
}