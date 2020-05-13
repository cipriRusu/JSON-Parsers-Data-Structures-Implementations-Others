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
            IEnumerable<string> CombinedOperators = OperatorPermutations(tailValue);
            IEnumerable<string[]> Expressions = GenerateExpressions(tailValue, CombinedOperators);
            IEnumerable<int> ValidIndexes = IdentifyValidIndexPositions(targetValue, Expressions);

            ValidCombinations = ValidIndexes.Select(x => Expressions.ElementAt(x))
                .Select(x => x.Aggregate("", (x, y) => x + y) + $" = {targetValue}\n");
        }

        private IEnumerable<int> IdentifyValidIndexPositions(int targetValue, IEnumerable<string[]> Expressions)
        {
            return ComputeExpressionResults(Expressions).Select((x, y) =>
            new { Item = x, Index = y }).Where(f => f.Item == targetValue).Select(x => x.Index);
        }

        private static IEnumerable<string[]> GenerateExpressions(int tailValue, IEnumerable<string> CombinedOperators)
        {
            return CombinedOperators.Select((stringValue) => 
            stringValue.Zip(Enumerable.Range(1, tailValue), (x, y) => x.ToString() + y)).Select(x => x.ToArray());
        }

        private static IEnumerable<string> OperatorPermutations(int tailValue)
        {
            return Enumerable.Range(1, tailValue).Aggregate((IEnumerable<string>)new string[] { "" },
                (currentCombination, y) => currentCombination.SelectMany(r => new string[] { r + "+", r + "-" }));
        }

        private IEnumerable<int> ComputeExpressionResults(IEnumerable<string[]> output)
        {
            return output.Select(x => x.Aggregate(0, (x, y) => y[0] == '+' ?
            x + Convert.ToInt32(y.Substring(1)) : x - Convert.ToInt32(y.Substring(1))));
        }
    }
}