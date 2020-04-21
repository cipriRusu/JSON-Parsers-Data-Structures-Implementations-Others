using System;
using System.Collections.Generic;
using System.Linq;
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

        public static Dictionary<string, int> OrderByExtractData(IOrderedEnumerable<KeyValuePair<string, int>> actual)
        {
            var TotalElements = new Dictionary<string, int>();

            foreach(var element in actual)
            {
                TotalElements.Add(element.Key, element.Value);
            }

            return TotalElements;
        }

        internal static string[] ThenByExtractData(IOrderedEnumerable<string> actual)
        {
            var TotalElements = new string[actual.Count()];
            var index = 0;

            foreach(var element in actual)
            {
                TotalElements[index] = element;
                index++;
            }

            return TotalElements;
        }

        internal static TestObject[] ChainedThenByExtractData(IOrderedEnumerable<TestObject> actual)
        {
            var TotalElements = new TestObject[actual.Count()];
            var index = 0;

            foreach(var element in actual)
            {
                TotalElements[index] = element;
                index++;
            }

            return TotalElements;
        }
    }
}
