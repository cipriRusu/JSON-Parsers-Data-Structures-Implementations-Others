using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JSONValidatorAlternativeVersion
{
    public class OptionalTest
    {
        [Fact(DisplayName = "Match returns true for one character from string")]
        public void MatchReturnsTrueForOneSingleCharacterValueAndStringInput()
        {
            var optionalTestObject = new Optional(new Character('a'));
            Assert.True(optionalTestObject.Match("abc").Success());
        }

        [Fact(DisplayName = "Remaining text returns proper string output from initial string")]
        public void RemainingTextReturnsProperStringValueFromInitialString()
        {
            var optionalTestObject = new Optional(new Character('a'));
            Assert.Equal("bc", optionalTestObject.Match("abc").RemainingText());
        }

        [Fact(DisplayName = "Match returns false for one character from invalid string")]
        public void MatchReturnsProperStringValueFromInitialInvalidString()
        {
            var optionalTestProject = new Optional(new Character('a'));
            Assert.False(optionalTestProject.Match("xbc").Success());
        }

        [Fact(DisplayName = "Remaining text returns proper string from output from initial string invalid value")]
        public void RemainingTextReturnsProperValueFromInitialInvalidString()
        {
            var optionalTestProject = new Optional(new Character('a'));
            Assert.Equal("xbc", optionalTestProject.Match("xbc").RemainingText());
        }

        [Fact(DisplayName = "Match returns true for range value from string")]
        public void MatchReturnsTrueForRangeValueFromInitialString()
        {
            var optionalTestProject = new Optional(new Range('0', '5'));
            Assert.True(optionalTestProject.Match("0013").Success());
        }

        [Fact(DisplayName = "Remaining text returns proper string output from valid string")]
        public void RemainingTextReturnsProperOutputValueFromInitialValidString()
        {
            var optinalTestProject = new Optional(new Range('0', '5'));
            Assert.Equal("013", optinalTestProject.Match("0013").RemainingText());
        }

        [Fact(DisplayName = "Match returns true for pattern not present in input string")]
        public void MatchReturnsTrueForPatternNotPresentInInputString()
        {
            var optionalTestProject = new Optional(new Range('0', '5'));
            Assert.True(optionalTestProject.Match("bc").Success());
        }
    }
}
