using System;
using Xunit;

namespace ChessMoves
{
    public class IndexTest
    {
        [Fact]
        public void GetMatrixIndexReturnsAppropriateValueForValidPawnIndexInCorner()
        {
            var cIndex = new Index();
            Assert.Equal((0, 0), cIndex.GetIndex("a8"));
        }

        [Fact]
        public void GetMatrixIndexReturnsAppropriateValuesForValidPawnIndexInBoard()
        {
            var cIndex = new Index();
            Assert.Equal((4, 4), cIndex.GetIndex("e4"));
        }

        [Fact]
        public void GetMatrixIndexThrowsArgumentExceptionForInvalidIndex()
        {
            var cIndex = new Index();
            Assert.Throws<ArgumentException>(() => cIndex.GetIndex("z9"));
        }
    }
}
