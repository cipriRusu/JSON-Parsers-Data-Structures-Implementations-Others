using System;
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
            return FindNodeAndParent(item, out _) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Root;
            var count = 0;

            FlattenBinaryTreeToArray(current, array, ref count);
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
                yield return NodeTraversal(current.Left);
            }

            if (current.Right != null)
            {
                yield return NodeTraversal(current.Right);
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item)) return false;

            TreeNode<T> current, parent;

            current = FindNodeAndParent(item, out parent);

            //Removal Node has no right node
            if (current.Right == null)
            {
                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    var getIndex = parent.NodeValue.CompareTo(item);

                    if (getIndex < 0)
                    {
                        parent.Right = current.Left;
                    }
                    else if (getIndex > 0)
                    {
                        parent.Left = current.Left;
                    }
                }
            }

            //Removal Node's Right child has no left child
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if(parent == null)
                {
                    Root = current.Right;
                }

                else
                {
                    var getIndex = parent.NodeValue.CompareTo(item);

                    if(getIndex < 0)
                    {
                        parent.Right = current.Right;
                    }
                    else if(getIndex > 0)
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

        private T NodeTraversal(TreeNode<T> input)
        {
            if (input.Left != null)
            {
                return NodeTraversal(input.Left);
            }

            if (input.Right != null)
            {
                return NodeTraversal(input.Right);
            }

            return input.NodeValue;
        }

        private TreeNode<T> FindNodeAndParent(T value, out TreeNode<T> parent)
        {
            TreeNode<T> current = Root;
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
