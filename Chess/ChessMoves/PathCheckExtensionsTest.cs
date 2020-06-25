using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class PathCheckExtensionsTest
    {
        [Fact]
        public void CheckMovePathReturnsTrueForValidPath()
        {
            var testEnumerable = new List<(int, int)>();
            var testBoard = new Piece[8,8];
            testBoard[0, 0] = new Piece((0, 0), Player.White);

            testEnumerable.Add((1, 0));
            testEnumerable.Add((2, 0));
            testEnumerable.Add((3, 0));

            Assert.True(testEnumerable.IsMovePathClear(testBoard));
        }

        [Fact]
        public void CheckMovePathReturnsFalseForUnclearPath()
        {
            var testEnumerable = new List<(int, int)>();
            var testBoard = new Piece[8, 8];
            testBoard[0, 0] = new Piece((0, 0), Player.White);
            testBoard[2, 0] = new Piece((2, 0), Player.Black);

            testEnumerable.Add((1, 0));
            testEnumerable.Add((2, 0));
            testEnumerable.Add((3, 0));

            Assert.False(testEnumerable.IsMovePathClear(testBoard));
        }

        [Fact]
        public void CheckCapturePathExtensionMethod()
        {
            var testEnumerable = new List<(int, int)>();
            var testBoard = new Piece[8, 8];

            testBoard[1, 0] = new Piece((1, 0), Player.White);
            testBoard[4, 3] = new Piece((4, 3), Player.Black);

            testEnumerable.Add((1, 0));
            testEnumerable.Add((2, 1));
            testEnumerable.Add((3, 2));
            testEnumerable.Add((4, 3));

            Assert.True(testEnumerable.IsCapturePathClear(testBoard));
        }

        [Fact]
        public void CheckCapturePathFailsForUnclearPath()
        {
            var testEnumerable = new List<(int, int)>();
            var testBoard = new Piece[8, 8];

            testBoard[1, 0] = new Piece((1, 0), Player.White);
            testBoard[4, 3] = new Piece((4, 3), Player.Black);
            testBoard[3, 2] = new Piece((3, 2), Player.Black);

            testEnumerable.Add((1, 0));
            testEnumerable.Add((2, 1));
            testEnumerable.Add((3, 2));
            testEnumerable.Add((4, 3));

            Assert.False(testEnumerable.IsCapturePathClear(testBoard));
        }

        [Fact]
        public void CheckCapturePathFailsForValidMovePath()
        {
            var testEnumerable = new List<(int, int)>();
            var testBoard = new Piece[8, 8];

            testBoard[1, 0] = new Piece((1, 0), Player.White);

            testEnumerable.Add((1, 0));
            testEnumerable.Add((2, 1));
            testEnumerable.Add((3, 2));
            testEnumerable.Add((4, 3));

            Assert.False(testEnumerable.IsCapturePathClear(testBoard));
        }

        [Fact]
        public void CheckMovePathFailsForValidCapturePath()
        {
            var testEnumerable = new List<(int, int)>();
            var testBoard = new Piece[8, 8];

            testBoard[1, 0] = new Piece((1, 0), Player.White);
            testBoard[4, 3] = new Piece((4, 3), Player.Black);

            testEnumerable.Add((1, 0));
            testEnumerable.Add((2, 1));
            testEnumerable.Add((3, 2));
            testEnumerable.Add((4, 3));

            Assert.False(testEnumerable.IsMovePathClear(testBoard));
        }
    }
}
