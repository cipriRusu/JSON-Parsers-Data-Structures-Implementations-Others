using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace ChessMoves
{
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

        protected IEnumerable<IEnumerable<(int, int)>> ValidatePath(UserMove move)
        {
            if (move.UserMoveType == UserMoveType.Move)
            {
                if (move.PieceType == PieceType.Knight)
                {
                    return GetLegalMoves()
                    .Where(x => x.Single() == move.MoveIndex);
                }
                else
                {
                    return GetLegalMoves()
                    .Where(x => x.First() == CurrentPosition &&
                                x.Last() == move.MoveIndex);
                }
            }

            if (move.UserMoveType == UserMoveType.Capture)
            {
                if (move.PieceType == PieceType.Knight)
                {
                    return GetLegalMoves()
                    .Where(x => x.Single() == move.MoveIndex);
                }
                else if(move.PieceType == PieceType.Pawn)
                {
                    return PawnCapture()
                    .Where(x => x.Single() == move.MoveIndex);
                }
            }

            return null;
        }

        internal bool IsChecked(ChessBoard chessBoard)
        {
            return false;
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
            var validPath = ValidatePath(move).SelectMany(x => x);

            if (validPath.Any() && chessBoard.IsPathClear(validPath.Skip(1)))
            {
                chessBoard
                    .PerformMove(validPath.First(), validPath.Last());
            }
        }
    }
}