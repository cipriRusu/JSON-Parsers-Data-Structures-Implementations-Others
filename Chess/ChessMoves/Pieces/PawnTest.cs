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
            var pawn = new Pawn("a7", Player.Black);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>{(1, 0), (2, 0) }, (1, 0)),
                new Path(new List<(int, int)>{(1, 0), (2, 0), (3, 0) }, (1, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackPawnReturnsCorrectLegalMoveFurther()
        {
            var pawn = new Pawn("a4", Player.Black);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>{(4, 0), (5, 0)}, (4, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackPawnInsideBoardReturnsCorrectLegalMoveDownwardTableFromStartIndex()
        {
            var pawn = new Pawn("f7", Player.Black);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>{(1, 5), (2, 5) }, (1, 5)),
                new Path(new List<(int, int)>{(1, 5), (2, 5), (3, 5) }, (1, 5))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackPawnInsideBoardReturnsNoMovesAtEdgeOfBoard()
        {
            var pawn = new Pawn("f1", Player.Black);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>() { };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackPawnReturnsEmptyListForEndOfBoard()
        {
            var pawn = new Pawn("a1", Player.Black);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>() { };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhitePawnReturnsCorrectLegalMoveDownwardTableFromStartIndex()
        {
            var pawn = new Pawn("a2", Player.White);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>{(6, 0), (5, 0) }, (6, 0)),
                new Path(new List<(int, int)>{(6, 0), (5, 0), (4, 0) }, (6, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhitePawnReturnsCorrectLegalMovementsFromStartIndexBoardInterior()
        {
            var pawn = new Pawn("d2", Player.White);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>{(6, 3), (5, 3) }, (6, 3)),
                new Path(new List<(int, int)>{(6, 3), (5, 3), (4, 3) }, (6, 3))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhitePawnInsideBoardReturnsCorrectLegalMoveFurther()
        {
            var pawn = new Pawn("a3", Player.White);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>{(5, 0), (4, 0) }, (5, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhitePawnInsideBoardReturnsEmptyListForEndOfBoard()
        {
            var pawn = new Pawn("e8", Player.White);

            var actual = new PathGenerator(pawn, PathType.Pawn).GetEnumerator().ToList();

            var expected = new List<IPath>() { };

            Assert.Equal(expected, actual, new PathComparer());
        }
    }
}
