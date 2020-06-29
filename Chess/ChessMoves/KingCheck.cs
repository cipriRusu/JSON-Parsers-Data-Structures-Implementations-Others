using System.Collections.Generic;
using System.Linq;

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
            foreach (var move in board[FindKing(board).Item1, FindKing(board).Item2]
                .GetLegalMoves().SelectMany(x => x))
            {
                new List<Piece[,]>().Add(board[FindKing(board).Item1, FindKing(board).Item2].MoveTo(move, board).Clone() as Piece[,]);
            }

            return Check(board) && new List<Piece[,]>().All(x => Check(x) == true);
        }

        private (int, int) FindKing(Piece[,] board) => 
            Enumerable.Range(0, CHESSBOARD_SIZE)
            .Select(x => Enumerable.Range(0, CHESSBOARD_SIZE).Select(y => (x, y)))
            .SelectMany(x => x)
            .Where(x => FindKing(board, player, x.x, x.y))
            .Single();

        private bool Check(Piece[,] board) => IsChecked(FindKing(board), board);

        private static bool FindKing(Piece[,] board, Player player, int i, int j) =>
            board[i, j] != null &&
            board[i, j].PlayerColour == player &&
            board[i, j].PieceType == PieceType.King;

        private bool IsChecked((int, int) startIndex, Piece[,] board)
        {
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

            return player switch
            {
                Player.White when 
                FindAttacks(
                    player, startIndex, board, 
                    new Diagonals(startIndex).AllDiagonals, 
                    new LinesAndColumns(startIndex).AllRowsColumns, 
                    new KnightMoves(startIndex).AllMoves, 
                    diagonalPieces, lineColumnPieces) => true,
                
                Player.Black when 

                FindAttacks(
                    player, startIndex, board, 
                    new Diagonals(startIndex).AllDiagonals, 
                    new LinesAndColumns(startIndex).AllRowsColumns, 
                    new KnightMoves(startIndex).AllMoves, 
                    diagonalPieces, lineColumnPieces) => true,
                _ => false
            };

            bool FindAttacks(
                Player player, (int, int) startIndex, Piece[,] board,
                IEnumerable<IEnumerable<(int, int)>> diagonals, 
                IEnumerable<IEnumerable<(int, int)>> linesColumns, 
                IEnumerable<IEnumerable<(int, int)>> knights, 
                List<PieceType> diagonalPieces, List<PieceType> lineColumnPieces)
            {
                switch (player)
                {
                    case Player.White:
                        {
                            return
                            GetAttacks(player, board, knights, null, true).Count() > 0 ||
                            GetAttacks(player, board, linesColumns, lineColumnPieces, false).Count() > 0 ||
                            GetAttacks(player, board, diagonals, diagonalPieces, false).Count() > 0 ||
                            new PawnAggregate(board, Player.Black).Attacks.Where(x => x == startIndex).Count() > 0;
                        }

                    case Player.Black:
                        {
                            return
                            GetAttacks(player, board, knights, null, true).Count() > 0 ||
                            GetAttacks(player, board, linesColumns, lineColumnPieces, false).Count() > 0 ||
                            GetAttacks(player, board, diagonals, diagonalPieces, false).Count() > 0 ||
                            new PawnAggregate(board, Player.White).Attacks.Where(x => x == startIndex).Count() > 0;
                        }
                }

                return false;
            }

            IEnumerable<IEnumerable<(int, int)>> GetAttacks(
                Player player, Piece[,] board,
                IEnumerable<IEnumerable<(int, int)>> paths,
                List<PieceType> attacks, bool IsKnight)
            {
                if (IsKnight == true)
                {
                    return paths.Where(x =>
                    x.IsOpponentPathClear(player, board, true))
                        .Where(x => board[x.Single().Item1, x.Single().Item2].PieceType == PieceType.Knight);
                }
                else
                {
                    return paths.Where(x =>
                    x.IsOpponentPathClear(player, board, false))
                        .Where(x => attacks.Contains(board[x.Last().Item1, x.Last().Item2].PieceType));
                }
            }
        }
    }
}
