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

            Assert.Equal('a', rankAndFile.Rank);
            Assert.Equal('7', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMatrixIndex()
        {
            var rankAndFile = new RankAndFile((7, 7));

            Assert.Equal('h', rankAndFile.Rank);
            Assert.Equal('1', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMatrixIndexOppositeCorner()
        {
            var rankAndFile = new RankAndFile((0, 0));

            Assert.Equal('a', rankAndFile.Rank);
            Assert.Equal('8', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMatrixIndexCorner()
        {
            var rankAndFile = new RankAndFile((0, 7));

            Assert.Equal('h', rankAndFile.Rank);
            Assert.Equal('8', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMatrixIndexInsideBoard()
        {
            var rankAndFile = new RankAndFile((4, 2));

            Assert.Equal('c', rankAndFile.Rank);
            Assert.Equal('4', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileForSingleUnmovedRockMAtrixIndexInsideBoardSecond()
        {
            var rankAndFile = new RankAndFile((3, 6));

            Assert.Equal('g', rankAndFile.Rank);
            Assert.Equal('5', rankAndFile.File);
        }

        [Fact]
        public void GetRankAndFileThrowsArgumentExceptionForInvalidIndices()
        {
            Assert.Throws<ArgumentException>(() => new RankAndFile((9, 8)));
        }
    }
}
