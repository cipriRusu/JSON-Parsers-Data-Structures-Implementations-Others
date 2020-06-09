using System.Collections;
using System.Linq;
using System.Text;

namespace Functional_LINQ.PolishNotationEvaluator
{
    public class PolishNotationEvaluator
    {
        public int PolishNotationExpressionEvaluator(string expression) =>
            expression.Split(' ').Aggregate(Enumerable.Empty<int>(), (x, y) =>
                int.TryParse(y, out int res) ? x.Append(res) :
                x.SkipLast(2).Append(x.TakeLast(2).Operate(y))).Single();
    }
}