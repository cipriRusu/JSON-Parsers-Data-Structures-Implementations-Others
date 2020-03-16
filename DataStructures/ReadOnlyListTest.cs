using System;
using Xunit;

namespace DataStructures
{
    public class ReadOnlyListTest
    {
        [Fact]
        public void ReadOnlyListAddMethodThrowsNotSupportedException()
        {
            List<int> list = new List<int> { 4, 5, 10, 4, 10 };

            Assert.Throws<NotSupportedException>(() => new ReadOnlyList<int>(list).Add(3));
        }

        [Fact]
        public void ReadOnlyListClearMethodThrowsNotSupportedException()
        {

            ReadOnlyList<int> roList = new ReadOnlyList<int>(new List<int> { 12, 5, 8 });

            Assert.Throws<NotSupportedException>(() => roList.Clear());
        }

        [Fact]
        public void ReadOnlyListContainsReturnsTrueForValidPresentValue()
        {
            ReadOnlyList<int> roList = new ReadOnlyList<int>(new List<int> { 3, 4, 5 });

            Assert.Contains(4, roList);
        }

        [Fact]
        public void ReadOnlyListContainsReturnsFalseForAbsentValue()
        {
            ReadOnlyList<int> roList = new ReadOnlyList<int>(new List<int> { 4, 5, 18 });

            Assert.DoesNotContain(20, roList);
        }

        [Fact]
        public void ReadOnlyListCopyToCopiesElementsToAnExternalArrayProperly()
        {

            ReadOnlyList<int> roList = new ReadOnlyList<int>(new List<int> { 4, 1, 10 });

            int[] externalArray = new int[new List<int> { 4, 1, 10 }.Count];

            roList.CopyTo(externalArray, 0);

            Assert.Equal(4, externalArray[0]);
        }

        [Fact]
        public void ReadOnlyListInsertMethodThrowsNotSupportedException()
        {

            ReadOnlyList<int> roList = new ReadOnlyList<int>(new List<int> { 4, 5, 10 });

            Assert.Throws<NotSupportedException>(() => roList.Insert(1, 4));
        }

        [Fact]
        public void ReadOnlyListRemoveMethodThrowsNotSupportedException()
        {
            ReadOnlyList<int> roList = new ReadOnlyList<int>(new List<int> { 5, 1, 10 });

            Assert.Throws<NotSupportedException>(() => roList.Remove(1));
        }

        [Fact]
        public void ReadOnlyListRemoveAtMethodThrowsNotSupportedException()
        {
            ReadOnlyList<int> roList = new ReadOnlyList<int>(new List<int> { 3, 4, 10, 91 });

            Assert.Throws<NotSupportedException>(() => roList.RemoveAt(3));
        }

        [Fact]
        public void ReadOnlyListGetterReturnsProperValue()
        {
            ReadOnlyList<int> roList = new ReadOnlyList<int>(new List<int> { 3, 4, 10, 2 });

            Assert.Equal(3, roList[0]);
        }
    }
}
