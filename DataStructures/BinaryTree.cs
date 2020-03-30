using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public BinaryTree()
        {
            root = null;
            Count = 0;
        }

        public bool IsReadOnly => false;

        public int Count { get; private set; }

        public void Add(T item)
        {
            var current = root;

            if (current == null)
            {
                root = new TreeNode<T>(item);
                Count++;
            }
            else
            {
                AddNode(current, item);
                Count++;
            }
        }

        private void AddNode(TreeNode<T> node, T value)
        {
            if (node.CompareTo(value) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(value);
                }
                else
                {
                    AddNode(node.Left, value);
                }
            }
            else if (node.CompareTo(value) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(value);
                }
                else
                {
                    AddNode(node.Right, value);
                }
            }
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return FindNodeAndParent(item, out _) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = root;
            var count = 0;

            FlattenBinaryTreeToArray(current, array, ref count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var rootNode = root;

            if (rootNode == null)
            {
                yield break;
            }

            yield return rootNode.NodeValue;

            if (rootNode.Left != null)
            {
                foreach (T i in rootNode.Left)
                {
                    yield return i;
                }
            }

            if (rootNode.Right != null)
            {
                foreach (T i in rootNode.Right)
                {
                    yield return i;
                }
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item)) return false;

            var current = FindNodeAndParent(item, out TreeNode<T> parent);

            if (current.Right == null)
            {
                if (parent == null)
                {
                    root = current.Left;
                }
                else
                {
                    var directionindex = current.NodeValue.CompareTo(parent.NodeValue);

                    if (directionindex < 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (directionindex > 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                if (parent == null)
                {
                    root = current.Right;
                }
                else
                {
                    var directionIndex = current.NodeValue.CompareTo(parent.NodeValue);

                    if (directionIndex > 0)
                    {
                        parent.Right = current.Right;
                    }
                    else if (directionIndex < 0)
                    {
                        parent.Left = current.Right;
                    }
                }
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private TreeNode<T> FindNodeAndParent(T value, out TreeNode<T> parent)
        {
            TreeNode<T> current = root;
            parent = null;

            while (current != null)
            {
                int res = current.CompareTo(value);

                if (res > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (res < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void FlattenBinaryTreeToArray(TreeNode<T> input, T[] array, ref int index)
        {
            if (input.Left != null)
            {
                FlattenBinaryTreeToArray(input.Left, array, ref index);
                array[index] = input.Left.NodeValue;
                index++;
            }

            if (input.Right != null)
            {
                FlattenBinaryTreeToArray(input.Right, array, ref index);
                array[index] = input.Right.NodeValue;
                index++;
            }

            array[index] = input.NodeValue;
        }

        private class TreeNode<T> : IEnumerable<T>, IComparable<T> where T : IComparable<T>
        {
            public TreeNode<T> Left;
            public T NodeValue;
            public TreeNode<T> Right;

            public TreeNode(T value = default)
            {
                Left = null;
                Right = null;
                NodeValue = value;
            }

            public int CompareTo([AllowNull] T other)
            {
                return NodeValue.CompareTo(other);
            }

            public IEnumerator<T> GetEnumerator()
            {
                var rootNode = this;

                if (rootNode == null)
                {
                    yield break;
                }

                yield return rootNode.NodeValue;

                if (rootNode.Left != null)
                {
                    foreach (T i in rootNode.Left)
                    {
                        yield return i;
                    }
                }

                if (rootNode.Right != null)
                {
                    foreach (T i in rootNode.Right)
                    {
                        yield return i;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
