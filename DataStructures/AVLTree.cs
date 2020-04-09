using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    public class AVLTree<T> : ICollection<T> where T : IComparable
    {
        public AVLTree()
        {
            root = null;
            Count = 0;
        }

        internal AVLNode<T> root;
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (root == null)
            {
                Count++;
                root = new AVLNode<T>(item, null, this);
            }
            else
            {
                Count++;
                AddNode(root, item);
            }
        }

        private void AddNode(AVLNode<T> aVLNode, T item)
        {
            if (aVLNode.CompareTo(item) < 0)
            {
                if (aVLNode.Right == null)
                {
                    aVLNode.Right = new AVLNode<T>(item, aVLNode, this);
                }
                else
                {
                    AddNode(aVLNode.Right, item);
                }
            }
            else if (aVLNode.CompareTo(item) > 0)
            {
                if (aVLNode.Left == null)
                {
                    aVLNode.Left = new AVLNode<T>(item, aVLNode, this);
                }
                else
                {
                    AddNode(aVLNode.Left, item);
                }
            }

            aVLNode.Balance();
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return FindItem(root, item);
        }

        private bool FindItem(AVLNode<T> node, T item)
        {
            if (node.CompareTo(item) == 0)
            {
                return true;
            }
            if (node.CompareTo(item) < 0)
            {
                FindItem(node.Right, item);
            }
            else if (node.CompareTo(item) > 0)
            {
                FindItem(node.Left, item);
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var currentValues = GetEnumerator();
            var startIndex = 0;

            while (currentValues.MoveNext())
            {
                array[startIndex] = currentValues.Current;
                startIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal(this);
        }

        private IEnumerator<T> InOrderTraversal(AVLTree<T> input)
        {
            if (input.root == null) { yield break; }

            var current = input.root.GetEnumerator();

            while(current.MoveNext())
            {
                yield return current.Current;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
