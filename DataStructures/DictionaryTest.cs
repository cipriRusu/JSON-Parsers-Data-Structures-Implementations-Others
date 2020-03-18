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
        public void DictionaryAddInitializesMultipleElementsIntoSameBucket()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(2, "a");
            testDict.Add(7, "b");

            Assert.Contains(new KeyValuePair<int, string>(2, "a"), testDict);
            Assert.Contains(new KeyValuePair<int, string>(7, "b"), testDict);
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

        [Fact]
        public void DictionaryContainsReturnsTrueForPresentKeyValuePairInCollision()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(0, "a");
            testDict.Add(5, "b");

            testDict.Contains(new KeyValuePair<int, string>(5, "b"));
        }

        [Fact]
        public void DictionaryKeysReturnsAllKeysList()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            var resList = new List<int>() { 1, 2, 3, 4 };

            Assert.Equal(testDict.Keys, resList);
        }

        [Fact]
        public void DictionaryValuesReturnsAllValuesList()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            var resList = new List<string>() { "a", "b", "c", "d" };

            Assert.Equal(testDict.Values, resList);
        }

        [Fact]
        public void DictionaryTvaluePropertyGetterReturnsTkeyValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            Assert.Equal("b", testDict[2]);
        }

        [Fact]
        public void DictionaryTKeySetterPropertySetsAppropriateValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            testDict[4] = "x";

            Assert.Equal("x", testDict[4]);
        }

        [Fact]
        public void DictionaryContainsKeyReturnsTrueForValidExistingKey()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            Assert.True(testDict.ContainsKey(2));
        }

        [Fact]
        public void DictionaryContainsKeyReturnsFalseForAbsentKey()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            Assert.False(testDict.ContainsKey(5));
        }

        [Fact]
        public void DictionaryCopyToCopiesDictionaryKeyValuePairsIntoExternalArray()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            var sourceArr = new KeyValuePair<int, string>[testDict.Count];

            testDict.CopyTo(sourceArr, 0);

            testDict.TryGetValue(1, out string output);

            Assert.Equal(sourceArr[0].Value, output);
        }

        [Fact]
        public void DictionaryTryGetValueReturnsTrueForPresentValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            Assert.True(testDict.TryGetValue(2, out string output));
        }

        [Fact]
        public void DictionaryTryGetValueReturnsFalseForAbsentValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            Assert.False(testDict.TryGetValue(5, out string output));
        }

        [Fact]
        public void DictionaryTryGetValueReturnsValidOutputValueForPresentValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            testDict.TryGetValue(1, out string output);

            Assert.Equal("a", output);
        }

        [Fact]
        public void DictionaryTryGetValueReturnsNullValueForAbsentReferenceType()
        {
            var testDict = new Dictionary<string, string>(5);

            testDict.Add("a", "1");
            testDict.Add("b", "2");
            testDict.Add("c", "3");
            testDict.Add("d", "4");

            testDict.TryGetValue("e", out string output);

            Assert.Null(output);
        }

        [Fact]
        public void DictionaryTryGetValueReturnsNullValueForAbsentValueType()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            testDict.TryGetValue(5, out string output);

            Assert.Null(output);
        }
    }
}
