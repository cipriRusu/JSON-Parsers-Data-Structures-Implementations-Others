using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.PolishNotationEvaluator
{
    public static class EnumerableExtensions
    {
        public static int Operate(this IEnumerable<int> input, string inputOperator)
        {
            switch(inputOperator)
            {
                case "+": return input.First() + input.Last();
                case "-": return input.First() - input.Last();
                case "*": return input.First() * input.Last();
                case "/": return input.First() / input.Last();
                case "^": return (int)Math.Pow(input.First(), input.Last());
            }

            throw new ArgumentException();
        }
    }
}