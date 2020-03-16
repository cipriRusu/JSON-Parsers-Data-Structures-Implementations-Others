using System;
using Xunit;

namespace DataStructures
{
    public class IntArrayTest
    {
        [Fact]
        public void ElementReturnsProperValueForGivenIndex()
        {
            var testArray = new IntArray();
            testArray.Add(4);
            testArray.Add(7);
            testArray.Add(9);
            testArray.Add(2);
            testArray.Add(5);

            Assert.Equal(9, testArray[2]);
        }

        [Fact]
        public void ElementReturnsMinusOneIfGivenIndexNotPresent()
        {
            var testArray = new IntArray();
            testArray.Add(4);
            testArray.Add(7);
            testArray.Add(9);
            testArray.Add(2);
            testArray.Add(5);

            Assert.Equal(-1, testArray[9]);
        }


        [Fact]
        public void SetElementModifiesValueOfElement()
        {
            var testArray = new IntArray();
            testArray.Add(4);
            testArray.Add(7);
            testArray.Add(9);
            testArray.Add(2);
            testArray.Add(5);

            testArray[2] = 21;

            Assert.Equal(21, testArray[2]);
        }

        [Fact]
        public void ContainsReturnsTrueIfElementIsPresent()
        {
            var testArray = new IntArray();
            testArray.Add(4);
            testArray.Add(7);
            testArray.Add(9);
            testArray.Add(2);
            testArray.Add(5);

            Assert.True(testArray.Contains(2));
        }

        [Fact]
        public void ContainsReturnsFalseIfElementIsAbsent()
        {
            var testArray = new IntArray();
            testArray.Add(4);
            testArray.Add(7);
            testArray.Add(9);
            testArray.Add(2);
            testArray.Add(5);

            Assert.False(testArray.Contains(32));
        }

        [Fact]
        public void IndexOfReturnsProperIndexValueForPresentElement()
        {
            var testArray = new IntArray();
            testArray.Add(4);
            testArray.Add(7);
            testArray.Add(9);
            testArray.Add(2);
            testArray.Add(5);

            Assert.Equal(2, testArray.IndexOf(9));
        }

        [Fact]
        public void InsertReplacesElementWithNewValue()
        {
            var testArray = new IntArray();
            testArray.Add(4);
            testArray.Add(7);
            testArray.Add(9);
            testArray.Add(2);
            testArray.Add(5);

            testArray.Insert(3, 21);

            Assert.Equal(21, testArray[3]);
        }

        [Fact]
        public void ClearRemovesAllElementsFromArray()
        {
            var testArray = new IntArray();
            testArray.Add(4);
            testArray.Add(7);
            testArray.Add(9);
            testArray.Add(2);
            testArray.Add(5);
            testArray.Add(9);

            testArray.Clear();

            Assert.False(testArray.Contains(4));
            Assert.False(testArray.Contains(7));
        }

        [Fact]
        public void RemoveRemovesFirstOccuringElement()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);
            testArray.Add(6);

            testArray.Remove(4);

            Assert.Equal(5, testArray[3]);
            Assert.Equal(-1, testArray[5]);
        }

        [Fact]
        public void RemoveAtRemovesPresentValue()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(4);
            testArray.Add(6);
            testArray.Add(8);
            testArray.Add(10);
            testArray.Add(12);

            testArray.RemoveAt(3);

            Assert.Equal(10, testArray[3]);
        }

        [Fact]
        public void CountPropertyReturnsProperCountValue()
        {
            var testArray = new IntArray();
            testArray.Add(1);

            Assert.Equal(1, testArray.Count);
        }

        [Fact]
        public void IndexerPropertyReturnsProperValueForValidIndex()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(4);

            Assert.Equal(4, testArray[1]);
        }

        [Fact]
        public void IndexerPropertySetsProperValueToArrayIndex()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray[0] = 4;

            Assert.Equal(4, testArray[0]);
        }
    }
}
