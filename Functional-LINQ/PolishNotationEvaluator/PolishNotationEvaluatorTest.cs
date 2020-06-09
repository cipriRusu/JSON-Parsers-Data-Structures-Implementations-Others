using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional_LINQ.PolishNotationEvaluator
{
    public class PolishNotationEvaluatorTest
    {
        [Fact]
        public void PolishNotationEvaluatorEvaluatesSimpleExpression()
        {
            var evaluator = new PolishNotationEvaluator();

            Assert.Equal(7, evaluator.PolishNotationExpressionEvaluator("3 4 +"));
        }

        [Fact]
        public void PolishNotationEvaluatorEvaluatesSimpleExpressionLargerValues()
        {
            var evaluator = new PolishNotationEvaluator();

            Assert.Equal(17, evaluator.PolishNotationExpressionEvaluator("13 4 +"));
        }

        [Fact]
        public void PolishNotationEvaluatorEvaluatesSimpleNestedExpression()
        {
            var evaluator = new PolishNotationEvaluator();

            Assert.Equal(12, evaluator.PolishNotationExpressionEvaluator("13 3 4 - +"));
        }

        [Fact]
        public void PolishNotationEvaluatorEvaluatesComplexNestedExpressionAllOperators()
        {
            var evaluator = new PolishNotationEvaluator();

            Assert.Equal(39, evaluator.PolishNotationExpressionEvaluator("6 9 + 4 2 * 4 2 ^ + +"));
        }
        [Fact]
        public void PolishNotationEvaluatorEvaluatesComplexNestedExpressionMultipleOperators()
        {
            var evaluator = new PolishNotationEvaluator();

            Assert.Equal(59, evaluator.PolishNotationExpressionEvaluator("5 3 2 3 ^ 5 - 7 -3 * + * -"));
        }
    }
}
