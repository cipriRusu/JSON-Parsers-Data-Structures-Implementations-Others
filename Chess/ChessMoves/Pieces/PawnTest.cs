using ChessGame.Paths;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class PawnTest
    {
        [Fact]
        public void BlackPawnReturnsCorrectLegalMoveDownwardTableFromStartIndex()
        {
            var actual = new Pawn("a7", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>{(1, 0), (2, 0) }, (1, 0)),
                new MovePath(new List<(int, int)>{(1, 0), (2, 0), (3, 0) }, (1, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackPawnReturnsCorrectLegalMoveFurther()
        {
            var actual = new Pawn("a4", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>{(4, 0), (5, 0)}, (4, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackPawnInsideBoardReturnsCorrectLegalMoveDownwardTableFromStartIndex()
        {
            var actual = new Pawn("f7", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>{(1, 5), (2, 5) }, (1, 5)),
                new MovePath(new List<(int, int)>{(1, 5), (2, 5), (3, 5) }, (1, 5))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackPawnInsideBoardReturnsNoMovesAtEdgeOfBoard()
        {
            var actual = new Pawn("f1", Player.Black).Moves;

            var expected = new List<IPath>() { };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackPawnReturnsEmptyListForEndOfBoard()
        {
            var actual = new Pawn("a1", Player.Black).Moves;

            var expected = new List<IPath>() { };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhitePawnReturnsCorrectLegalMoveDownwardTableFromStartIndex()
        {
            var actual = new Pawn("a2", Player.White).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>{(6, 0), (5, 0) }, (6, 0)),
                new MovePath(new List<(int, int)>{(6, 0), (5, 0), (4, 0) }, (6, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhitePawnReturnsCorrectLegalMovementsFromStartIndexBoardInterior()
        {
            var actual = new Pawn("d2", Player.White).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>{(6, 3), (5, 3) }, (6, 3)),
                new MovePath(new List<(int, int)>{(6, 3), (5, 3), (4, 3) }, (6, 3))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhitePawnInsideBoardReturnsCorrectLegalMoveFurther()
        {
            var actual = new Pawn("a3", Player.White).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>{(5, 0), (4, 0) }, (5, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhitePawnInsideBoardReturnsEmptyListForEndOfBoard()
        {
            var actual = new Pawn("e8", Player.White).Moves;

            var expected = new List<IPath>() { };

            Assert.Equal(expected, actual, new PathComparer());
        }
    }
}
