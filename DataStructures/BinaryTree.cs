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

        public virtual void Add(T item)
        {
            if (Contains(item))
            {
                throw new ArgumentException("Value already present in tree");
            }

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
            ArrayExceptions(array);

            var current = root;
            var count = 0;

            FlattenBinaryTreeToArray(current, array, ref count);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            var current = root;

            if (current == null) { yield break; }

            var currentEnumerator = current.GetEnumerator();

            while (currentEnumerator.MoveNext())
            {
                yield return currentEnumerator.Current;
            }
        }

        public bool Remove(T value)
        {
            var current = root;
            TreeNode<T> parent = null;

            if (!Contains(value)) return false;

            if (current == null)
            {
                return false;
            }
            else
            {
                Count--;
                return RemoveNode(parent, current, value);
            }
        }

        private bool RemoveNode(TreeNode<T> parent, TreeNode<T> current, T value)
        {
            if (current.CompareTo(value) == 0)
            {
                if (current.Left == null && current.Right == null && parent != null)
                {
                    RemoveLeafNode(parent);
                }
                else if (current.Right == null)
                {
                    RemoveNodeWithNoRightNode(parent, current);
                    return true;
                }
                else if (current.Right.Left == null)
                {
                    RemoveNodeWithNoLeftNodeOnRightChild(parent, current);
                    return true;
                }
                else if (current.Right.Left != null)
                {
                    RemoveNodeWithLeftNodeOnRightChild(parent, current);
                    return true;
                }
            }

            else if (current.NodeValue.CompareTo(value) < 0)
            {
                RemoveNode(current, current.Right, value);
            }
            else if (current.NodeValue.CompareTo(value) > 0)
            {
                RemoveNode(current, current.Left, value);
            }

            return false;
        }

        private void RemoveLeafNode(TreeNode<T> parent)
        {
            if (parent.Right == null)
            {
                parent.Left = null;
            }
            else
            {
                parent.Right = null;
            }
        }

        private void RemoveNodeWithNoRightNode(TreeNode<T> parent, TreeNode<T> current)
        {
            if (parent == null)
            {
                root = current.Left;
            }
            else
            {
                ParentDirectionReference(parent, current);
            }
        }

        private void RemoveNodeWithNoLeftNodeOnRightChild(TreeNode<T> parent, TreeNode<T> current)
        {
            current.Right.Left = current.Left;

            if (parent == null)
            {
                root = current.Right;
            }
            else
            {
                ParentDirectionReference(parent, current);
            }
        }

        private void RemoveNodeWithLeftNodeOnRightChild(TreeNode<T> parent, TreeNode<T> current)
        {
            TreeNode<T> leftmost, leftmostParent;
            leftmostParent = current.Right;
            leftmost = current.Right.Left;

            while (leftmost.Left != null)
            {
                leftmostParent = leftmost;
                leftmost = leftmost.Left;
            }

            leftmostParent.Left = leftmost.Right;

            leftmost.Left = current.Left;
            leftmost.Right = current.Right;

            ParentDirectionReference(parent, current);
        }

        private void ParentDirectionReference(TreeNode<T> parent, TreeNode<T> current)
        {
            if (parent.Left == current)
            {
                parent.Left = current.Right;
            }
            else
            {
                parent.Right = current.Right;
            }
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

        private void ArrayExceptions(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array value is null");
            }

            if (array.Length < Count)
            {
                throw new ArgumentException("Source array length is shorter than number of elements");
            }
        }
    }
}
