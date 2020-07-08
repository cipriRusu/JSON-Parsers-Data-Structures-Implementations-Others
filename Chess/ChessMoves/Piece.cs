using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;

namespace ChessMoves
{
    [Serializable]
    public class Piece
    {
        public const int BOARDSIZE = 8;
        public (int, int) CurrentPosition { get; internal set; }
        public Player PlayerColour { get; internal set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public PieceType PieceType { get; internal set; }
        public virtual IEnumerable<IEnumerable<(int, int)>> GetLegalMoves() => null;
        public bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);
        internal Index customIndex = new Index();
        public Piece(string chessBoardIndex, Player playerColour)
        {
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
            File = chessBoardIndex.First();
            Rank = chessBoardIndex.Last();
        }
        public Piece((int, int) pieceIndex, Player playerColour)
        {
            var rankAndFile = new RankAndFile(pieceIndex);
            CurrentPosition = pieceIndex;
            PlayerColour = playerColour;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }
        public void Update((int, int) newPosition)
        {
            var rankAndFile = new RankAndFile(newPosition);
            CurrentPosition = newPosition;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }

        protected virtual IEnumerable<IEnumerable<(int, int)>> ValidatePath(ChessBoard board, UserMove move)
        {
            if (move.UserMoveType == UserMoveType.Move)
            {
                return
                    GetLegalMoves()
                    .Where(
                        x => x.First() == CurrentPosition &&
                             x.Last() == move.MoveIndex);
            }

            if (move.UserMoveType == UserMoveType.Capture)
            {
                if (move.PieceType == PieceType.Pawn)
                {
                    return
                        PawnCapture()
                        .Where(
                            x => x.Single() == move.MoveIndex &&
                            board[x.Single().Item1, x.Single().Item2].PlayerColour ==
                            Opponent(PlayerColour));
                }
                else
                {
                    return
                        GetLegalMoves()
                        .Where(x =>
                            x.First() == CurrentPosition &&
                            x.Last() == move.MoveIndex &&
                            board[x.Last().Item1, x.Last().Item2].PlayerColour ==
                            Opponent(PlayerColour));
                }
            }

            return null;
        }

        internal bool IsCheckMated(Player player, ChessBoard chessBoard)
        {
            var moves = GetLegalMoves().Where(x => chessBoard.IsPathClear(x));

            foreach (var move in moves)
            {
                var current = chessBoard.DeepClone();

                current.PerformMove(CurrentPosition, move.Single());

                if (!current.IsChecked(player))
                {
                    return false;
                }
            }

            return moves.Count() > 0;
        }

        internal bool IsChecked(Player player, ChessBoard chessBoard)
        {
            switch (player)
            {
                case Player.Black:
                    return CheckValidator(Player.White, chessBoard);
                case Player.White:
                    return CheckValidator(Player.Black, chessBoard);
                default:
                    return false;
            }
        }

        public static Player Opponent(Player player)
        {
            switch (player)
            {
                case Player.White:
                    return Player.Black;
                case Player.Black:
                    return Player.White;
                default:
                    throw new ArgumentException("Invalid player");
            }
        }

        private bool CheckValidator(Player opponent, ChessBoard chessBoard)
        {
            var diags = Diagonals()
                .Where(x =>
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                (chessBoard.IsPiece(x.Last(), PieceType.Queen, opponent) ||
                chessBoard.IsPiece(x.Last(), PieceType.Bishop, opponent)));

            var rowsAndColumns = RowsAndColumns()
                .Where(x =>
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                (chessBoard.IsPiece(x.Last(), PieceType.Rock, opponent) ||
                chessBoard.IsPiece(x.Last(), PieceType.Queen, opponent)));

            var knight = new Knight(CurrentPosition, PlayerColour).GetLegalMoves()
                .Where(x => chessBoard.IsPiece(x.Single(), PieceType.Knight, opponent));

            return diags.Any() || rowsAndColumns.Any() || knight.Any();
        }

        protected IEnumerable<IEnumerable<(int, int)>> RowsAndColumns()
        {
            var firstColumn = new List<(int, int)>();
            var firstRow = new List<(int, int)>();
            var secondColumn = new List<(int, int)>();
            var secondRow = new List<(int, int)>();

            for (int i = CurrentPosition.Item1; i >= 0; i--)
            {
                firstColumn.Add((i, CurrentPosition.Item2));
            }

            for (int i = CurrentPosition.Item2; i <= 7; i++)
            {
                firstRow.Add((CurrentPosition.Item1, i));
            }

            for (int i = CurrentPosition.Item1; i <= 7; i++)
            {
                secondColumn.Add((i, CurrentPosition.Item2));
            }

            for (int i = CurrentPosition.Item2; i >= 0; i--)
            {
                secondRow.Add((CurrentPosition.Item1, i));
            }

            var firstSubs = firstColumn.Select((x, y) => firstColumn.Take(y + 1)).Skip(1);
            var firstRowSubs = firstRow.Select((x, y) => firstRow.Take(y + 1)).Skip(1);
            var secondSubs = secondColumn.Select((x, y) => secondColumn.Take(y + 1)).Skip(1);
            var secondColSubs = secondRow.Select((x, y) => secondRow.Take(y + 1)).Skip(1);

            return firstSubs.Concat(firstRowSubs).Concat(secondSubs).Concat(secondColSubs);
        }

        protected IEnumerable<IEnumerable<(int, int)>> Diagonals()
        {
            var firstDiag = new List<(int, int)>();
            var secondDiag = new List<(int, int)>();
            var thirdDiag = new List<(int, int)>();
            var fourthDiag = new List<(int, int)>();

            for (int i = CurrentPosition.Item1, j = CurrentPosition.Item2;
                i >= 0 && j >= 0; i--, j--)
            {
                firstDiag.Add((i, j));
            }

            for (int i = CurrentPosition.Item1, j = CurrentPosition.Item2;
                i >= 0 && j <= 7; i--, j++)
            {
                secondDiag.Add((i, j));
            }

            for (int i = CurrentPosition.Item1, j = CurrentPosition.Item2;
               i <= 7 && j >= 0; i++, j--)
            {
                thirdDiag.Add((i, j));
            }

            for (int i = CurrentPosition.Item1, j = CurrentPosition.Item2;
               i <= 7 && j <= 7; i++, j++)
            {
                fourthDiag.Add((i, j));
            }

            var firstSubArrays = firstDiag.Select((x, y) => firstDiag.Take(y + 1)).Skip(1);
            var secondSubArrays = secondDiag.Select((x, y) => secondDiag.Take(y + 1)).Skip(1);
            var thirdSubArrays = thirdDiag.Select((x, y) => thirdDiag.Take(y + 1)).Skip(1);
            var fourthSubArrays = fourthDiag.Select((x, y) => fourthDiag.Take(y + 1)).Skip(1);

            return firstSubArrays.Concat(secondSubArrays).Concat(thirdSubArrays).Concat(fourthSubArrays);
        }

        protected IEnumerable<IEnumerable<(int, int)>> PawnCapture()
        {
            var captures = new List<IEnumerable<(int, int)>>();

            if (PlayerColour == Player.White)
            {
                if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 1))
                {
                    captures.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 1), 1));
                }
                if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 1))
                {
                    captures.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 1), 1));
                }
            }
            else if (PlayerColour == Player.Black)
            {
                if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 1))
                {
                    captures.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 1), 1));
                }
                if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 1))
                {
                    captures.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 1), 1));
                }
            }

            return captures;
        }

        internal virtual void Move(UserMove move, ChessBoard chessBoard)
        {
            var validPath = ValidatePath(chessBoard, move).SelectMany(x => x);

            if (validPath.Any() && chessBoard.IsPathClear(validPath.Skip(1).SkipLast(1)))
            {
                chessBoard.PerformMove(validPath.First(), validPath.Last());
            }
        }
    }
}