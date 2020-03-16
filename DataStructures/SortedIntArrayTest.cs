using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataStructures
{
    public class SortedIntArrayTest
    {
        [Fact]
        public void IndexReturnsValidValueForNegativeAndPositiveValues()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(-3);
            sortedIntArray.Add(0);
            sortedIntArray.Add(-1);
            sortedIntArray.Add(4);

            Assert.Equal(-1, sortedIntArray[1]);
        }

        [Fact]
        public void CountIncreasesForCountInsertionIntoArray()
        {
            var sortedIntArray = new SortedIntArray();

            sortedIntArray.Insert(sortedIntArray.Count, 2);

            Assert.Equal(1, sortedIntArray.Count);
        }

        [Fact]
        public void CountStopsIncreasingAfterFirstElementInsertedAtStart()
        {
            var sortedIntArray = new SortedIntArray();

            sortedIntArray.Insert(sortedIntArray.Count, 7);
            sortedIntArray.Insert(0, 9);

            Assert.Equal(1, sortedIntArray.Count);
        }

        [Fact]
        public void CountContinuesAfterValidElementInsertedIntoCount()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Insert(sortedIntArray.Count, 7);
            sortedIntArray.Insert(sortedIntArray.Count, 9);

            Assert.Equal(2, sortedIntArray.Count);
        }

        [Fact]
        public void IndexReturnsValidForInsertionOfIdenticalValue()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(3);
            sortedIntArray.Add(4);
            sortedIntArray.Add(5);
            sortedIntArray.Add(6);

            sortedIntArray.Insert(2, 4);

            Assert.Equal(4, sortedIntArray[2]);
        }


        [Fact]
        public void IndexSkipsInsertForLargeValueAtStartOfArray()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(2);
            sortedIntArray.Add(3);
            sortedIntArray.Add(4);

            sortedIntArray[0] = 10;

            Assert.Equal(2, sortedIntArray[0]);
        }

        [Fact]
        public void AddIncreasesArrayLengthForEqualValue()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(1);
            
            sortedIntArray.Add(1);

            Assert.Equal(1, sortedIntArray[1]);
        }

        [Fact]
        public void AddSkipsForInvalidValue()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(3);
            
            sortedIntArray.Add(1);

            Assert.Equal(3, sortedIntArray[1]);
        }

        [Fact]
        public void IndexInsertsValueIfSortingIsMaintainedWithLowerValue()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(4);
            sortedIntArray.Add(6);
            sortedIntArray.Add(7);

            sortedIntArray[1] = 5;

            Assert.Equal(5, sortedIntArray[1]);
        }

        [Fact]
        public void IndexSkipsInsertValueIfSortingIsNotMaintainedWithLargerValue()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(3);
            sortedIntArray.Add(4);
            sortedIntArray.Add(7);

            sortedIntArray[1] = 10;

            Assert.NotEqual(10, sortedIntArray[1]);
        }

        [Fact]
        public void IndexReturnsProperValueForSortedIntArray()
        {
            var sortedIntArray = new SortedIntArray();

            sortedIntArray.Add(3);
            sortedIntArray.Add(7);
            sortedIntArray.Add(1);

            Assert.Equal(1, sortedIntArray[0]);
        }

        [Fact]
        public void IndexReturnsProperValueForLongerSortedIntArray()
        {
            var sortedIntArray = new SortedIntArray();
            sortedIntArray.Add(4);
            sortedIntArray.Add(2);
            sortedIntArray.Add(1);
            sortedIntArray.Add(7);
            sortedIntArray.Add(0);

            Assert.Equal(4, sortedIntArray[3]);
        }

        [Fact]
        public void IndexReturnsProperValueAfterInsertionOperation()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(8);
            sortedArray.Add(1);

            sortedArray.Insert(1, 6);

            Assert.Equal(6, sortedArray[1]);
        }

        [Fact]
        public void IndexReturnsProperValueAfterInsertionOperationAtStart()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(4);
            sortedArray.Add(1);
            sortedArray.Add(5);

            sortedArray.Insert(0, 0);

            Assert.Equal(0, sortedArray[0]);
        }

        [Fact]
        public void IndexReturnsProperValueAfterInsertionOperationAtEnd()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(4);
            sortedArray.Add(2);
            sortedArray.Add(7);

            sortedArray.Insert(sortedArray.Count, 10);

            Assert.Equal(10, sortedArray[sortedArray.Count - 1]);
        }

        [Fact]
        public void IndexReturnsProperValueAfterInvalidInsertion()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(4);
            sortedArray.Add(6);
            sortedArray.Add(7);

            sortedArray.Insert(1, 9);

            Assert.Equal(6, sortedArray[1]);
        }

        [Fact]
        public void IndexReturnsFalseAfterInvalidInsertionOperation()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(2);
            sortedArray.Add(3);

            sortedArray.Insert(2, 1);

            Assert.Equal(-1, sortedArray[2]);
        }

        [Fact]
        public void IndexReturnsProperValueAfterInvalidSetterOperation()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(2);
            sortedArray.Add(3);
            sortedArray.Add(4);

            sortedArray[1] = 5;

            Assert.NotEqual(5, sortedArray[1]);
        }

        [Fact]
        public void IndexReturnsProperValueAfterValidInsertionOperation()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(2);
            sortedArray.Add(7);
            sortedArray.Add(10);

            sortedArray.Insert(1, 5);
        }

        [Fact]
        public void ContainsMethodReturnsTrueForExpectedSorted()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(10);
            sortedArray.Add(4);

            Assert.True(sortedArray.Contains(10));
        }

        [Fact]
        public void IndexOfReturnsProperValueForSorted()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(10);
            sortedArray.Add(3);
            sortedArray.Add(15);

            Assert.Equal(0, sortedArray.IndexOf(3));
        }

        [Fact]
        public void RemoveWorksAsExpectedForSortedArray()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(4);
            sortedArray.Add(2);
            sortedArray.Add(10);

            sortedArray.Remove(10);

            Assert.Equal(4, sortedArray[1]);
        }

        [Fact]
        public void RemoveAtWorksAsExpectedForSortedArray()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(4);
            sortedArray.Add(1);
            sortedArray.Add(3);

            sortedArray.RemoveAt(1);

            Assert.Equal(4, sortedArray[1]);
        }

        [Fact]
        public void ContainsDoesNotCountExtraZerosOutsideOfArrayBound()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(2);
            sortedArray.Add(7);
            sortedArray.Add(1);

            Assert.False(sortedArray.Contains(0));
        }

        [Fact]
        public void InsertionSkipsIfArrayIndexIsNegative()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(2);
            sortedArray.Add(7);
            sortedArray.Add(1);

            sortedArray.Insert(-4, -3);

            Assert.Equal(3, sortedArray.Count);
        }

        [Fact]
        public void InsertionSkipIfArrayIndexIsOutOfBounds()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(2);
            sortedArray.Add(7);
            sortedArray.Add(1);

            sortedArray.Insert(9, 10);

            Assert.Equal(3, sortedArray.Count);
        }
    }
}