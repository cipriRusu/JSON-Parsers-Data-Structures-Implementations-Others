using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Functional_LINQ.PolishNotationEvaluator
{
    public class PolishNotationEvaluator
    {
        internal string PolishNotationExpressionEvaluator(string expression)
        {
            var results = expression.Split(' ');

            var res = results.Aggregate(new Stack<string>(), (x, y) =>
            {
                if (int.TryParse(y, out int res)) { x.Push(y); };

                switch (y)
                {
                    case "+":
                        {
                            var secondTerm = x.Pop();
                            var firstTerm = x.Pop();
                            var operation = Convert.ToInt32(firstTerm) + Convert.ToInt32(secondTerm);
                            x.Push(operation.ToString());
                            break;
                        }
                    case "-":
                        {
                            var secondTerm = x.Pop();
                            var firstTerm = x.Pop();
                            var operation = Convert.ToInt32(firstTerm) - Convert.ToInt32(secondTerm);
                            x.Push(operation.ToString());
                            break;
                        }
                    case "/":
                        {
                            var secondTerm = x.Pop();
                            var firstTerm = x.Pop();
                            var operation = Convert.ToInt32(firstTerm) / Convert.ToInt32(secondTerm);
                            x.Push(operation.ToString());
                            break;
                        }
                    case "*":
                        {
                            var secondTerm = x.Pop();
                            var firstTerm = x.Pop();
                            var operation = Convert.ToInt32(firstTerm) * Convert.ToInt32(secondTerm);
                            x.Push(operation.ToString());
                            break;
                        }
                    case "^":
                        {
                            var secondTerm = x.Pop();
                            var firstTerm = x.Pop();
                            var operation = Math.Pow(Convert.ToInt32(firstTerm), Convert.ToInt32(secondTerm));
                            x.Push(operation.ToString());
                            break;
                        }
                }

                return x;
            });

            return res.Single();
        }
    }
}
