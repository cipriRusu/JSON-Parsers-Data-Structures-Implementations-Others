using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class KnightMovesTest
    {
        [Fact]
        public void KnightReturnsValidMovesFromEdgeOfBoard()
        {
            var kMoves = new KnightMoves((0, 1));
            var expected = new List<IEnumerable<(int, int)>>()
            {
                Enumerable.Repeat((2, 2), 1),
                Enumerable.Repeat((1, 3), 1),
                Enumerable.Repeat((2, 0), 1),
            };

            Assert.Equal(expected, kMoves.AllMoves);
        }

        [Fact]
        public void KnightMovesReturnsValidMoveFromMiddleOfBoard()
        {
            var kMoves = new KnightMoves((2, 2));
            var expected = new List<IEnumerable<(int, int)>>()
            {
                Enumerable.Repeat((0, 3), 1),
                Enumerable.Repeat((1, 4), 1),
                Enumerable.Repeat((0, 1), 1),
                Enumerable.Repeat((1, 0), 1),
                Enumerable.Repeat((4, 3), 1),
                Enumerable.Repeat((3, 4), 1),
                Enumerable.Repeat((4, 1), 1),
                Enumerable.Repeat((3, 0), 1),
            };

            Assert.Equal(expected, kMoves.AllMoves);
        }
    }
}
