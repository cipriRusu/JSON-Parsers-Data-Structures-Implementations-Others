using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructures
{
    public class LinkedListTest
    {
        [Fact]
        public void LinkedListInitializesEmptyLinkedList()
        {
            var lList = new LinkedList<int>();
            Assert.Empty(lList);
        }

        [Fact]
        public void LinkedListPopulatesWithSingleElement()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);

            Assert.Single(lList);
        }

        [Fact]
        public void LinkedListPopulatesWithMultipleElements()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(7);
            lList.Add(9);

            Assert.Equal(3, lList.Count);
        }

        [Fact]
        public void LinkedListCopyToCopiesValuesToSourceArray()
        {
            var lList = new LinkedList<int>();
            lList.Add(4);
            lList.Add(2);
            lList.Add(7);

            var sourceArray = new int[lList.Count];

            lList.CopyTo(sourceArray, 0);

            Assert.Equal(4, sourceArray[0]);
            Assert.Equal(7, sourceArray[2]);
        }

        [Fact]
        public void LinkedListRemoveRemovesElementFromLinkedList()
        {
            var lList = new LinkedList<int>();
            lList.Add(4);
            lList.Add(2);
            lList.Add(7);

            lList.Remove(2);

            Assert.DoesNotContain(2, lList);
        }

        [Fact]
        public void AddAfterAcceptsNullValueForReferenceType()
        {
            var lList = new LinkedList<string>();

            lList.Add(null);

            Assert.Single(lList);
        }

        [Fact]
        public void AddAfterAcceptsDuplicateValue()
        {
            var lList = new LinkedList<int>();

            lList.Add(2);
            lList.Add(2);

            Assert.Equal(2, lList.Count);
        }

        [Fact]
        public void LinkedListAddAfterAddsSpecifiedNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(1);
            lList.Add(4);
            lList.Add(10);

            var nodeToInsert = new Node<int>(20);

            lList.AddAfter(lList.Find(4), nodeToInsert);

            Assert.Contains(20, lList);
        }

        [Fact]
        public void LinkedListAddBeforeAddsSpecifiedNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(9);
            lList.Add(20);

            var nodeToInsert = new Node<int>(30);

            lList.AddBefore(lList.Find(9), nodeToInsert);

            Assert.Contains(30, lList);
        }

        [Fact]
        public void LinkedListAddAfterAddsValueAfterSpecifiedNodeAndValue()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(2);
            lList.Add(9);

            var valueToAdd = 21;

            lList.AddAfter(lList.Find(2), valueToAdd);

            Assert.Contains(21, lList);
        }

        [Fact]
        public void LinkedListAddBeforeAddsNodeBeforeSpecifiedExistingNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(2);
            lList.Add(9);

            var nodeToAdd = new Node<int>(12);

            lList.AddBefore(lList.Find(2), nodeToAdd);

            Assert.Contains(12, lList);
        }

        [Fact]
        public void LinkedListAddBeforeAddsValueBeforeSpecifiedExistingNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(9);
            lList.Add(12);
            lList.Add(3);

            var valueToAdd = 21;

            lList.AddBefore(lList.Find(12), valueToAdd);
        }

        [Fact]
        public void LinkedListAddFirstInsertsElementAtStartOfList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(2);
            lList.Add(7);

            lList.AddFirst(9);

            Assert.Contains(9, lList);
        }

        [Fact]
        public void LinkedListAddFirstNodeInsertElementAtStartOfList()
        {
            var lList = new LinkedList<int>();

            lList.Add(2);
            lList.Add(12);
            lList.Add(0);

            var nodeToInsert = new Node<int>(8);

            lList.AddFirst(nodeToInsert);

            Assert.Contains(8, lList);
        }

        [Fact]
        public void LinkedListAddLastInsertsElementAtEndOfList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(2);
            lList.Add(7);

            lList.AddLast(9);

            Assert.Contains(9, lList);
        }

        [Fact]
        public void LinkedListAddLastNodeInsertsElementAtEndOfList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(2);
            lList.Add(7);

            var newNode = new Node<int>(9);

            lList.AddLast(newNode);
        }

        [Fact]
        public void LinkedListClearRemovesAllElementsFromList()
        {
            var lList = new LinkedList<int>();

            lList.Clear();

            Assert.Empty(lList);
        }

        [Fact]
        public void LinkedListClearFirstIsSetToNull()
        {
            var lList = new LinkedList<int>();

            lList.Add(9);
            lList.Add(11);
            lList.Add(20);

            lList.Clear();

            Assert.Null(lList.First);
        }

        [Fact]
        public void LinkedListClearLastSetToNull()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(10);
            lList.Add(8);

            lList.Clear();

            Assert.Null(lList.Last);
        }

        [Fact]
        public void LinkedListContainsWorksProperlyForPresentIntegerValue()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(10);
            lList.Add(21);

            Assert.Contains(10, lList);
        }

        [Fact]
        public void LinkedListContainsWorksProperlyforAbsentIntegerValue()
        {
            var lList = new LinkedList<int>();
            lList.Add(1);
            lList.Add(4);
            lList.Add(5);

            Assert.DoesNotContain(10, lList);
        }

        [Fact]
        public void LinkedListContainsWorksProperlyForNullValueInReferenceType()
        {
            var lList = new LinkedList<string>();
            lList.Add("first");
            lList.Add(null);
            lList.Add("second");

            Assert.Contains(null, lList);
        }

        [Fact]
        public void LinkedListFindReturnsValidPresentNode()
        {
            var lList = new LinkedList<int>();
            lList.Add(7);
            lList.Add(2);
            lList.Add(9);

            Assert.Equal(lList.First, lList.Find(7));
        }

        [Fact]
        public void LinkedListFindReturnsNullForAbsentNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(2);
            lList.Add(10);

            lList.Remove(4);

            Assert.NotEqual(lList.First, lList.Find(4));
        }

        [Fact]
        public void LinkedListFindLastReturnsLastNodeContainingSpecifiedValue()
        {
            var lList = new LinkedList<int>();

            lList.Add(5);
            lList.Add(12);
            lList.Add(3);
            lList.Add(5);
            lList.Add(2);

            var found = lList.FindLast(5);

            Assert.Equal(2, found.Next.data);
        }

        [Fact]
        public void LinkedListRemoveRemovesNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(21);
            lList.Add(9);

            lList.Remove(lList.Find(3));

            Assert.Null(lList.Find(3));
        }

        [Fact]
        public void LinkedListReturnsTrueForPresentInput()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(10);
            lList.Add(7);

            Assert.True(lList.Remove(4));
        }

        [Fact]
        public void LinkedListRemoveReturnsFalseForAbsentInput()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(10);
            lList.Add(7);

            Assert.False(lList.Remove(2));
        }

        [Fact]
        public void LinkedListRemoveFirstMethodRemovesFirstNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(2);
            lList.Add(9);
            lList.Add(10);

            lList.RemoveFirst();

            Assert.DoesNotContain(2, lList);
        }

        [Fact]
        public void LinkedListRemoveLastMethodRemovesLastNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(3);
            lList.Add(12);

            lList.RemoveLast();

            Assert.DoesNotContain(12, lList);
        }

        [Fact]
        public void AddAfterReturnsArgumentNullExceptionForNullAddItionNode()
        {
            var lList = new LinkedList<int>();

            Assert.Throws<ArgumentNullException>(() => lList.AddAfter(null, 4));
        }

        [Fact]
        public void AddAfterReturnsArgumentNullExceptionForNullInsertionNodeSecondOverride()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(12);
            lList.Add(2);

            Assert.Throws<ArgumentNullException>(()=> lList.AddAfter(null, 2));
        }

        [Fact]
        public void AddAfterReturnsArgumentNullExceptionForNullNewNodeSecondOverride()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(12);
            lList.Add(2);

            Assert.Throws<ArgumentNullException>(() => lList.AddAfter(lList.Find(12), null));
        }

        [Fact]
        public void AddAfterReturnsInvalidOperationExceptionForNodeNotInCurrentList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(3);
            lList.Add(7);

            var secondList = new LinkedList<int>();

            secondList.Add(4);
            secondList.Add(3);
            secondList.Add(7);

            Assert.Throws<InvalidOperationException>(() => lList.AddAfter(secondList.First, 3));
        }

        [Fact]
        public void AddAfterReturnsInvalidOperationExceptionForNewNodeBelongingToAnotherList()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(2);
            lList.Add(8);

            var secondList = new LinkedList<int>();

            secondList.Add(2);
            secondList.Add(9);
            secondList.Add(7);

            Assert.Throws<InvalidOperationException>(() => lList.AddAfter(lList.First, secondList.First));
        }

        [Fact]
        public void AddBeforeReturnsArgumentNullExceptionForNullInsertionNode()
        {
            var lList = new LinkedList<int>();

            lList.Add(2);
            lList.Add(3);
            lList.Add(12);

            Assert.Throws<ArgumentNullException>(()=> lList.AddBefore(null, 4));
        }

        [Fact]
        public void AddBeforeReturnsInvalidOperationExceptionIfAdditionNodeIsNotPresent()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(12);
            lList.Add(6);

            var secondList = new LinkedList<int>();

            secondList.Add(1);
            secondList.Add(2);
            secondList.Add(3);

            Assert.Throws<InvalidOperationException>(()=> lList.AddBefore(secondList.First, 5));
        }

        [Fact]
        public void AddBeforeReturnsArgumentNullExceptionIfAdditionNodeIsNullSecondOverride()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(2);
            lList.Add(10);

            Assert.Throws<ArgumentNullException>(()=> lList.AddBefore(null, new Node<int>(8)));
        }

        [Fact]
        public void AddBeforeReturnsArgumentNullExceptionIfNewNodeIsNull()
        {
            var lList = new LinkedList<int>();

            lList.Add(5);
            lList.Add(10);
            lList.Add(9);

            Assert.Throws<ArgumentNullException>(() => lList.AddBefore(lList.First, null));
        }

        [Fact]
        public void AddBeforeReturnsInvalidOperationExceptionIfAdditionNodeIsNotInCurrentList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(1);
            lList.Add(9);

            var secondList = new LinkedList<int>();

            secondList.Add(1);
            secondList.Add(2);
            secondList.Add(3);

            Assert.Throws<InvalidOperationException>(()=> lList.AddBefore(secondList.First, 4));
        }

        [Fact]
        public void AddBeforeReturnsInvalidOperationExceptionIfNewNodeIsInAnotherList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(1);
            lList.Add(9);

            var secondList = new LinkedList<int>();

            secondList.Add(1);
            secondList.Add(2);
            secondList.Add(3);

            Assert.Throws<InvalidOperationException>(()=> lList.AddBefore(lList.Find(1), secondList.First));
        }

        [Fact]
        public void AddFirstReturnsArgumentNullExceptionIfAdditionNodeIsNull()
        {
            var lList = new LinkedList<int>();

            lList.Add(3);
            lList.Add(2);
            lList.Add(7);

            Assert.Throws<ArgumentNullException>(()=> lList.AddFirst(null));
        }

        [Fact]
        public void AddFirstReturnsInvalidOperationExceptionIfNodeBelongsToAnotherList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(3);
            lList.Add(10);

            var secList = new LinkedList<int>();

            secList.Add(1);
            secList.Add(2);
            secList.Add(3);

            Assert.Throws<InvalidOperationException>(()=> lList.AddFirst(secList.First));
        }

        [Fact]
        public void AddLastReturnsArgumentNullExceptionsForNullNodeValue()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(12);
            lList.Add(5);

            Assert.Throws<ArgumentNullException>(()=> lList.AddLast(null));
        }

        [Fact]
        public void AddLastReturnsInvalidOperationExceptionForNodeInAnotherList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(15);
            lList.Add(0);

            var secList = new LinkedList<int>();

            secList.Add(4);
            secList.Add(15);
            secList.Add(0);

            Assert.Throws<InvalidOperationException>(()=> lList.AddLast(secList.First));
        }

        [Fact]
        public void CopyToMethodReturnsArgumentNullExceptionForNullArray()
        {
            var lList = new LinkedList<int>();

            lList.Add(2);
            lList.Add(10);
            lList.Add(3);

            Assert.Throws<ArgumentNullException>(()=> lList.CopyTo(null, 0));
        }

        [Fact]
        public void CopyToMethodReturnsArgumentOutOfRangeExceptionForInvalidIndexValue()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(12);
            lList.Add(3);

            var sourceArr = new int[lList.Count];

            Assert.Throws<ArgumentOutOfRangeException>(()=> lList.CopyTo(sourceArr, -3));
        }

        [Fact]
        public void CopyToMethodReturnsArgumentExceptionForListHavingMoreElementsThanArrayLength()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(3);
            lList.Add(1);
            lList.Add(8);

            var sourceArr = new int[3];

            Assert.Throws<ArgumentException>(()=> lList.CopyTo(sourceArr, 0));
        }

        [Fact]
        public void RemoveMethodThrowsArgumentExceptionIfNodeValueIsNull()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(2);
            lList.Add(1);
            lList.Add(9);

            Assert.Throws<ArgumentNullException>(()=> lList.Remove(null));
        }

        [Fact]
        public void RemoveMethodThrowsInvalidOperationExceptionIfNodeIsNotPresentInList()
        {
            var lList = new LinkedList<int>();

            lList.Add(4);
            lList.Add(2);
            lList.Add(1);
            lList.Add(9);

            Assert.Throws<InvalidOperationException>(() => lList.Remove(new Node<int>(10)));
        }

        [Fact]
        public void RemoveFirstReturnsInvalidOperationExceptionForEmptyList()
        {
            var lList = new LinkedList<int>();

            Assert.Throws<InvalidOperationException>(() => lList.RemoveFirst());
        }

        [Fact]
        public void RemoveLastReturnsInvalidOperationExceptionForEmptyList()
        {
            var lList = new LinkedList<int>();

            Assert.Throws<InvalidOperationException>(()=> lList.RemoveLast());
        }
    }
}
