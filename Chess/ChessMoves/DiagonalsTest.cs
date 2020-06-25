using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class DiagonalsTest
    {
        [Fact]
        public void ReturnAllDiagonalsFromEdgePoint()
        {
            var testDiag = new Diagonals((7, 2));

            var expected = new List<List<(int, int)>>
            {
                new List<(int, int)>() {(7, 2), (6, 1) },
                new List<(int, int)>() {(7, 2), (6, 1), (5, 0) },

                new List<(int, int)>() {(7, 2), (6, 3) },
                new List<(int, int)>() {(7, 2), (6, 3), (5, 4) },
                new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5) },
                new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5), (3, 6) },
                new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5), (3, 6), (2, 7) },
            };

            Assert.Equal(expected, testDiag.AllDiagonals);
        }

        [Fact]
        public void ReturnAllDiagonalsFromMiddlePoint()
        {
            var testDiag = new Diagonals((4, 5));

            var expected = new List<List<(int, int)>>()
            {
                new List<(int, int)>() {(4, 5), (3, 4) },
                new List<(int, int)>() {(4, 5), (3, 4), (2, 3) },
                new List<(int, int)>() {(4, 5), (3, 4), (2, 3), (1, 2)},
                new List<(int, int)>() {(4, 5), (3, 4), (2, 3), (1, 2), (0, 1)},

                new List<(int, int)>() {(4, 5), (3, 6) },
                new List<(int, int)>() {(4, 5), (3, 6), (2, 7)},

                new List<(int, int)>() {(4, 5), (5, 4) },
                new List<(int, int)>() {(4, 5), (5, 4), (6, 3) },
                new List<(int, int)>() {(4, 5), (5, 4), (6, 3), (7, 2) },


                new List<(int, int)>() {(4, 5), (5, 6) },
                new List<(int, int)>() {(4, 5), (5, 6), (6, 7) },
            };

            Assert.Equal(expected, testDiag.AllDiagonals);
        }
    }
}
