using System;
using Xunit;

namespace ArrayImplementation
{
    public class ListTest
    {
        [Fact]
        public void ListCreatesEmptyIntegerListWithNoElements()
        {
            var list = new List<int>();

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void ListPopulatesWithNullValue()
        {
            var list = new List<string>();

            list.Add(null);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void ListCreatesEmptyListWithNoElementsString()
        {
            var list = new List<string>();

            Assert.Equal(0, list.Count);
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
        public void ListContainsReturnsValidForPresentElement()
        {
            var list = new List<int>();

            list.Add(4);
            list.Add(2);
            list.Add(9);

            Assert.True(list.Contains(9));
        }

        [Fact]
        public void ListContainsReturnsFalseForAbsentElement()
        {
            var list = new List<int>();

            list.Add(4);
            list.Add(2);

            Assert.False(list.Contains(3));
        }

        [Fact]
        public void ListContainsReturnsMinusOneForEmptyList()
        {
            var list = new List<int>();

            list.Contains(21);

            Assert.False(list.Contains(21));
        }

        [Fact]
        public void ListClearWorksProperly()
        {
            var list = new List<int>();

            list.Add(1);
            list.Add(8);
            list.Add(9);

            list.Clear();

            Assert.Equal(0, list.Count);
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
        public void ListRemoveRemovesIfElementIsPresent()
        {
            var list = new List<int>();
            list.Add(3);
            list.Add(5);
            list.Add(1);

            list.Remove(5);

            Assert.Equal(1, list[1]);
        }
        
        [Fact]
        public void ListRemoveDoesNotChangeIfElementIsNotPresent()
        {
            var list = new List<int>();

            list.Add(3);
            list.Add(8);
            list.Add(2);

            list.Remove(5);

            Assert.Equal(8, list[1]);
        }

        [Fact]
        public void ListRemoveAtRemovesIfIndexIsValid()
        {
            var list = new List<int>();

            list.Add(3);
            list.Add(9);
            list.Add(2);

            list.RemoveAt(1);

            Assert.Equal(2, list[1]);
        }

        [Fact]
        public void ListRemoveAtDoesNotRemoveIfIndexIsOutOfRange()
        {
            var list = new List<int>();

            list.Add(4);
            list.Add(5);
            list.Add(1);

            list.RemoveAt(7);

            Assert.Equal(1, list[2]);
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
    }
}