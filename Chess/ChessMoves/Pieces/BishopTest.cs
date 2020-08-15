using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class BishopTest
    {
        [Fact]
        public void WhiteBishopReturnsAllPossibleMoves()
        {
            var bishop = new Bishop("c1", Player.White);

            var path = new PathGenerator(bishop, PathType.Diagonals).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>() {(7, 2), (6, 1) }, (7, 2)),
                new Path(new List<(int, int)>() {(7, 2), (6, 1), (5, 0) }, (7, 2)),
                new Path(new List<(int, int)>() {(7, 2), (6, 3) }, (7, 2)),
                new Path(new List<(int, int)>() {(7, 2), (6, 3), (5, 4) }, (7, 2)),
                new Path(new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5) }, (7, 2)),
                new Path(new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5), (3, 6) }, (7, 2)),
                new Path(new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5), (3, 6), (2, 7) }, (7, 2)),
            };

            Assert.Equal(expected, path, new PathComparer());
        }

        [Fact]
        public void WhiteBishopReturnsAllPossibleMovesBoardInterior()
        {
            var bishop = new Bishop("f4", Player.White);

            var path = new PathGenerator(bishop, PathType.Diagonals).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>() {(4, 5), (3, 4) }, (4, 5)),
                new Path(new List<(int, int)>() {(4, 5), (3, 4), (2, 3) }, (4, 5)),
                new Path(new List<(int, int)>() {(4, 5), (3, 4), (2, 3), (1, 2)}, (4, 5)),
                new Path(new List<(int, int)>() {(4, 5), (3, 4), (2, 3), (1, 2), (0, 1)}, (4, 5)),

                new Path(new List<(int, int)>() {(4, 5), (3, 6) }, (4, 5)),
                new Path(new List<(int, int)>() {(4, 5), (3, 6), (2, 7)}, (4, 5)),

                new Path(new List<(int, int)>() {(4, 5), (5, 4) }, (4, 5)),
                new Path(new List<(int, int)>() {(4, 5), (5, 4), (6, 3) }, (4, 5)),
                new Path(new List<(int, int)>() {(4, 5), (5, 4), (6, 3), (7, 2) }, (4, 5)),


                new Path(new List<(int, int)>() {(4, 5), (5, 6) }, (4, 5)),
                new Path(new List<(int, int)>() {(4, 5), (5, 6), (6, 7) }, (4, 5)),
            };

            Assert.Equal(expected, path, new PathComparer());
        }

        [Fact]
        public void BlackBishopReturnsAllPossibleMovesBoardInterior()
        {
            var bishop = new Bishop("d6", Player.Black);

            var path = new PathGenerator(bishop, PathType.Diagonals).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>(){(2, 3),(1, 2)}, (2, 3)),
                new Path(new List<(int, int)>(){(2, 3),(1, 2), (0, 1)}, (2, 3)),

                new Path(new List<(int, int)>() {(2, 3), (1, 4)}, (2, 3)),
                new Path(new List<(int, int)>() {(2, 3), (1, 4), (0, 5)}, (2, 3)),

                new Path(new List<(int, int)>() {(2, 3), (3, 2) }, (2, 3)),
                new Path(new List<(int, int)>() {(2, 3), (3, 2), (4, 1) }, (2, 3)),
                new Path(new List<(int, int)>() {(2, 3), (3, 2), (4, 1), (5, 0)}, (2, 3)),

                new Path(new List<(int, int)>() {(2, 3), (3, 4)}, (2, 3)),
                new Path(new List<(int, int)>() {(2, 3), (3, 4), (4, 5)}, (2, 3)),
                new Path(new List<(int, int)>() {(2, 3), (3, 4), (4, 5), (5, 6)}, (2, 3)),
                new Path(new List<(int, int)>() {(2, 3), (3, 4), (4, 5), (5, 6), (6, 7)}, (2, 3)),
            };

            Assert.Equal(expected, path, new PathComparer());
        }
    }
}
