using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONValidatorAlternativeVersion
{
    public class NumberTest
    {
        [Fact]
        private void NumberReturnsTrueForValidJsonInputNumericValuesOnly()
        {
            var number = new Number();
            Assert.True(number.Match("1234").Success());
        }

        [Fact]
        private void ReturnTextReturnsEmptyStringForValidValue()
        {
            var number = new Number();
            Assert.Equal("", number.Match("1234").RemainingText());
        }

        [Fact]
        public void NumberReturnFalseForInvalidJsonInputNumericValuesOnly()
        {
            var number = new Number();
            Assert.False(number.Match("01234").Success());
        }

        [Fact]
        public void ReturnTextReturnsValidStringForInvalidInputNumericValuesOnly()
        {
            var number = new Number();
            Assert.Equal("01234", number.Match("01234").RemainingText());
        }

        [Fact]
        public void SuccesReturnsTrueForValidInputNegativeNumber()
        {
            var number = new Number();
            Assert.True(number.Match("-1234").Success());
        }

        [Fact]
        public void ReturnTextReturnsValidStringForValidNegativeInput()
        {
            var number = new Number();
            Assert.Equal("", number.Match("-1234").RemainingText());
        }

        [Fact]
        public void SuccesReturnsFalseForNegativeAndLeadingZeroValue()
        {
            var number = new Number();
            Assert.False(number.Match("-01234").Success());
        }

        [Fact]
        public void ReturnTextReturnsValidStringForInvalidNegativeInput()
        {
            var number = new Number();
            Assert.Equal("-01234", number.Match("-01234").RemainingText());
        }

        [Fact]
        public void SuccesReturnsTrueForValidDecimalNumberValue()
        {
            var number = new Number();
            Assert.True(number.Match("12.34").Success());
        }

        [Fact]
        public void ReturnTextReturnsValidStringForValidDecimalNumberValue()
        {
            var number = new Number();
            Assert.Equal("", number.Match("12.34").RemainingText());
        }

        [Fact]
        public void SuccessReturnsFalseForInvalidNegativeNumberWithDecimal()
        {
            var number = new Number();
            Assert.False(number.Match("-0123.1").Success());
        }

        [Fact]
        public void ReturnTextReturnsValidStringForInValidDecimalNumberValue()
        {
            var number = new Number();
            Assert.Equal("-0123.4", number.Match("-0123.4").RemainingText());
        }

        [Fact]
        public void SuccessReturnsTrueForValidDecimalNegativeNumberWithLeadingZero()
        {
            var number = new Number();
            Assert.True(number.Match("-0.123").Success());
        }
    }
}
