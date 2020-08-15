using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Paths
{
    public class DiagonalPaths : IEnumerable<IPath>
    {
        private (int, int) StartIndex;
        public DiagonalPaths((int, int) startIndex) => StartIndex = startIndex;
        private IEnumerable<IEnumerable<(int, int)>> AllDiagonals()
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

        public IEnumerator<IPath> GetEnumerator()
        {
            foreach (var diagonal in AllDiagonals())
                yield return new Path(diagonal, StartIndex);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
