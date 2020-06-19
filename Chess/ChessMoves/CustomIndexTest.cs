using System;
using Xunit;

namespace ChessMoves
{
    public class CustomIndexTest
    {
        [Fact]
        public void GetMatrixIndexReturnsAppropriateValueForValidPawnIndexInCorner()
        {
            var cIndex = new CustomIndex();
            Assert.Equal((0, 0), cIndex.GetMatrixIndex("a8"));
        }

        [Fact]
        public void GetMatrixIndexReturnsAppropriateValuesForValidPawnIndexInBoard()
        {
            var cIndex = new CustomIndex();
            Assert.Equal((4, 4), cIndex.GetMatrixIndex("e4"));
        }

        [Fact]
        public void GetMatrixIndexThrowsArgumentExceptionForInvalidIndex()
        {
            var cIndex = new CustomIndex();
            Assert.Throws<ArgumentException>(() => cIndex.GetMatrixIndex("z9"));
        }
    }
}
