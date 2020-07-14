using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class KnightTest
    {
        [Fact]
        public void BlackKnigtReturnsAllPossibleMovesDownwardBoardOnStartPosition()
        {
            var knight = new Knight("b8", Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                Enumerable.Repeat((2, 2), 1),
                Enumerable.Repeat((1, 3), 1),
                Enumerable.Repeat((2, 0), 1),
            };

            var actual = knight.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SecondBlackKnightReturnsAllPossibleMovesDownwardBoardOnStartPosition()
        {
            var knight = new Knight("g8", Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                Enumerable.Repeat((2, 7), 1),
                Enumerable.Repeat((2, 5), 1),
                Enumerable.Repeat((1, 4), 1),
            };

            var actual = knight.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteKnightReturnsAllPossibleMovesUpwardBoardOnStartPosition()
        {
            var knight = new Knight("b1", Player.White);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                Enumerable.Repeat((5, 2), 1),
                Enumerable.Repeat((6, 3), 1),
                Enumerable.Repeat((5, 0), 1),
            };

            var actual = knight.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SecondWhiteKnightReturnsAllPossibleMovesUpwardBoardOnStartPosition()
        {
            var knight = new Knight("g1", Player.White);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                Enumerable.Repeat((5, 7), 1),
                Enumerable.Repeat((5, 5), 1),
                Enumerable.Repeat((6, 4), 1),
            };

            var actual = knight.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackKnightReturnsAllPossibleMovesDownwardBoardMiddleBoard()
        {
            var knight = new Knight("c6", Player.Black);
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

            var actual = knight.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteKnightReturnsAllPossibleMovesUpwardBoardMiddleBoard()
        {
            var knight = new Knight("f3", Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                Enumerable.Repeat((3, 6), 1),
                Enumerable.Repeat((4, 7), 1),
                Enumerable.Repeat((3, 4), 1),
                Enumerable.Repeat((4, 3), 1),
                Enumerable.Repeat((7, 6), 1),
                Enumerable.Repeat((6, 7), 1),
                Enumerable.Repeat((7, 4), 1),
                Enumerable.Repeat((6, 3), 1),
            };

            var actual = knight.Moves();

            Assert.Equal(expected, actual);
        }
    }
}
