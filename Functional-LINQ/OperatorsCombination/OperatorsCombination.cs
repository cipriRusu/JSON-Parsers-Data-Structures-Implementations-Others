using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Transactions;

namespace Functional_LINQ.OperatorsCombination
{
    public class OperatorsCombination
    {
        public IEnumerable<string> ValidCombinations;

        internal void GenerateOperators(int tailValue, int targetValue)
        {
            IEnumerable<string> Operators = Enumerable.Range(1, tailValue)
                .Aggregate((IEnumerable<string>)new string[] { "" },
                (x, y) => x.SelectMany(r => new string[] { r + "+", r + "-" }));

            IEnumerable<string[]> Expressions = Operators.Select((stringValue) =>
            stringValue.Zip(Enumerable.Range(1, tailValue), (x, y) => x.ToString() + y))
                .Select(x => x.ToArray());

            IEnumerable<int> ValidIndexes = Results(Expressions).Select((x, y) => new { Item = x, Index = y })
                .Where(f => f.Item == targetValue).Select(x => x.Index);

            ValidCombinations =  ValidIndexes.Select(x => Expressions.ElementAt(x))
                .Select(x => x.Aggregate("", (x, y) => x + y) + $" = {targetValue}\n");
        }

        private IEnumerable<int> Results(IEnumerable<string[]> output)
        {
            return output.Select(x => x.Aggregate(0, (x, y) => y[0] == '+' ?
            x + Convert.ToInt32(y.Substring(1)) : x - Convert.ToInt32(y.Substring(1))));
        }
    }
}