using System.Collections;
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
            return expression.Split(' ').Aggregate(Enumerable.Empty<int>(), (x, y) =>
            {
                x = int.TryParse(y, out int res) ?
                x.Append(res) :
                x.SkipLast(2).Append(x.TakeLast(2).Operate(y));

                return x;

            }).Single();
        }
    }
}