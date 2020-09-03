using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Paths
{
    public class KnightPath : IEnumerable<IEnumerable<(int, int)>>
    {
        private (int, int) StartIndex;
        public KnightPath((int, int) startIndex) => StartIndex = startIndex;
        private bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);
        private IEnumerable<IEnumerable<(int, int)>> AllKnightPaths()
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

        public IEnumerator<IEnumerable<(int, int)>> GetEnumerator()
        {
            foreach (var path in AllKnightPaths())
            {
                yield return path;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
