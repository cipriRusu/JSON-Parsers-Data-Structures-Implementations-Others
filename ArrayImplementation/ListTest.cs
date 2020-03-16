using System;
using Xunit;

namespace DataStructures
{
    public class ListTest
    {
        [Fact]
        public void ListCreatesEmptyIntegerListWithNoElements()
        {
            var list = new List<int>();

            Assert.Empty(list);
        }

        [Fact]
        public void ListPopulatesWithNullValue()
        {
            var list = new List<string>();

            list.Add(null);

            Assert.Single(list);
        }

        [Fact]
        public void ListCreatesEmptyListWithNoElementsString()
        {
            var list = new List<string>();

            Assert.Empty(list);
        }

        [Fact]
        public void ListCreatesEmptyListNoElementsIndexer()
        {
            var list = new List<int>();

            list[0] = -1;

            Assert.Equal(-1, list[0]);
        }

        [Fact]
        public void ListIndexerPopulatesWithMultipleValues()
        {
            var list = new List<int>();

            list[0] = 21;
            list[1] = 4;

            Assert.Equal(21, list[0]);
            Assert.Equal(4, list[1]);
        }

        [Fact]
        public void ListIndexerPopulatsWithMultipleStringValues()
        {
            var list = new List<string>();

            list[0] = "first";
            list[1] = "second";

            Assert.Equal("first", list[0]);
            Assert.Equal("second", list[1]);
        }

        [Fact]
        public void ListAddValueAddsSingleValue()
        {
            var list = new List<int>();

            list.Add(21);

            Assert.Equal(21, list[0]);
        }

        [Fact]
        public void ListAddValueAddsSingleStringValue()
        {
            var list = new List<string>();

            list.Add("something");

            Assert.Equal("something", list[0]);
        }

        [Fact]
        public void ListAddValueAddsMultipleValues()
        {
            var list = new List<int>();

            list.Add(21);
            list.Add(30);

            Assert.Equal(30, list[1]);
        }

        [Fact]
        public void ListCopyToCopiesWholeListInsideArray()
        {
            var list = new List<int>();
            list.Add(4);
            list.Add(21);
            list.Add(12);
            list.Add(3);

            var sourceArray = new int[list.Count];
            list.CopyTo(sourceArray, 0);

            Assert.Equal(4, sourceArray[0]);
        }

        [Fact]
        public void ListCopyToCopiesWholeList()
        {
            var list = new List<int>();
            list.Add(4);
            list.Add(21);
            list.Add(6);

            var sourceArray = new int[20];

            list.CopyTo(sourceArray, 4);

            Assert.Equal(0, sourceArray[0]);
            Assert.Equal(4, sourceArray[4]);

        }

        [Fact]
        public void ListContainsReturnsValidForPresentElement()
        {
            var list = new List<int>();

            list.Add(4);
            list.Add(2);
            list.Add(9);

            Assert.Contains(9, list);
        }

        [Fact]
        public void ListContainsReturnsFalseForAbsentElement()
        {
            var list = new List<int>();

            list.Add(4);
            list.Add(2);

            Assert.DoesNotContain(3, list);
        }

        [Fact]
        public void ListContainsReturnsMinusOneForEmptyList()
        {
            var list = new List<int>();

            list.Contains(21);

            Assert.DoesNotContain(21, list);
        }

        [Fact]
        public void ListClearWorksProperly()
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(8);
            list.Add(9);

            list.Clear();

            Assert.Empty(list);
        }

        [Fact]
        public void ListIndexOfReturnsIndexOfBetweenMultipleElements()
        {
            var list = new List<int>();

            list.Add(2);
            list.Add(24);
            list.Add(3);

            Assert.Equal(2, list.IndexOf(3));
        }

        [Fact]
        public void ListIndexOfReturnsMinusForAbsentElement()
        {
            var list = new List<int>();

            list.Add(4);
            list.Add(8);
            list.Add(1);

            Assert.Equal(-1, list.IndexOf(9));
        }

        [Fact]
        public void ListEnumeratorReturnsFirstElement()
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();

            Assert.Equal(1, enumerator.Current);
        }

        [Fact]
        public void ListRemoveReturnsTrueForPresentItem()
        {
            var list = new List<int>();

            list.Add(4);
            list.Add(7);
            list.Add(2);

            Assert.True(list.Remove(2));
        }

        [Fact]
        public void ListRemoveReturnsFalseForAbsentItem()
        {
            var list = new List<int>();

            list.Add(4);
            list.Add(7);
            list.Add(2);

            Assert.False(list.Remove(3));
        }

        [Fact]
        public void ListRemoveRemovesElementFromList()
        {
            var list = new List<int>() { 2, 3, 4, 1 };

            list.Remove(3);

            Assert.DoesNotContain(3, list);
        }

        [Fact]
        public void ListRemoveDoesNotChangeListIfElementIsNotPresent()
        {
            var list = new List<int>() { 2, 4, 8, 2, 0 };

            list.Remove(7);

            Assert.Equal(5, list.Count);
        }

        [Fact]
        public void ListRemovAeAtRemovesIfIndexIsValid()
        {
            var list = new List<int>();

            list.Add(3);
            list.Add(9);
            list.Add(2);

            list.RemoveAt(1);

            Assert.Equal(2, list[1]);
        }

        [Fact]
        public void ListEnumeratorReturnsTrueForFurtherElementsAhead()
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();

            Assert.True(enumerator.MoveNext());
        }

        [Fact]
        public void ListEnumeratorReturnsFalseForEndOfList()
        {
            var list = new List<int> { 1, 2, 3 };

            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.MoveNext();

            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void CopyingToNullArrayThrowsArgumentNullException()
        {
            var list = new List<int>() { 2, 3, 4 };

            Assert.Throws<NullReferenceException>(() => list.CopyTo(null, 4));
        }

        [Fact]
        public void CopyToArrayInvalidIndexThrowsArgumentOutOfRangeException()
        {
            var list = new List<int> { 3, 4, 5 };

            var sourceArray = new int[list.Count];

            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(sourceArray, -4));
        }

        [Fact]
        public void CopyToArrayShortedLengthThrowsArgumentException()
        {
            var list = new List<int> { 4, 7, 8 };

            var sourceArray = new int[2];

            Assert.Throws<ArgumentException>(() => list.CopyTo(sourceArray, 1));
        }

        [Fact]
        public void InsertIndexOutRangeThrowsArgumentOutOfRangeExceptionOverLength()
        {
            var list = new List<int> { 3, 5, 1 };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(9, 6));
        }

        [Fact]
        public void InsertIndexOutOfRangeThrowsArgumentOutOfRangeExceptionIndexUnderLength()
        {
            var list = new List<int> { 3, 4, 6, 1 };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-2, 3));
        }

        [Fact]
        public void RemoveAtOutOfRangeIndexThrowsArgumentOutOfRangeException()
        {
            var list = new List<int> { 4, 6, 1 };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(8));
        }

        [Fact]
        public void RemoveAtOutOfRangeIndexThrowsArgumentOurOfRangeExceptionForNegativeIndex()
        {
            var list = new List<int> { 4, 1, 4, 6 };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-4));
        }
    }
}