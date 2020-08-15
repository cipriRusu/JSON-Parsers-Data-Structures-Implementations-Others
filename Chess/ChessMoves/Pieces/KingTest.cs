using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class KingTest
    {
        [Fact]
        public void BlackKingReturnsAllLegalMovesStartPosition()
        {
            var king = new King("e8", Player.Black);

            var actual = new PathGenerator(king, PathType.King).GetEnumerator().ToList();

            var expected = new List<IPath>
            {
                new Path(new List<(int, int)>{(0, 5)}, (0, 4)),
                new Path(new List<(int, int)>{(0, 3)}, (0, 4)),
                new Path(new List<(int, int)>{(1, 3)}, (0, 4)),
                new Path(new List<(int, int)>{(1, 4)}, (0, 4)),
                new Path(new List<(int, int)>{(1, 5)}, (0, 4)),
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhiteKingReturnsAllLegalMovesStartPosition()
        {
            var king = new King("e1", Player.White);

            var actual = new PathGenerator(king, PathType.King).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>{(7, 5)}, (7, 4)),
                new Path(new List<(int, int)>{(6, 5)}, (7, 4)),
                new Path(new List<(int, int)>{(6, 4)}, (7, 4)),
                new Path(new List<(int, int)>{(6, 3)}, (7, 4)),
                new Path(new List<(int, int)>{(7, 3)}, (7, 4)),
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackKingReturnsAllLegalMovesDownwardTable()
        {
            var king = new King("d6", Player.Black);

            var actual = new PathGenerator(king, PathType.King).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                new Path(new List<(int, int)>{(2, 4)}, (2, 3)),
                new Path(new List<(int, int)>{(1, 4)}, (2, 3)),
                 new Path(new List<(int, int)>{(1, 3)}, (2, 3)),
                 new Path(new List<(int, int)>{(1, 2)}, (2, 3)),
                 new Path(new List<(int, int)>{(2, 2)}, (2, 3)),
                 new Path(new List<(int, int)>{(3, 2)}, (2, 3)),
                 new Path(new List<(int, int)>{(3, 3)}, (2, 3)),
                 new Path(new List<(int, int)>{(3, 4)}, (2, 3)),
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhiteKingReturnsAllLegalMovesUpwardTable()
        {
            var king = new King("g3", Player.White);

            var actual = new PathGenerator(king, PathType.King).GetEnumerator().ToList();

            var expected = new List<IPath>()
            {
                 new Path(new List<(int, int)>{(5, 7)}, (5, 6)),
                 new Path(new List<(int, int)>{(4, 7)}, (5, 6)),
                 new Path(new List<(int, int)>{(4, 6)}, (5, 6)),
                 new Path(new List<(int, int)>{(4, 5)}, (5, 6)),
                 new Path(new List<(int, int)>{(5, 5)}, (5, 6)),
                 new Path(new List<(int, int)>{(6, 5)}, (5, 6)),
                 new Path(new List<(int, int)>{(6, 6)}, (5, 6)),
                 new Path(new List<(int, int)>{(6, 7)}, (5, 6)),
            };

            Assert.Equal(expected, actual, new PathComparer());
        }
    }
}
