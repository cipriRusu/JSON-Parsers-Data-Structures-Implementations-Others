using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.OperatorsCombination
{
    public class OperatorsCombination
    {
        public IEnumerable<string> ValidCombinations;

        internal void GenerateOperators(int tailValue, int targetValue)
        {
            IEnumerable<string> combinedOperators = OperatorPermutations(tailValue);
            ValidCombinations = ValidExpressions(tailValue, targetValue, combinedOperators);
        }

        private static IEnumerable<string> ValidExpressions(int tailValue, int targetValue,
            IEnumerable<string> CombinedOperators)
        {
            return GenerateExpressions(tailValue, CombinedOperators)
                .Where(x => CheckExpression(targetValue, x))
                .Select(x => ConcatenateExpression(targetValue, x));
        }

        private static IEnumerable<IEnumerable<string>> GenerateExpressions(int tailValue,
            IEnumerable<string> CombinedOperators)
        {
            return CombinedOperators.Select((stringValue) =>
            stringValue.Zip(Enumerable.Range(1, tailValue), (x, y) => x.ToString() + y));
        }

        private static string ConcatenateExpression(int targetValue, IEnumerable<string> x) =>
            x.Aggregate("", (a, b) => a + b) + $" = {targetValue}\n";

        private static bool CheckExpression(int targetValue, IEnumerable<string> x) =>
            targetValue ==
                x.Aggregate(0, (x, y) => y[0] == '+' ?
                x + Convert.ToInt32(y.Substring(1)) :
                x - Convert.ToInt32(y.Substring(1)));

        private static IEnumerable<string> OperatorPermutations(int tailValue) =>
            Enumerable.Range(1, tailValue)
                .Aggregate((IEnumerable<string>)new string[] { "" },
                (x, y) => x.SelectMany(r => new string[] { r + "+", r + "-" }));
    }
}