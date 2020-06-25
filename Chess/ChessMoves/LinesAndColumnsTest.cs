using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class LinesAndColumnsTest
    {
        [Fact]
        public void ReturnAllLinesAndColumnsFromCornerPoint()
        {
            var testLinesCols = new LinesAndColumns((0, 0));

            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)> {(0, 0), (0, 1) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},

                new List<(int, int)> {(0, 0), (1, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)},
            };

            Assert.Equal(expected, testLinesCols.AllRowsColumns);
        }

        [Fact]
        public void ReturnAllRowsAndColumnsFromMiddleStartPoint()
        {
            var testLinesCols = new LinesAndColumns((3, 2));

            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>() {(3, 2), (2, 2) },
                new List<(int, int)>() {(3, 2), (2, 2), (1, 2) },
                new List<(int, int)>() {(3, 2), (2, 2), (1, 2), (0, 2)},

                new List<(int, int)>() {(3, 2), (3, 3) },
                new List<(int, int)>() {(3, 2), (3, 3), (3, 4) },
                new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5) },
                new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5), (3, 6) },
                new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7)},

                new List<(int, int)>() {(3, 2), (4, 2) },
                new List<(int, int)>() {(3, 2), (4, 2), (5, 2) },
                new List<(int, int)>() {(3, 2), (4, 2), (5, 2), (6, 2) },
                new List<(int, int)>() {(3, 2), (4, 2), (5, 2), (6, 2), (7, 2)},

                new List<(int, int)>() {(3, 2), (3, 1) },
                new List<(int, int)>() {(3, 2), (3, 1), (3, 0)},
            };

            Assert.Equal(expected, testLinesCols.AllRowsColumns);
        }
    }
}
