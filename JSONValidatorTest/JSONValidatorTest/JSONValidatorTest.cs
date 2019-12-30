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

        [Fact]
        public void JsonStringValidatorReturnsFalseForExtraQuotations()
        {
            var inputJsonString = "\"Input\"String\"";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public void JsonStringValidatorReturnsFalseForInvalidEscapeSequence()
        {
            var inputJsonString = "\"InputStrin\\g\"";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public void JsonStringValidatorReturnsFalseForMultipleEscapeSequencesOneValidOneInvalid()
        {
            var inputJsonString = "\"I\\nput\\String\"";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public void JsonStringValidatorReturnsTrueForValidUnicodeValue()
        {
            var inputJsonString = "\"\\u009A\\u009a\"";
            Assert.True(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public void JsonStringValidatorReturnsFalseForInvalidUnicodeValue()
        {
            var inputJsonString = "\"\\u009X\\u009x\"";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }
    }
}