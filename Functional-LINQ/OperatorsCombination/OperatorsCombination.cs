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
            GenerateExpressions(tailValue, targetValue, combinedOperators);
        }

        private static void GenerateExpressions(int tailValue, int targetValue,
            IEnumerable<string> CombinedOperators)
        {
            var res = CombinedOperators
                .Select((stringValue) => stringValue.Zip(Enumerable.Range(1, tailValue), (x, y) =>
              x.ToString() + y)).Where(x => targetValue == x.Aggregate(0, (x, y) => y[0] == '+' ? x + Convert.ToInt32(y.Substring(1)) : x - Convert.ToInt32(y.Substring(1))));
        }

        private static IEnumerable<string> OperatorPermutations(int tailValue)
        {
            return Enumerable.Range(1, tailValue).Aggregate((IEnumerable<string>)new string[] { "" },
                (x, y) => x.SelectMany(r => new string[] { r + "+", r + "-" }));
        }
    }
}