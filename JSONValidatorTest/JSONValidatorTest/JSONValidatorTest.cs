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

        [Fact]
        public static void JsonStringValidatorReturnsTrueForComplexValidValue()
        {
            var inputJsonString = "\"InputComplexValid\\nValue\\u00AB\"";
            Assert.True(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public static void JsonStringValidatorReturnsFalseForComplexInvalidValue()
        {
            var inputJsonString = "\"InputComplexValid\\gValue\\u00AB\"";
            Assert.False(ValidateJsonInput.JsonStringValidator(inputJsonString));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsTrueForValidPositiveInteger()
        {
            var inputJsonNumber = "126";
            Assert.True(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsTrueForValidNegativeInteger()
        {
            var inputJsonNumber = "-121";
            Assert.True(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsFalseForIntegerWithLeadingZero()
        {
            var inputJsonNumber = "0134";
            Assert.False(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsTrueForValidDecimal()
        {
            var inputJsonNumber = "12.32";
            Assert.True(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsTrueForValidExponentialValue()
        {
            var inputJsonNumber = "12.123e3";
            Assert.True(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsTrueForValidExponentialPosExponent()
        {
            var inputJsonNumber = "12.123E+2";
            Assert.True(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsTrueForValidExponentialNegExponent()
        {
            var inputJsonNumber = "12.123E-3";
            Assert.True(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsFalseForValidExponentialNoExponent()
        {
            var inputJsonNumber = "12.123E";
            Assert.False(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }

        [Fact]
        public static void JsonNumberValidatorReturnsFalseForValidDecimalNoTrailingValues()
        {
            var inputJsonNumber = "12.";
            Assert.False(ValidateJsonInput.JsonNumberValidator(inputJsonNumber));
        }
    }
}