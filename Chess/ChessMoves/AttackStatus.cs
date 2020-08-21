using ChessMoves.Moves;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ChessMoves
{
    public class AttackStatus
    {
        private IPiece chessPiece { get => GetKing(); }
        private Player player;
        private IBoard board;

        public bool IsAttacked => IsCurrentAttacked();
        public bool IsCheckMated => IsCurrentCheckMate();

        public AttackStatus(IBoard board, Player player)
        {
            this.board = board;
            this.player = player;
        }

        private bool IsCurrentCheckMate()
        {
            var origin = new MoveUserMove($"K{new RankAndFile(chessPiece.Index).GetRankAndFile}", player);

            var clearPaths = chessPiece.Moves().Where(x => board[x.End.Item1, x.End.Item2] == null);

            var legalMoves = clearPaths.Select(x => new MoveUserMove($"K{new RankAndFile(x.End).GetRankAndFile}", player));

            foreach (var move in legalMoves)
            {
                board.Perform(move);

                if (!new AttackStatus(board, player).IsAttacked)
                {
                    return false;
                }
            }

            board.Perform(origin);

            return legalMoves.Count() > 0;
        }

        private bool IsCurrentAttacked()
        {
            var diagonalAttacks =
                ValidAttacks(chessPiece, new Type[] { typeof(Queen), typeof(Bishop) }, PathType.Diagonals);

            var verticalHorizontalAttacks =
                ValidAttacks(chessPiece, new Type[] { typeof(Queen), typeof(Rock) }, PathType.RowsAndColumns);

            var knightAttacks =
                ValidAttacks(chessPiece, new Type[] { typeof(Knight) }, PathType.Knight);

            var pawnAttacks =
                ValidAttacks(chessPiece, new Type[] { typeof(Pawn) }, PathType.PawnCapture);

            return diagonalAttacks || verticalHorizontalAttacks || knightAttacks || pawnAttacks;
        }

        private bool ValidAttacks(IPiece piece, Type[] attackers, params PathType[] pathTypes)
        {
            return new PathGenerator(piece, pathTypes).GetEnumerator()
            .Where(x => board[x.End.Item1, x.End.Item2] != null)
            .Where(x => board.IsPathClear(x))
            .Where(x => board[x.End.Item1, x.End.Item2].PlayerColour != piece.PlayerColour)
            .Where(x => attackers.Contains(board[x.End.Item1, x.End.Item2].GetType())).Any();
        }

        private IPiece GetKing() => Enumerable.Range(0, 8)
                .Select(x => Enumerable.Range(0, 8).Select(y => board[x, y]))
                .SelectMany(x => x)
                .Where(x => x != null)
                .Where(x => x.PlayerColour == player)
                .Where(x => x.GetType() == typeof(King))
                .Single();
    }
}
