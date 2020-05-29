using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Functional_LINQ.TestResultsPicker
{
    public class TestResultsPicker
    {
        internal IEnumerable<TestResults> MaximumScorePicker(List<TestResults> inputResults)
        {
            return inputResults
                .GroupBy(result => result.FamilyId)
                    .Select(resultGrouping => resultGrouping.OrderByDescending(n => n.Score))
                .Select(y => y.TakeWhile(n => n.Score == y.First().Score))
                .SelectMany(i => i);
        }
    }
}
