using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class RankAndFileTest
    {
        [Fact]
        public void GetRankAndFileForSingleUnMovedPawnMatrixIndex()
         {
            var rankAndFile = new RankAndFile((1, 0));

            Assert.Equal('7', rankAndFile.Rank);
            Assert.Equal('a', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMatrixIndex()
        {
            var rankAndFile = new RankAndFile((7, 7));

            Assert.Equal('1', rankAndFile.Rank);
            Assert.Equal('h', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMatrixIndexOppositeCorner()
        {
            var rankAndFile = new RankAndFile((0, 0));

            Assert.Equal('8', rankAndFile.Rank);
            Assert.Equal('a', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMatrixIndexCorner()
        {
            var rankAndFile = new RankAndFile((0, 7));

            Assert.Equal('8', rankAndFile.Rank);
            Assert.Equal('h', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMatrixIndexInsideBoard()
        {
            var rankAndFile = new RankAndFile((4, 2));

            Assert.Equal('4', rankAndFile.Rank);
            Assert.Equal('c', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMAtrixIndexInsideBoardSecond()
        {
            var rankAndFile = new RankAndFile((3, 6));

            Assert.Equal('5', rankAndFile.Rank);
            Assert.Equal('g', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileThrowsArgumentExceptionForInvalidIndices()
        {
            Assert.Throws<ArgumentException>(() => new RankAndFile((9, 8)));
        }
    }
}
