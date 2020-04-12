using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class AVLTree<T> : ICollection<T> where T : IComparable
    {
        internal AVLNode<T> root;

        public AVLTree()
        {
            root = null;
            Count = 0;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (FindNode(item, root, out _) != null)
            {
                throw new ArgumentException("Element already present in tree");
            }

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

        private void AddNode(AVLNode<T> node, T item)
        {
            if (node.CompareTo(item) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = new AVLNode<T>(item, node, this);
                }
                else
                {
                    AddNode(node.Right, item);
                }
            }
            else if (node.CompareTo(item) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new AVLNode<T>(item, node, this);
                }
                else
                {
                    AddNode(node.Left, item);
                }
            }

            node.Balance();
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return FindNode(item, root, out _) != null;
        }

        private AVLNode<T> FindNode(T value, AVLNode<T> current, out AVLNode<T> parent)
        {
            parent = null;

            while (current != null)
            {
                if (current.CompareTo(value) == 0)
                {
                    break;
                }
                else if (current.CompareTo(value) < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (current.CompareTo(value) > 0)
                {
                    parent = current;
                    current = current.Left;
                }
            }

            return current;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null)
            {
                throw new ArgumentNullException("Input array is null");
            }

            if(array.Length < Count)
            {
                throw new ArgumentException("Input array length is shorter than total tree Count");
            }

            var startindex = arrayIndex;
            var current = root.GetEnumerator();

            while (current.MoveNext())
            {
                array[startindex] = current.Current;
                startindex++;
            }
        }

        public bool Remove(T item)
        {
            AVLNode<T> parent;

            var current = FindNode(item, root, out parent);

            if (current == null)
            {
                return false;
            }

            AVLNode<T> subTree = current.Parent;

            Count--;

            if (current.Right == null)
            {
                if (current.Parent == null)
                {
                    root = current.Left;

                    if (root != null)
                    {
                        root.Parent = null;
                    }
                }
                else
                {
                    var res = parent.CompareTo(item);

                    if (res > 0)
                    {
                        parent.Left = current.Left;
                    }
                    if (res < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (current.Parent == null)
                {
                    root = current.Left;

                    if (root != null)
                    {
                        root.Parent = null;
                    }
                }
                else
                {
                    var res = parent.CompareTo(item);

                    if (res > 0)
                    {
                        current.Parent.Left = current.Right;
                    }
                    if (res < 0)
                    {
                        current.Parent.Right = current.Right;
                    }
                }
            }
            else
            {
                var leftMost = current.Right.Left;

                while (leftMost.Left != null)
                {
                    leftMost = leftMost.Left;
                }

                leftMost.Parent.Left = leftMost.Right;
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (current.Parent == null)
                {
                    root = leftMost;

                    if (root != null)
                    {
                        root.Parent = null;
                    }
                }
                else
                {
                    int res = current.Parent.CompareTo(current.Value);

                    if (res > 0)
                    {
                        current.Parent.Left = leftMost;
                    }
                    else if (res < 0)
                    {
                        current.Parent.Right = leftMost;
                    }
                }
            }

            if (subTree != null)
            {
                subTree.Balance();
            }
            else
            {
                if (root != null)
                {
                    root.Balance();
                }
            }

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (root == null) yield break;

            var current = root.GetEnumerator();

            while (current.MoveNext())
            {
                yield return current.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
