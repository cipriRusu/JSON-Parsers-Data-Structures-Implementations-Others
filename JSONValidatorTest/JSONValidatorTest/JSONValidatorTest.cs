using System;
using Xunit;

namespace JSONValidatorTest
{
    public class ValidateJsonInputTest
    {
        [Fact]
        public void JsonStringValidatorReturnsFalseForAbsentQuotations()
        {
            var inputJsonString = "InputString";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public void JsonStringValidatorReturnsFalseForAbsentQLeft()
        {
            var inputJsonString = "\"InputString";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public void JsonStringValidatorReturnsFalseForAbsentQRight()
        {
            var inputJsonString = "InputString\"";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public void JsonStringValidatorReturnsTrueForPresentQuotations()
        {
            var inputJsonString = "\"InputString\"";
            Assert.True(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }
    }
}
