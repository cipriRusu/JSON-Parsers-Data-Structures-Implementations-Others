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
            switch (move.UserMoveType)
            {
                case UserMoveType.Move:
                    return GetLegalMoves().Where(x => IsLast(x.Last(), move.MoveIndex));

                case UserMoveType.Capture:
                    return GetLegalMoves().Where(x => IsLast(x.Last(), move.MoveIndex) &&
                    IsOpponentColour(board, x.Last()));
                default:
                    throw new ArgumentException("Invalid move type or not yet handled");
            }
        }

        private bool IsOpponentColour(ChessBoard board, (int, int) lastElement) =>
            board[lastElement.Item1, lastElement.Item2].PlayerColour == Opponent(PlayerColour);

        private bool IsLast((int, int) actualLast, (int, int) expectedLast) => actualLast == expectedLast;
        internal virtual bool IsChecked(Player player, ChessBoard chessBoard) => false;
        internal virtual bool IsCheckMated(Player player, ChessBoard chessBoard) => false;

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