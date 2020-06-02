using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Functional_LINQ.TestResultsPicker
{
    public class TestResultsPicker
    {
        internal IEnumerable<TestResults> MaximumScorePicker(List<TestResults> inputResults)
            => inputResults.GroupBy(x => x.FamilyId).Select(y => 
            { return y.Aggregate(y.First(), (a, b) => b.Score > y.First().Score ? b : a); });
    }
}