using ChessGame.Paths;
using ChessMoves.Paths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    internal class RownColumnPaths : IEnumerable<IEnumerable<(int, int)>>
    {
        private (int, int) StartIndex;
        public RownColumnPaths((int, int) startIndex) => StartIndex = startIndex;

        private IEnumerable<IEnumerable<(int, int)>> AllRownColumnPaths()
        {
            var firstColumn = EnumerableExtensions.CountDown(StartIndex.Item1, 0)
                .Select(x => (x, StartIndex.Item2)).ToList();

            var firstRow = EnumerableExtensions.CountUp(StartIndex.Item2, 7)
                .Select(x => (StartIndex.Item1, x)).ToList();

            var secondColumn = EnumerableExtensions.CountUp(StartIndex.Item1, 7)
                .Select(x => (x, StartIndex.Item2)).ToList();

            var secondRow = EnumerableExtensions.CountDown(StartIndex.Item2, 0)
                .Select(x => (StartIndex.Item1, x)).ToList();

            var firstSubs = firstColumn.Select((x, y) => firstColumn.Take(y + 1)).Skip(1);
            var firstRowSubs = firstRow.Select((x, y) => firstRow.Take(y + 1)).Skip(1);
            var secondSubs = secondColumn.Select((x, y) => secondColumn.Take(y + 1)).Skip(1);
            var secondColSubs = secondRow.Select((x, y) => secondRow.Take(y + 1)).Skip(1);

            return firstSubs.Concat(firstRowSubs).Concat(secondSubs).Concat(secondColSubs);
        }

        public IEnumerator<IEnumerable<(int, int)>> GetEnumerator()
        {
            foreach (var path in AllRownColumnPaths())
            {
                yield return path;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}