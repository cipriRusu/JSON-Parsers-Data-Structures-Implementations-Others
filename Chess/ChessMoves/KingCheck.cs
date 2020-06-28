using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ChessMoves
{
    public class KingCheck
    {
        private Piece[,] board;
        private Player player;

        public KingCheck(Piece[,] board, Player player)
        {
            this.board = board;
            this.player = player;
        }

        public bool IsCheckMate => CheckMate(board);
        public bool IsCheck => Check(board);

        public int CHESSBOARD_SIZE { get; private set; } = 8;

        private bool CheckMate(Piece[,] board)
        {
            var king = FindKing(board);

            var allMoves = board[king.Item1, king.Item2].GetLegalMoves().SelectMany(x => x);

            var moves = new List<Piece[,]>();

            foreach(var move in allMoves)
            {
                var newBoard = board;
                moves.Add(newBoard[FindKing(newBoard).Item1, FindKing(newBoard).Item2].MoveTo(move, newBoard).Clone() as Piece[,]);
            }

            return Check(board) && moves.All(x => Check(x) == true);
        }

        private (int, int) FindKing(Piece[,] board) => Enumerable.Range(0, CHESSBOARD_SIZE)
                   .Select(x => Enumerable.Range(0, CHESSBOARD_SIZE).Select(y => (x, y)))
                       .SelectMany(x => x).Where(x => FindKing(board, player, x.x, x.y)).Single();

        private bool Check(Piece[,] board) => IsChecked(FindKing(board), board);

        private static bool FindKing(Piece[,] board, Player player, int i, int j) =>
            board[i, j] != null &&
            board[i, j].PlayerColour == player &&
            board[i, j].PieceType == PieceType.King;

        private bool IsChecked((int, int) res, Piece[,] board)
        {
            var diagonals = new Diagonals(res).AllDiagonals;
            var linesColumns = new LinesAndColumns(res).AllRowsColumns;
            var knights = new KnightMoves(res).AllMoves;

            var diagonalPieces = new List<PieceType>
            {
                PieceType.Bishop,
                PieceType.Queen
            };

            var lineColumnPieces = new List<PieceType>
            {
                PieceType.Rock,
                PieceType.Queen,
            };


            if (player == Player.White)
            {
                var diagonalAttacks = diagonals.Where(x =>
                x.IsOpponentPathClear(player, board, false))
                    .Where(x => diagonalPieces.Contains(board[x.Last().Item1, x.Last().Item2].PieceType));

                var verticalHorizontalAttacks = linesColumns.Where(x =>
                x.IsOpponentPathClear(player, board, false))
                    .Where(x => lineColumnPieces.Contains(board[x.Last().Item1, x.Last().Item2].PieceType));

                var knightsAttacks = knights.Where(x =>
                x.IsOpponentPathClear(player, board, true))
                    .Where(x => board[x.Single().Item1, x.Single().Item2].PieceType == PieceType.Knight);

                var pawnAttacks = new PawnAggregate(board, Player.Black).Attacks
                    .Where(x => x == res);

                if (knightsAttacks.Count() > 0 || verticalHorizontalAttacks.Count() > 0 || diagonalAttacks.Count() > 0 || pawnAttacks.Count() > 0)
                {
                    return true;
                }
            }

            if (player == Player.Black)
            {
                var diagonalAttacks = diagonals.Where(x =>
                x.IsOpponentPathClear(player, board, false))
                    .Where(x => diagonalPieces.Contains(board[x.Last().Item1, x.Last().Item2].PieceType));

                var verticalHorizontalAttacks = linesColumns.Where(x =>
                x.IsOpponentPathClear(player, board, false))
                    .Where(x => lineColumnPieces.Contains(board[x.Last().Item1, x.Last().Item2].PieceType));

                var knightsAttacks = knights.Where(x =>
                x.IsOpponentPathClear(player, board, true))
                    .Where(x => board[x.Single().Item1, x.Single().Item2].PieceType == PieceType.Knight);

                var pawnAttacks = new PawnAggregate(board, Player.White).Attacks
                    .Where(x => x == res);

                if (knightsAttacks.Count() > 0 || verticalHorizontalAttacks.Count() > 0 || diagonalAttacks.Count() > 0 || pawnAttacks.Count() > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
