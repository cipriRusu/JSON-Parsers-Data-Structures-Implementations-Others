using Xunit;

namespace JSONValidatorAlternativeVersion
{
    public class RangeTest
    {
        [Fact]
        public void RangeReturnsTrueForValidInterval()
        {
            var testRangeObject = new Range('a', 'f');
            Assert.True(testRangeObject.Match("abc").Success());
        }

        [Fact]
        public void RangeReturnsFalseForValidIntervalInvalidString()
        {
            var testRangeObject = new Range('a', 'f');
            Assert.False(testRangeObject.Match("1ab").Success());
        }

        [Fact]
        public void RangeReturnsTrueForValidIntervalUnSorted()
        {
            var testRangeObject = new Range('a', 'f');
            Assert.True(testRangeObject.Match("fab").Success());
        }

        [Fact]
        public void RangeReturnsFalseForNullInput()
        {
            var testRangeObject = new Range('a', 'f');
            Assert.False(testRangeObject.Match(null).Success());
        }

        [Fact]
        public void RangeReturnsFalseForEmptyInput()
        {
            var testRangeObject = new Range('a', 'f');
            Assert.False(testRangeObject.Match("").Success());
        }

        [Fact]
        public void RangeReturnsValidTextForMatchingChar()
        {
            var testRangeObject = new Range('a', 'i');
            Assert.Equal("fi", testRangeObject.Match("afi").RemainingText());
        }

        [Fact]
        public void RangeReturnsValidTextForUnMatchingChar()
        {
            var testRangeObject = new Range('a', 'i');
            Assert.Equal("jfi", testRangeObject.Match("jfi").RemainingText());
        }
    }
}