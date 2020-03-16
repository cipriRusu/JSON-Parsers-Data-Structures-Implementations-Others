using System;
using Xunit;

namespace DataStructures
{
    public class SortedListTest
    {
        [Fact]
        public void SortedListCreatesEmptyList()
        {
            var sortedList = new SortedList<int>();

            Assert.Empty(sortedList);
        }

        [Fact]
        public void SortedListInsertStopsInsertingOnCountAfterFirstElementAdded()
        {
            var sortedList = new SortedList<int>();

            sortedList.Insert(sortedList.Count, 7);
            sortedList.Insert(0, 9);

            Assert.Single(sortedList);
        }

        [Fact]
        public void SortedListInsertStopsInsertingOnCountAfterFirstStringElementAdded()
        {
            var sortedList = new SortedList<string>();

            sortedList.Insert(sortedList.Count, "daw");
            sortedList.Insert(0, "jii");

            Assert.Single(sortedList);
        }

        [Fact]
        public void SortedListReturnsValidValueForNegativeAndPositiveValues()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(-3);
            sortedList.Add(0);
            sortedList.Add(-1);
            sortedList.Add(4);

            Assert.Equal(-1, sortedList[1]);
        }

        [Fact]
        public void SortedListInsertInsertsElementOnCount()
        {
            var sortedList = new SortedList<int>();

            sortedList.Insert(sortedList.Count, 2);

            Assert.Single(sortedList);
        }

        [Fact]
        public void SortedListInsertInsertsStringElementOnCount()
        {
            var sortedList = new SortedList<string>();

            sortedList.Insert(sortedList.Count, "something");

            Assert.Single(sortedList);
        }

        [Fact]
        public void SortedListInsertsSortedElementsInList()
        {
            var sortedList = new SortedList<int>();

            sortedList.Add(4);
            sortedList.Add(5);

            Assert.Equal(2, sortedList.Count);
        }

        [Fact]
        public void SortedListInsertsSortedStringElementsInList()
        {
            var sortedList = new SortedList<string>();

            sortedList.Add("abc");
            sortedList.Add("bcd");

            Assert.Equal(2, sortedList.Count);
        }

        [Fact]
        public void SortedListReturnsValidValueForInsertedIndenticalValue()
        {
            var sortedList = new SortedList<int>();

            sortedList.Add(3);
            sortedList.Add(4);
            sortedList.Add(5);
            sortedList.Add(6);

            sortedList.Insert(2, 4);

            Assert.Equal(4, sortedList[2]);
        }

        [Fact]
        public void SortedListReturnsValidValueForInsertedIndenticalStringValue()
        {
            var sortedList = new SortedList<string>();

            sortedList.Add("abbah");
            sortedList.Add("babbbah");
            sortedList.Add("caddadha");
            sortedList.Add("daaddah");

            sortedList.Insert(2, "babbbah");

            Assert.Equal("babbbah", sortedList[2]);
        }

        [Fact]
        public void SortedListCountContinuesAfterValidElementInsertedIntoCountIndex()
        {
            var sortedList = new SortedList<int>();
            sortedList.Insert(sortedList.Count, 7);
            sortedList.Insert(sortedList.Count, 9);

            Assert.Equal(2, sortedList.Count);
        }

        [Fact]
        public void SortedListCountContinuesAfterValidStringElementInsertedIntoCountIndex()
        {
            var sortedList = new SortedList<string>();
            sortedList.Insert(sortedList.Count, "defg");
            sortedList.Insert(sortedList.Count, "gabc");

            Assert.Equal(2, sortedList.Count);
        }
        
        [Fact]
        public void SortedListIndexSkipsInsertForLargeValueAtStartOfArray()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(2);
            sortedList.Add(3);
            sortedList.Add(4);

            sortedList[0] = 10;

            Assert.Equal(2, sortedList[0]);
        }

        [Fact]
        public void SortedListIndexSkipsInsertForUnalphabeticalValueAtStartOfArray()
        {
            var sortedList = new SortedList<string>();

            sortedList.Add("apa");
            sortedList.Add("bere");
            sortedList.Add("coniac");

            sortedList[0] = "tuica";

            Assert.Equal("apa", sortedList[0]);
        }

        [Fact]
        public void SortedListAddIncreasesArrayLengthForEqualValue()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(1);
            sortedList.Add(1);

            Assert.Equal(1, sortedList[1]);
        }

        [Fact]
        public void SortedListAddSkipsForInvalidValue()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(3);

            sortedList.Add(1);

            Assert.Equal(3, sortedList[1]);
        }

        [Fact]
        public void SortedListIndexInsertsValueIfSortingIsMaintainedWithLowerValue()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(4);
            sortedList.Add(6);
            sortedList.Add(7);

            sortedList[1] = 5;

            Assert.Equal(5, sortedList[1]);
        }

        [Fact]
        public void SortedListIndexSkipsInsertValueIfSortingIsNotMaintainedWithLargerValue()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(3);
            sortedList.Add(4);
            sortedList.Add(7);

            sortedList[1] = 10;

            Assert.NotEqual(10, sortedList[1]);
        }

        [Fact]
        public void SortedListIndexReturnsProperValueAfterInsertionOperation()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(8);
            sortedList.Add(1);

            sortedList.Insert(1, 6);

            Assert.Equal(6, sortedList[1]);
        }

        [Fact]
        public void SortedListIndexReturnsProperValueAfterInsertionOperationAtStart()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(4);
            sortedList.Add(1);
            sortedList.Add(5);

            sortedList.Insert(0, 0);

            Assert.Equal(0, sortedList[0]);
        }

        [Fact]
        public void SortedListIndexReturnsProperValueAfterInsertionOperationAtEnd()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(4);
            sortedList.Add(2);
            sortedList.Add(7);

            sortedList.Insert(sortedList.Count, 10);

            Assert.Equal(10, sortedList[sortedList.Count - 1]);
        }

        [Fact]
        public void SortedListIndexReturnsProperValueAfterInvalidInsertion()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(4);
            sortedList.Add(6);
            sortedList.Add(7);

            sortedList.Insert(1, 9);

            Assert.Equal(6, sortedList[1]);
        }

        [Fact]
        public void SortedListIndexReturnsProperValueAfterInvalidSetterOperation()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(2);
            sortedList.Add(3);
            sortedList.Add(4);

            sortedList[1] = 5;

            Assert.NotEqual(5, sortedList[1]);
        }

        [Fact]
        public void SortedListContainsMethodReturnsTrueForExpectedSorted()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(1);
            sortedList.Add(10);
            sortedList.Add(4);

            Assert.Contains(10, sortedList);
        }

        [Fact]
        public void SortedListIndexOfReturnsProperValueForSorted()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(10);
            sortedList.Add(3);
            sortedList.Add(15);

            Assert.Equal(0, sortedList.IndexOf(3));
        }

        [Fact]
        public void SortedListRemoveAtWorksAsExpectedForSortedArray()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(4);
            sortedList.Add(1);
            sortedList.Add(3);

            sortedList.RemoveAt(1);

            Assert.Equal(4, sortedList[1]);
        }

        [Fact]
        public void SortedListContainsDoesNotCountExtraZerosOutsideOfArrayBound()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(2);
            sortedList.Add(7);
            sortedList.Add(1);

            Assert.DoesNotContain(0, sortedList);
        }

        [Fact]
        public void SortedListInsertionSkipsIfArrayIndexIsNegative()
        {
            var sortedList = new SortedList<int>();
            sortedList.Add(2);
            sortedList.Add(7);
            sortedList.Add(1);

            sortedList.Insert(-4, -3);

            Assert.Equal(3, sortedList.Count);
        }

        [Fact]
        public void SortedListInsertionSkipsIfArrayIndexIsOutOfBounds()
        {
            var sortedList = new SortedIntArray();
            sortedList.Add(2);
            sortedList.Add(7);
            sortedList.Add(1);

            sortedList.Insert(9, 10);

            Assert.Equal(3, sortedList.Count);
        }
    }
}
