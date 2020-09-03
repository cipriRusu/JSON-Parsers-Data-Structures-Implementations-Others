using ChessGame.Paths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Paths
{
    public class DiagonalPaths : IEnumerable<IEnumerable<(int, int)>>
    {
        private (int, int) StartIndex;
        public DiagonalPaths((int, int) startIndex) => StartIndex = startIndex;

        private IEnumerable<IEnumerable<(int, int)>> AllDiagonals()
        {
            var firstDiag = EnumerableExtensions.CountDown(StartIndex.Item1, 0)
                .Zip(EnumerableExtensions.CountDown(StartIndex.Item2, 0)).ToList();

            var secondDiag = EnumerableExtensions.CountDown(StartIndex.Item1, 0)
                .Zip(EnumerableExtensions.CountUp(StartIndex.Item2, 7)).ToList();

            var thirdDiag = EnumerableExtensions.CountUp(StartIndex.Item1, 7)
               .Zip(EnumerableExtensions.CountDown(StartIndex.Item2, 0)).ToList();

            var fourthDiag = EnumerableExtensions.CountUp(StartIndex.Item1, 7)
                .Zip(EnumerableExtensions.CountUp(StartIndex.Item2, 7)).ToList();

            var firstSubArrays = firstDiag.Select((x, y) => firstDiag.Take(y + 1)).Skip(1);
            var secondSubArrays = secondDiag.Select((x, y) => secondDiag.Take(y + 1)).Skip(1);
            var thirdSubArrays = thirdDiag.Select((x, y) => thirdDiag.Take(y + 1)).Skip(1);
            var fourthSubArrays = fourthDiag.Select((x, y) => fourthDiag.Take(y + 1)).Skip(1);

            return firstSubArrays.Concat(secondSubArrays).Concat(thirdSubArrays).Concat(fourthSubArrays);
        }

        public IEnumerator<IEnumerable<(int, int)>> GetEnumerator()
        {
            foreach(var path in AllDiagonals())
            {
                yield return path;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
