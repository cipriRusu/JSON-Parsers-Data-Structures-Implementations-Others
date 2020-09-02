using ChessGame.Paths;
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
            var firstDiag = CustomEnumerableExtensions.CountDown(StartIndex.Item1, 0)
                .Zip(CustomEnumerableExtensions.CountDown(StartIndex.Item2, 0)).ToList();

            var secondDiag = CustomEnumerableExtensions.CountDown(StartIndex.Item1, 0)
                .Zip(CustomEnumerableExtensions.CountUp(StartIndex.Item2, 7)).ToList();

            var thirdDiag = CustomEnumerableExtensions.CountUp(StartIndex.Item1, 7)
               .Zip(CustomEnumerableExtensions.CountDown(StartIndex.Item2, 0)).ToList();

            var fourthDiag = CustomEnumerableExtensions.CountUp(StartIndex.Item1, 7)
                .Zip(CustomEnumerableExtensions.CountUp(StartIndex.Item2, 7)).ToList();

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
