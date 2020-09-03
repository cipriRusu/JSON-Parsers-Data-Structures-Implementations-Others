using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Paths
{
    public class KingPaths : IEnumerable<IEnumerable<(int, int)>>
    {
        private (int, int) StartIndex;
        public KingPaths((int, int) startIndex) => StartIndex = startIndex;
        private bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);

        private IEnumerable<IEnumerable<(int, int)>> AllKingPaths()
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
            foreach(var path in AllKingPaths())
            {
                yield return path;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
