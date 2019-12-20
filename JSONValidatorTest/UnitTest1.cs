using System;
using JSONValidator;
using Xunit;

namespace JSONValidatorTest
{
    public class UnitTest1
    {
        [Fact]
        public void ValidateJsonReturnTrueForString()
        {
            string inputTestValue = "\"\"";
            Assert.True(Program.ValidateJson(inputTestValue));
        }
        
        [Fact]
        public void ValidateJsonReturnsFalseForQuotationsOneSide()
        {
            string inputTestValue = "\"teststring";
            Assert.False(Program.ValidateJson(inputTestValue));
        }
    }
}
