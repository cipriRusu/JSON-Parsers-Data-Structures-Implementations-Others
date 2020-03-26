﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        private TreeNode<T> Root;

        public BinaryTree()
        {
            Root = null;
            Count = 0;
        }

        public bool IsReadOnly => false;

        public int Count { get; private set; }

        public void Add(T item)
        {
            var current = Root;

            if (current == null)
            {
                Root = new TreeNode<T>(item);
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
            if (node.NodeValue.CompareTo(value) > 0)
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
            else
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
            Root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Root;
            return NodeVisit(current).CompareTo(item) == 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Root;
            var count = 0;

            FlattenBinaryTree(current, array, ref count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Root;

            if (current == null)
            {
                yield break;
            }

            yield return current.NodeValue;

            if (current.Left != null)
            {
                yield return NodeVisit(current.Left);
            }

            if (current.Right != null)
            {
                yield return NodeVisit(current.Right);
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item)) return false;

            var current = Root;

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private T NodeVisit(TreeNode<T> input)
        {
            if (input.Left != null)
            {
                return NodeVisit(input.Left);
            }

            if (input.Right != null)
            {
                return NodeVisit(input.Right);
            }

            return input.NodeValue;
        }

        private void FlattenBinaryTree(TreeNode<T> input, T[] array, ref int index)
        {
            if (input.Left != null)
            {
                FlattenBinaryTree(input.Left, array, ref index);
                array[index] = input.Left.NodeValue;
                index++;
            }

            if (input.Right != null)
            {
                FlattenBinaryTree(input.Right, array, ref index);
                array[index] = input.Right.NodeValue;
                index++;
            }

            array[index] = input.NodeValue;
        }

        private class TreeNode<T> : IComparable<T> where T : IComparable<T>
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
        }
    }
}
