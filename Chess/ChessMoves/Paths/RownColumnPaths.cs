using ChessMoves.Paths;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    internal class RownColumnPaths : IEnumerable<IPath>
    {
        private (int, int) StartIndex;
        public RownColumnPaths((int, int) startIndex) => StartIndex = startIndex;

        private IEnumerable<IEnumerable<(int, int)>> AllRownColumnPaths()
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

        public IEnumerator<IPath> GetEnumerator()
        {
            foreach (var path in AllRownColumnPaths())
                yield return new Path(path, StartIndex);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}