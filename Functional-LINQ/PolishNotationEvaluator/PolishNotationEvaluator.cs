using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Functional_LINQ.PolishNotationEvaluator
{
    public class PolishNotationEvaluator
    {
        public int PolishNotationExpressionEvaluator(string expression)
        {
            var results = expression.Split(' ');

            var final = results.Aggregate(Enumerable.Empty<int>(), (x, y) =>
            {
                x = int.TryParse(y, out int res) ? x.Append(res) : PerformOperation(x, y);

                return x;   
            });

            return final.Single();
        }

        private IEnumerable<int> PerformOperation(IEnumerable<int> x, string y)
        {
            var secondElement = x.TakeLast(1);
            x = x.SkipLast(1);
            var firstElement = x.TakeLast(1);
            x = x.SkipLast(1);

            x = x.Append(Operation(y, firstElement, secondElement));

            return x;
        }

        private int Operation(string y, IEnumerable<int> firstElement, IEnumerable<int> secondElement)
        {
            switch (y)
            {
                case "+":
                    {
                        return
                            Convert.ToInt32(firstElement.Single()) +
                            Convert.ToInt32(secondElement.Single());
                    }
                case "-":
                    {
                        return
                            Convert.ToInt32(firstElement.Single()) -
                            Convert.ToInt32(secondElement.Single());
                    }
                case "/":
                    {
                        return
                            Convert.ToInt32(firstElement.Single()) /
                            Convert.ToInt32(secondElement.Single());
                    }
                case "*":
                    {
                        return
                            Convert.ToInt32(firstElement.Single()) *
                            Convert.ToInt32(secondElement.Single());
                    }
                case "^":
                    {
                        return(int)
                           Math.Pow(
                               Convert.ToInt32(firstElement.Single()),
                               Convert.ToInt32(secondElement.Single()));
                    }

            }

            throw new ArgumentException();
        }
    }
}