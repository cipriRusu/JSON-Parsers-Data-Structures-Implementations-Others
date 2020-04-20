using System;
using System.Collections.Generic;
using System.Text;

namespace Functional_LINQ
{
    class DataExtractionHelper
    {
        public static Dictionary<int, List<string>> GroupByExtractData(IEnumerable<Dictionary<int, List<string>>> actual)
        {
            var TotalElements = new Dictionary<int, List<string>>();

            foreach (var element in actual)
            {
                foreach (var listElement in element)
                {
                    TotalElements.Add(listElement.Key, listElement.Value);
                }
            }

            return TotalElements;
        }
    }
}
