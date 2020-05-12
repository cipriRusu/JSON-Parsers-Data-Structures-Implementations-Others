using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xunit;

namespace Functional_LINQ.OperatorsCombination
{
    public class OperatorsCombinationTest
    {
        [Fact]
        public void GenerateOperatorsReturnsNoValueForZeroTail()
        {
            var TargetValue = 0;
            var TailValue = 0;

            var operators = new OperatorsCombination();
            operators.GenerateOperators(TailValue, TargetValue);

            var expected = new string[]
            {
                " = 0\n",
            };

            Assert.Equal(expected, operators.ValidCombinations);
        }

        [Fact]
        public void GenerateOperatorsReturnsSingleValue()
        {
            var TargetValue = 1;
            var TailValue = 1;

            var operators = new OperatorsCombination();
            operators.GenerateOperators(TailValue, TargetValue);

            var expected = new string[]
            {
                "+1 = 1\n",
            };

            Assert.Equal(expected, operators.ValidCombinations);
        }

        [Fact]
        public void GenerateOperatorReturnsValidOutputForTwoValues()
        {
            var TargetValue = 1;
            var TailValue = 2;

            var operators = new OperatorsCombination();
            operators.GenerateOperators(TailValue, TargetValue);

            var expected = new string[]
            {
                "-1+2 = 1\n",
            };

            Assert.Equal(expected, operators.ValidCombinations);
        }

        [Fact]
        public void GenerateOperatorsWorksForSmallNumber()
        {
            var TargetValue = 0;
            var TailValue = 3;

            var operators = new OperatorsCombination();
            operators.GenerateOperators(TailValue, TargetValue);

            var expected = new string[]
            {
                "+1+2-3 = 0\n",
                "-1-2+3 = 0\n"
            };

            Assert.Equal(expected, operators.ValidCombinations);
        }

        [Fact]
        public void GenerateOperatorsWorksForLargerNumber()
        {
            var TargetValue = 10;
            var TailValue = 7;

            var operators = new OperatorsCombination();
            operators.GenerateOperators(TailValue, TargetValue);

            var expected = new string[]
            {
                "+1+2+3-4-5+6+7 = 10\n",
                "+1+2-3+4+5-6+7 = 10\n",
                "+1-2+3+4+5+6-7 = 10\n",
                "+1-2-3-4+5+6+7 = 10\n",
                "-1+2-3+4-5+6+7 = 10\n",
                "-1-2+3+4+5-6+7 = 10\n"
            };

            Assert.Equal(expected, operators.ValidCombinations);
        }
    }
}
