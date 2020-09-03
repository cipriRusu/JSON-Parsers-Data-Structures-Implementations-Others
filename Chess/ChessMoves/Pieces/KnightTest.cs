using ChessGame.Paths;
using ChessMoves.Paths;
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
            var actual = new Knight("b8", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(Enumerable.Repeat((2, 2), 1), (0, 1)),  
                new MovePath(Enumerable.Repeat((1, 3), 1), (0, 1)),
                new MovePath(Enumerable.Repeat((2, 0), 1), (0, 1))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void SecondBlackKnightReturnsAllPossibleMovesDownwardBoardOnStartPosition()
        {
            var actual = new Knight("g8", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(Enumerable.Repeat((2, 7), 1), (0, 6)),
                new MovePath(Enumerable.Repeat((2, 5), 1), (0, 6)),
                new MovePath(Enumerable.Repeat((1, 4), 1), (0, 6)),
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhiteKnightReturnsAllPossibleMovesUpwardBoardOnStartPosition()
        {
            var actual = new Knight("b1", Player.White).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(Enumerable.Repeat((5, 2), 1), (7, 1)),
                new MovePath(Enumerable.Repeat((6, 3), 1), (7, 1)),
                new MovePath(Enumerable.Repeat((5, 0), 1), (7, 1))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void SecondWhiteKnightReturnsAllPossibleMovesUpwardBoardOnStartPosition()
        {
            var actual = new Knight("g1", Player.White).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(Enumerable.Repeat((5, 7), 1), (7, 6)),
                new MovePath(Enumerable.Repeat((5, 5), 1), (7, 6)),
                new MovePath(Enumerable.Repeat((6, 4), 1), (7, 6))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackKnightReturnsAllPossibleMovesDownwardBoardMiddleBoard()
        {
            var actual = new Knight("c6", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(Enumerable.Repeat((0, 3), 1), (2, 2)),
                new MovePath(Enumerable.Repeat((1, 4), 1), (2, 2)),
                new MovePath(Enumerable.Repeat((0, 1), 1), (2, 2)),
                new MovePath(Enumerable.Repeat((1, 0), 1), (2, 2)),
                new MovePath(Enumerable.Repeat((4, 3), 1), (2, 2)),
                new MovePath(Enumerable.Repeat((3, 4), 1), (2, 2)),
                new MovePath(Enumerable.Repeat((4, 1), 1), (2, 2)),
                new MovePath(Enumerable.Repeat((3, 0), 1), (2, 2))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhiteKnightReturnsAllPossibleMovesUpwardBoardMiddleBoard()
        {
            var actual = new Knight("f3", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(Enumerable.Repeat((3, 6), 1), (5, 5)),
                new MovePath(Enumerable.Repeat((4, 7), 1), (5, 5)),
                new MovePath(Enumerable.Repeat((3, 4), 1), (5, 5)),
                new MovePath(Enumerable.Repeat((4, 3), 1), (5, 5)),
                new MovePath(Enumerable.Repeat((7, 6), 1), (5, 5)),
                new MovePath(Enumerable.Repeat((6, 7), 1), (5, 5)),
                new MovePath(Enumerable.Repeat((7, 4), 1), (5, 5)),
                new MovePath(Enumerable.Repeat((6, 3), 1), (5, 5))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }
    }
}
