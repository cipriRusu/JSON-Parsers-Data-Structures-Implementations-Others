using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.TestResultsPicker
{
    public class TestResultsPicker
    {
        internal IEnumerable<TestResults> MaximumScorePicker(List<TestResults> inputResults)
        {
            return inputResults
                .GroupBy(result => result.FamilyId)
                    .Select(resultGrouping => resultGrouping.OrderByDescending(subEelement => subEelement.Score))
                        .Select(orderedElement => orderedElement.TakeWhile(subElement => subElement.Score == orderedElement.First().Score))
                .SelectMany(e => e);
        }
    }
}
