using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class LinkedList<T> : ICollection<T>
    {
        private readonly Node<T> sentinel;

        public LinkedList()
        {
            sentinel = new Node<T>(default);
            sentinel.Previous = sentinel;
            sentinel.Next = sentinel;

            Count = 0;
        }

        public Node<T> First => Count == 0 ? null : sentinel.Next;

        public Node<T> Last => Count == 0 ? null : sentinel.Previous;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddBefore(sentinel, new Node<T>(item));
        }

        public void AddFirst(T item)
        {
            AddBefore(sentinel.Next, new Node<T>(item));
        }

        public void AddFirst(Node<T> nodeToInsert)
        {
            AddBefore(sentinel.Next, nodeToInsert);
        }

        public void AddLast(T item)
        {
            AddBefore(sentinel, new Node<T>(item));
        }

        public void AddLast(Node<T> nodeToInsert)
        {
            AddBefore(sentinel, nodeToInsert);
        }

        public void AddAfter(Node<T> listNode, Node<T> newNode)
        {
            FirstAndSecondNodesExceptions(listNode, newNode);

            AddBefore(listNode.Next, newNode);
        }

        public void AddAfter(Node<T> listNode, T item)
        {
            NodeAdditionAndListPresenceException(listNode);

            AddBefore(listNode.Next, new Node<T>(item));
        }

        public void AddBefore(Node<T> listNode, T item)
        {
            NodeAdditionAndListPresenceException(listNode);

            AddBefore(listNode, new Node<T>(item));
        }

        public void AddBefore(Node<T> listNode, Node<T> newNode)
        {
            FirstAndSecondNodesExceptions(listNode, newNode);

            listNode.Previous.Next = newNode;
            newNode.Previous = listNode.Previous;
            newNode.Next = listNode;
            listNode.Previous = newNode;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CopyToExceptions(array, arrayIndex);

            IEnumerable<Node<T>> current = GetAllNodes();
            int counter = 0;

            foreach (Node<T> i in current)
            {
                array[counter] = i.data;
                counter++;
            }
        }

        public Node<T> Find(T item)
        {
            return SearchNodes(item, GetAllNodes());
        }

        public Node<T> FindLast(T item)
        {
            return SearchNodes(item, GetAllNodesReverse());
        }

        private Node<T> SearchNodes(T searchItem, IEnumerable<Node<T>> nodeEnumerable)
        {
            foreach (Node<T> currentNode in nodeEnumerable)
            {
                if (IsNodeValueNull(currentNode, searchItem) ||
                    currentNode.data.Equals(searchItem))
                {
                    return currentNode;
                }
            }

            return null;
        }

        public bool Remove(T item)
        {
            return NodeRemove(Find(item));
        }

        public void Remove(Node<T> nodeToRemove)
        {
            NodeAdditionAndListPresenceException(nodeToRemove);

            NodeRemove(FindNode(nodeToRemove));
        }

        public void RemoveFirst()
        {
            InvalidOperationForEmptyList();
            Remove(First);
        }

        public void RemoveLast()
        {
            InvalidOperationForEmptyList();
            Remove(Last);
        }

        private Node<T> FindNode(Node<T> nodeToFind)
        {
            foreach (var node in GetAllNodes())
            {
                if (node == nodeToFind)
                {
                    return node;
                }
            }

            return null;
        }

        private bool NodeRemove(Node<T> item)
        {
            if (item == null) { return false; }

            item.Next.Previous = item.Previous;
            item.Previous.Next = item.Next;
            Count--;
            return true;
        }

        private void FirstAndSecondNodesExceptions(Node<T> listNode, Node<T> newNode)
        {
            NodeValueNullException(listNode);
            NodeValueNullException(newNode);
            NodeLinkException(newNode);
        }

        private void NodeAdditionAndListPresenceException(Node<T> listNode)
        {
            NodeValueNullException(listNode);
            NodeNotPresentInListException(listNode);
        }

        private void CopyToExceptions(T[] array, int arrayIndex)
        {
            ArrayNullException(array);
            NegativeIndexException(arrayIndex);
            CountArrayException(array);
        }

        private bool IsNodeValueNull(Node<T> currentNode, T searchItem)
        {
            return currentNode.data == null && searchItem == null;
        }

        private void NodeLinkException(Node<T> newNode)
        {
            if (newNode.Next != null || newNode.Previous != null)
            { throw new InvalidOperationException("Node already belongs to another LinkedList"); }
        }

        private void NodeNotPresentInListException(Node<T> listNode)
        {
            if (FindNode(listNode) == null)
            { throw new InvalidOperationException("Node does not exist in current LinkedList"); }
        }

        private void NodeValueNullException(Node<T> listNode)
        {
            if (listNode == null)
            { throw new ArgumentNullException("Node value is null"); }
        }

        private static void ArrayNullException(T[] array)
        {
            if (array == null)
            { throw new ArgumentNullException("Array value is null"); }
        }

        private static void NegativeIndexException(int arrayIndex)
        {
            if (arrayIndex < 0)
            { throw new ArgumentOutOfRangeException("Array index is a negative value"); }
        }

        private void CountArrayException(T[] array)
        {
            if (Count > array.Length)
            { throw new ArgumentException("Number of list elements is greater than array length"); }
        }

        private void InvalidOperationForEmptyList()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is Empty");
            }
        }

        private IEnumerable<Node<T>> GetAllNodes()
        {
            for (Node<T> i = sentinel.Next; i != sentinel; i = i.Next)
            {
                yield return i;
            }
        }

        private IEnumerable<Node<T>> GetAllNodesReverse()
        {
            for (Node<T> i = sentinel.Previous; i != sentinel; i = i.Previous)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = sentinel.Next;

            while (current != sentinel)
            {
                yield return current.data;
                current = current.Next;
            }
        }
    }
}
