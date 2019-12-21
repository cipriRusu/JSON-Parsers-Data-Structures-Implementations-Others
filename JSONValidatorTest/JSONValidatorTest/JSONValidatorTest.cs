using System;
using Xunit;

namespace JSONValidatorTest
{
    public class JSONValidatorTest
    {
        [Fact]
        public void JsonValidatorReturnsTrueForEmptyCorrectJsonString()
        {
            var inputJsonString = "\"\"";
            Assert.True(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public void JsonValidatorReturnsFalseForAbsentQuotations()
        {
            var inputJsonString = "";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }
    }
}
