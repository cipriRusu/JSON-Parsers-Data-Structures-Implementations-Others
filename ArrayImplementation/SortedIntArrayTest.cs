using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayImplementation
{
    public class SortedIntArrayTest
    {
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
        public void IndexReturnsProperVAlueAfterInsertionOperation()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(8);
            sortedArray.Add(1);

            sortedArray.Insert(1, 10);

            Assert.Equal(10, sortedArray[2]);
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
        public void IndexOfReturnProperValueForSorted()
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
    }
}
