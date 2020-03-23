using System;
using System.Collections.Generic;
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
        public void DictionaryResizesAsAdditionExpandsMaximumCapacity()
        {
            var testDict = new Dictionary<int, string>();

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.Contains(1, testDict);
            Assert.Contains(2, testDict);
            Assert.Contains(3, testDict);
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
        public void DictionaryContainsValueReturnsTrueForPresentValueInCollection()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(0, "a");
            testDict.Add(5, "b");

            Assert.True(testDict.ContainsValue("b"));
        }

        [Fact]
        public void DictionaryContainsValueReturnsFalseForAbsentValueInCollection()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(0, "a");
            testDict.Add(1, "b");
            testDict.Add(2, "c");
            testDict.Add(3, "d");

            Assert.False(testDict.ContainsValue("e"));
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
        public void DictionaryCopyToCopiesDictionaryKeyValuePairsIntoExternalArrayFurther()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            var sourceArr = new KeyValuePair<int, string>[testDict.Count];

            testDict.CopyTo(sourceArr, 2);

            testDict.TryGetValue(3, out string output);

            Assert.Equal(sourceArr[2].Value, output);
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

        [Fact]
        public void DictionaryRemoveReturnsFalseForAbsentValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            Assert.False(testDict.Remove(5));
        }

        [Fact]
        public void DictionaryRemoveReturnsTrueForPresentValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            Assert.True(testDict.Remove(3));
        }

        [Fact]
        public void DictionaryRemoveRemovesValueFromDictionary()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            testDict.Remove(2);

            Assert.DoesNotContain(2, testDict);
        }

        [Fact]
        public void DictionaryRemoveRemovesPresentValueFromDictionaryFirstInBucket()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            testDict.Remove(12);

            Assert.Equal(4, testDict.Count);
        }

        [Fact]
        public void DictionaryKeyReturnsAllKeysFromDictionary()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            var keysList = testDict.Keys;

            Assert.True(keysList.Contains(1));
            Assert.True(keysList.Contains(2));
            Assert.True(keysList.Contains(10));
            Assert.True(keysList.Contains(7));
            Assert.True(keysList.Contains(12));
        }

        [Fact]
        public void DictionaryKeyDoesNotReturnAbsentKey()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            var keysList = testDict.Keys;

            Assert.False(keysList.Contains(20));
        }

        [Fact]
        public void DictionaryRemoveRemovesPresentValueFromDictionaryNotFirstInBucket()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            testDict.Remove(7);
            testDict.Remove(1);

            Assert.Equal(3, testDict.Count);
        }

        [Fact]
        public void DictionaryRemoveAndAddReusesPositions()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            testDict.Remove(7);
            testDict.Remove(1);

            testDict.Add(17, "f");
            testDict.Add(19, "g");

            Assert.Contains(2, testDict);
            Assert.Contains(10, testDict);
            Assert.Contains(12, testDict);
            Assert.Contains(17, testDict);
            Assert.Contains(19, testDict);
        }

        [Fact]
        public void RemoveDoesNotRemoveAbsentKeyValuePairForPresentValues()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            testDict.Remove(new KeyValuePair<int, string>(13, "f"));

            Assert.DoesNotContain(new KeyValuePair<int, string>(13, "f"), testDict);
        }

        [Fact]
        public void RemoveReturnsFalseAbsentKeyValuePairForPresentValues()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            Assert.False(testDict.Remove(new KeyValuePair<int, string>(13, "f")));
        }

        [Fact]
        public void RemoveDoesNotRemovePresentKeyValuePairWithDifferentValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            testDict.Remove(new KeyValuePair<int, string>(1, "b"));

            Assert.Contains(new KeyValuePair<int, string>(1, "a"), testDict);
        }

        [Fact]
        public void RemoveReturnsFalseForPresentKeyValuePairWithDifferentValue()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");
            testDict.Add(4, "d");

            Assert.False(testDict.Remove(new KeyValuePair<int, string>(1, "b")));
        }

        [Fact]
        public void RemoveRemovesKeyValuePairOverrideForPresentValues()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            testDict.Remove(new KeyValuePair<int, string>(10, "c"));

            Assert.DoesNotContain(new KeyValuePair<int, string>(10, "c"), testDict);
        }

        [Fact]
        public void RemoveReturnsTrueForKeyValuePairOverrideForPresentValues()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(10, "c");
            testDict.Add(7, "d");
            testDict.Add(12, "e");

            Assert.True(testDict.Remove(new KeyValuePair<int, string>(10, "c")));
        }

        [Fact]
        public void DictionaryAddThrowsArgumentNullExceptionForNullKeyValue()
        {
            var testDict = new Dictionary<string, string>(5);

            Assert.Throws<ArgumentNullException>(()=> testDict.Add(null, "a"));
        }

        [Fact]
        public void DictionaryAddDoesNotThrowArgumentNullExceptionForNullValue()
        {
            var testDict = new Dictionary<string, string>(5);

            testDict.Add("a", null);

            Assert.Contains("a", testDict);
        }

        [Fact]
        public void DictionaryKeyIndexableCtorThrowsArgumentNullExceptionForInvalidIndexGet()
        {
            var testDict = new Dictionary<int, string>();
            testDict.Add(1, "a");

            Assert.Throws<ArgumentException>(() => testDict[3]);
        }

        [Fact]
        public void DictionaryKeyIndexableCtorGetsValidValueForValidGetter()
        {
            var testDict = new Dictionary<int, string>();
            testDict.Add(1, "a");

            Assert.Equal("a", testDict[1]);
        }

        [Fact]
        public void DictionaryKeyIndexableCtorSetsValueForValidSetter()
        {
            var testDict = new Dictionary<int, string>();
            testDict.Add(1, "a");

            testDict[1] = "b";

            Assert.Equal("b", testDict[1]);
        }

        [Fact]
        public void DictionaryKeyIndexableCtorThrowsArgumentNullExceptionForInvalidIndexSetter()
        {
            var testDict = new Dictionary<int, string>();
            testDict.Add(2, "b");

            Assert.Throws<ArgumentException>(()=> testDict[1] = "a");
        }

        [Fact]
        public void DictionaryAddThrowsArgumentExceptionForAlreadyPresentKey()
        {
            var testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");

            Assert.Throws<ArgumentException>(() => testDict.Add(1, "b"));
        }

        [Fact]
        public void DictionaryContainsThrowsArgumentNullExceptionForNullValue()
        {
            var testDict = new Dictionary<string, string>(5);

            testDict.Add("a", "a");

            Assert.Throws<ArgumentNullException>(() => testDict.ContainsKey(null));
        }

        [Fact]
        public void DictionaryRemoveThrowsArgumentNullExceptionForNullValue()
        {
            var testDict = new Dictionary<string, string>(5);

            Assert.Throws<ArgumentNullException>(()=> testDict.Remove(null));
        }

        [Fact]
        public void DictionaryTryGetValueThrowsArgumentNullExceptionForNullValue()
        {
            var testDict = new Dictionary<string, string>(5);

            Assert.Throws<ArgumentNullException>(() => testDict.TryGetValue(null, out string value));
        }
    }
}
