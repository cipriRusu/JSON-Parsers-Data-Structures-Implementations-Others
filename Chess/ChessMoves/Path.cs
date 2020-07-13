using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class Path : IEnumerable<IEnumerable<(int, int)>>
    {
        public Path((int, int) startIndex, IEnumerable<PathType> paths, Player player = Player.White)
        {
            this.StartIndex = startIndex;
            this.paths = paths;
            this.PlayerColour = player;
        }
        public (int, int) StartIndex { get; private set; }
        public Player PlayerColour { get; set; }
        public IEnumerable<PathType> paths { get; private set; }

        private bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);

        private IEnumerable<IEnumerable<(int, int)>> RownColumnPaths()
        {
            var firstColumn = new List<(int, int)>();
            var firstRow = new List<(int, int)>();
            var secondColumn = new List<(int, int)>();
            var secondRow = new List<(int, int)>();

            for (int i = StartIndex.Item1; i >= 0; i--)
            {
                firstColumn.Add((i, StartIndex.Item2));
            }

            for (int i = StartIndex.Item2; i <= 8 - 1; i++)
            {
                firstRow.Add((StartIndex.Item1, i));
            }

            for (int i = StartIndex.Item1; i <= 8 - 1; i++)
            {
                secondColumn.Add((i, StartIndex.Item2));
            }

            for (int i = StartIndex.Item2; i >= 0; i--)
            {
                secondRow.Add((StartIndex.Item1, i));
            }

            var firstSubs = firstColumn.Select((x, y) => firstColumn.Take(y + 1)).Skip(1);
            var firstRowSubs = firstRow.Select((x, y) => firstRow.Take(y + 1)).Skip(1);
            var secondSubs = secondColumn.Select((x, y) => secondColumn.Take(y + 1)).Skip(1);
            var secondColSubs = secondRow.Select((x, y) => secondRow.Take(y + 1)).Skip(1);

            return firstSubs.Concat(firstRowSubs).Concat(secondSubs).Concat(secondColSubs);
        }

        private IEnumerable<IEnumerable<(int, int)>> DiagonalPaths()
        {
            var firstDiag = new List<(int, int)>();
            var secondDiag = new List<(int, int)>();
            var thirdDiag = new List<(int, int)>();
            var fourthDiag = new List<(int, int)>();

            for (int i = StartIndex.Item1, j = StartIndex.Item2;
                i >= 0 && j >= 0; i--, j--)
            {
                firstDiag.Add((i, j));
            }

            for (int i = StartIndex.Item1, j = StartIndex.Item2;
                i >= 0 && j <= 7; i--, j++)
            {
                secondDiag.Add((i, j));
            }

            for (int i = StartIndex.Item1, j = StartIndex.Item2;
               i <= 7 && j >= 0; i++, j--)
            {
                thirdDiag.Add((i, j));
            }

            for (int i = StartIndex.Item1, j = StartIndex.Item2;
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

        private IEnumerable<IEnumerable<(int, int)>> KnightPaths()
        {
            var legalMoves = new List<IEnumerable<(int, int)>>();

            if (CheckIndexes(StartIndex.Item1 - 2, StartIndex.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 - 2, StartIndex.Item2 + 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2 + 2))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 - 1, StartIndex.Item2 + 2), 1));
            }
            if (CheckIndexes(StartIndex.Item1 - 2, StartIndex.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 - 2, StartIndex.Item2 - 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2 - 2))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 - 1, StartIndex.Item2 - 2), 1));
            }
            if (CheckIndexes(StartIndex.Item1 + 2, StartIndex.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 + 2, StartIndex.Item2 + 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2 + 2))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 + 1, StartIndex.Item2 + 2), 1));
            }
            if (CheckIndexes(StartIndex.Item1 + 2, StartIndex.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 + 2, StartIndex.Item2 - 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2 - 2))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 + 1, StartIndex.Item2 - 2), 1));
            }

            return legalMoves;
        }

        private IEnumerable<IEnumerable<(int, int)>> PawnPaths()
        {
            const int BLACKSTARTPOSITION = 1;
            const int WHITESTARTPOSITION = 6;

            var paths = new List<(int, int)>();

            if (PlayerColour == Player.Black)
            {
                if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2))
                {
                    for (int i = StartIndex.Item1; i <= StartIndex.Item1 + 1; i++)
                    {
                        paths.Add((i, StartIndex.Item2));
                    }

                    if (StartIndex.Item1 == BLACKSTARTPOSITION)
                    {
                        paths.Add((paths.Last().Item1 + 1, paths.Last().Item2));
                    }
                }
            }
            else if (PlayerColour == Player.White)
            {
                if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2))
                {
                    for (int i = StartIndex.Item1; i >= StartIndex.Item1 - 1; i--)
                    {
                        paths.Add((i, StartIndex.Item2));
                    }

                    if (StartIndex.Item1 == WHITESTARTPOSITION)
                    {
                        paths.Add((paths.Last().Item1 - 1, paths.Last().Item2));
                    }
                }
            }

            return paths.Select((x, y) => paths.Take(y + 1)).Skip(1);
        }

        private IEnumerable<IEnumerable<(int, int)>> KingPaths()
        {
            var legalMoves = new List<IEnumerable<(int, int)>>();

            if (CheckIndexes(StartIndex.Item1, StartIndex.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1, StartIndex.Item2 + 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 - 1, StartIndex.Item2 + 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 - 1, StartIndex.Item2), 1));
            }
            if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 - 1, StartIndex.Item2 - 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1, StartIndex.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1, StartIndex.Item2 - 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 + 1, StartIndex.Item2 - 1), 1));
            }
            if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 + 1, StartIndex.Item2), 1));
            }
            if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((StartIndex.Item1 + 1, StartIndex.Item2 + 1), 1));
            }

            return legalMoves;
        }

        public IEnumerator<IEnumerable<(int, int)>> GetEnumerator()
        {
            foreach(var path in paths)
            {
                switch (path)
                {
                    case PathType.RowsAndColumns:

                        foreach(var currentPath in RownColumnPaths())
                        {
                            yield return currentPath;
                        }
                        break;

                    case PathType.Diagonals:

                        foreach (var currentPath in DiagonalPaths())
                        {
                            yield return currentPath;
                        }
                        break;

                    case PathType.Knight:

                        foreach (var currentPath in KnightPaths())
                        {
                            yield return currentPath;
                        }
                        break;

                    case PathType.King:

                        foreach (var currentPath in KingPaths())
                        {
                            yield return currentPath;
                        }
                        break;

                    case PathType.Pawn:
                        foreach (var currentPath in PawnPaths())
                        {
                            yield return currentPath;
                        }
                        break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}