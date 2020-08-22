using ChessGame;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class King : Piece, IPiece, IKing, ICastable
    {
        private int BLACKINDEX = 0;
        private int WHITEINDEX = 7;
        private IBoard Board { get; set; }
        public bool IsMoved { get; set; }
        public CastlingDirection CastlingDirection { get; set; }
        public King(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) => PieceType = typeof(King);

        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.King).GetEnumerator();
        public override IEnumerable<IPath> Captures() => Moves();

        public bool IsChecked(IBoard board)
        {
            this.Board = board;
            var diagonalAttacks =
                ValidAttacks(this, new Type[] { typeof(Queen), typeof(Bishop) }, PathType.Diagonals);

            var verticalHorizontalAttacks =
                ValidAttacks(this, new Type[] { typeof(Queen), typeof(Rock) }, PathType.RowsAndColumns);

            var knightAttacks =
                ValidAttacks(this, new Type[] { typeof(Knight) }, PathType.Knight);

            var pawnAttacks =
                ValidAttacks(this, new Type[] { typeof(Pawn) }, PathType.PawnCapture);

            return diagonalAttacks || verticalHorizontalAttacks || knightAttacks || pawnAttacks;
        }

        public bool IsCheckMate(IBoard board)
        {
            var allClearPaths = Moves().Where(x => board[x.End.Item1, x.End.Item2] == null);

            var allClearMoves = allClearPaths.Select(x => new King(new RankAndFile(x.End).GetRankAndFile, PlayerColour));

            var hasUnattackedMoves = allClearMoves.Any(x => !x.IsChecked(board));

            return IsChecked(board) && !hasUnattackedMoves;
        }

        private bool ValidAttacks(IPiece piece, Type[] attackers, params PathType[] pathTypes)
        {
            return new PathGenerator(piece, pathTypes).GetEnumerator()
            .Where(x => Board[x.End.Item1, x.End.Item2] != null)
            .Where(x => Board.IsPathClear(x, 1, 1))
            .Where(x => Board[x.End.Item1, x.End.Item2].PlayerColour != piece.PlayerColour)
            .Where(x => attackers.Contains(Board[x.End.Item1, x.End.Item2].GetType())).Any();
        }

        public bool CanCastle(IBoard board)
        {
            if (IsMoved) throw new UserMoveException(null, "Castling cannot be performed due to moved state of Piece");

            var allMoves = CastlingPath().Select(x => new King(new RankAndFile(x).GetRankAndFile, PlayerColour));

            return !allMoves.Any(x => x.IsChecked(board)) ? true : throw new UserMoveException(null, "Cannot cast through Check!");
        }

        private IEnumerable<(int, int)> CastlingPath()
        {
            int boardSize = 8;
            var fullPath = Enumerable.Empty<(int, int)>();
            var rowIndex = Enumerable.Empty<int>();
            var columnIndex = Enumerable.Range(0, boardSize);

            switch (PlayerColour)
            {
                case Player.White:
                    rowIndex = Enumerable.Repeat(WHITEINDEX, boardSize);
                    break;
                case Player.Black:
                    rowIndex = Enumerable.Repeat(BLACKINDEX, boardSize);
                    break;
            }

            fullPath = rowIndex.Zip(columnIndex);

            return CastlingDirection == CastlingDirection.KingSide
                ? fullPath.SkipWhile(x => x != Index).Skip(1).Take(2)
                : fullPath.TakeWhile(x => x != Index).Reverse().Take(2);
        }
        public override void UpdateAfterMove(IUserMove move)
        {
            if (move is QueenCastlingUserMove)
            {
                Index = (Index.Item1, Index.Item2 - 2);
            }
            if (move is KingCastlingUserMove)
            {
                Index = (Index.Item1, Index.Item2 + 2);
            }
            else
            {
                base.UpdateAfterMove(move);
            }
        }
    }
}