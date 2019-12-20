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
    }
}
