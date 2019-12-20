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
            Assert.True(ValidateJsonInput.JsonValidator(inputJsonString));
        }

        [Fact]
        public void JsonValidatorReturnsFalseForAbsentQuotations()
        {
            var inputJsonString = "";
            Assert.False(ValidateJsonInput.JsonValidator(inputJsonString));
        }
    }
}
