using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataStructures
{
    public class DictionaryTest
    {
        [Fact]
        public void DictionaryInitializesNewEmptyDictionary()
        {
            var testDict = new Dictionary<int, string>();

            Assert.Empty(testDict);
        }

        [Fact]
        public void DictionaryAddInitializesSingleElementDictionary()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");

            Assert.Single(testDict);
        }

        [Fact]
        public void DictionaryAddInitializezSingleElementDictionaryKVP()
        {
            var testDict = new Dictionary<int, string>(10);

            var kvp = new KeyValuePair<int, string>(1, "a");

            testDict.Add(kvp);

            Assert.Single(testDict);
        }

        [Fact]
        public void DictionaryAddAddsMultipleElementsInDictionary()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");

            Assert.Contains(new KeyValuePair<int, string>(1, "a"), testDict);
            Assert.Contains(new KeyValuePair<int, string>(2, "b"), testDict);
        }

        [Fact]
        public void DictionaryClearEmptiesDictionary()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(3, "first");
            testDict.Add(4, "second");
            testDict.Add(2, "third");

            testDict.Clear();

            Assert.Empty(testDict);
        }

        [Fact]
        public void DictionaryContainsReturnsTrueForPresentKeyValuePair()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");

            Assert.Contains(new KeyValuePair<int, string>(1, "a"), testDict);
        }

        [Fact]
        public void DictionaryContainsREturnsFalseForAbsentPresentKeyValuePair()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(2, "b");

            Assert.DoesNotContain(new KeyValuePair<int, string>(1, "a"), testDict);
        }
    }
}
