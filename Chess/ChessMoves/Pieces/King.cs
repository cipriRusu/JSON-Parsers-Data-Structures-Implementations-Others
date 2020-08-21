using ChessGame;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    public class King : Piece, IPiece, IKing
    {
        private IBoard board { get; set; }

        public King(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) => PieceType = typeof(King);

        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.King).GetEnumerator();

        public override IEnumerable<IPath> Captures() => Moves();

        public bool IsChecked(IBoard board)
        {
            this.board = board;
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
            var origin = new MoveUserMove($"K{new RankAndFile(Index).GetRankAndFile}", PlayerColour);

            var clearPaths = Moves().Where(x => board[x.End.Item1, x.End.Item2] == null);

            var legalMoves = clearPaths.Select(x => new MoveUserMove($"K{new RankAndFile(x.End).GetRankAndFile}", PlayerColour));

            foreach (var move in legalMoves)
            {
                board.Perform(move);

                if (!IsChecked(board)) { return false; }

                board.Perform(origin);
            }

            return legalMoves.Count() > 0;
        }

        private bool ValidAttacks(IPiece piece, Type[] attackers, params PathType[] pathTypes)
        {
            return new PathGenerator(piece, pathTypes).GetEnumerator()
            .Where(x => board[x.End.Item1, x.End.Item2] != null)
            .Where(x => board.IsPathClear(x))
            .Where(x => board[x.End.Item1, x.End.Item2].PlayerColour != piece.PlayerColour)
            .Where(x => attackers.Contains(board[x.End.Item1, x.End.Item2].GetType())).Any();
        }
    }
}