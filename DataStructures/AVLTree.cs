using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    public class AVLTree<T> : ICollection<T> where T : IComparable<T>
    {
        private enum CurrentState
        {
            Balanced,
            RightHeavy,
            LeftHeavy
        }

        private AVLTreeNode<T> root;

        public AVLTree()
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
                root = new AVLTreeNode<T>(null, item);
                Count++;
            }
            else
            {
                AddNode(current, item);
                Count++;
            }
        }

        private void AddNode(AVLTreeNode<T> node, T value)
        {
            if (node.CompareTo(value) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new AVLTreeNode<T>(node, value);
                    node.Left.Balance();
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
                    node.Right = new AVLTreeNode<T>(node, value);
                    node.Right.Balance();
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
            AVLTreeNode<T> parent = null;

            if (!Contains(value))
            {
                return false;
            }

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

        private bool RemoveNode(AVLTreeNode<T> parent, AVLTreeNode<T> current, T value)
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

        private void RemoveLeafNode(AVLTreeNode<T> parent)
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

        private void RemoveNodeWithNoRightNode(AVLTreeNode<T> parent, AVLTreeNode<T> current)
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

        private void RemoveNodeWithNoLeftNodeOnRightChild(AVLTreeNode<T> parent, AVLTreeNode<T> current)
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

        private void RemoveNodeWithLeftNodeOnRightChild(AVLTreeNode<T> parent, AVLTreeNode<T> current)
        {
            AVLTreeNode<T> leftmost, leftmostParent;
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

        private void ParentDirectionReference(AVLTreeNode<T> parent, AVLTreeNode<T> current)
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

        private AVLTreeNode<T> FindNodeAndParent(T value, out AVLTreeNode<T> parent)
        {
            AVLTreeNode<T> current = root;
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

        private void FlattenBinaryTreeToArray(AVLTreeNode<T> input, T[] array, ref int index)
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

        private class AVLTreeNode<T> : IEnumerable<T>, IComparable<T> where T : IComparable<T>
        {
            public AVLTreeNode<T> Left;
            public AVLTreeNode<T> Right;
            public AVLTreeNode<T> Parent;
            public T NodeValue;

            public AVLTreeNode(AVLTreeNode<T> parent, T value = default)
            {
                Left = null;
                Right = null;
                NodeValue = value;
                Parent = parent;
            }

            internal void Balance()
            {
                if (CurrentState == CurrentState.RightHeavy)
                {
                    if (Right != null && Right.BalanceFactor < 0)
                    {
                        LeftRightRotation();
                    }
                    else
                    {
                        LeftRotation();
                    }
                }

                if (CurrentState == CurrentState.LeftHeavy)
                {
                    if (Left != null && Left.BalanceFactor > 0)
                    {
                        RightLeftRotation();
                    }
                    else
                    {
                        RightRotation();
                    }
                }

                if (Parent != null)
                {
                    Parent.Balance();
                }
            }

            private void LeftRightRotation()
            {
                var currentNode = new AVLTreeNode<T>(this, NodeValue);
                NodeValue = Right.Left.NodeValue;
                Left = currentNode;
                Right.Parent = this;
                Right.Left = null;
            }

            private void RightLeftRotation()
            {
                var currentNode = new AVLTreeNode<T>(this, NodeValue);
                NodeValue = Left.Right.NodeValue;
                Right = currentNode;
                Left.Parent = this;
                Left.Right = null;
            }

            private void RightRotation()
            {
                var RightMost = new AVLTreeNode<T>(this, NodeValue);
                NodeValue = Left.NodeValue;
                Right = RightMost;
                Left = Left.Left;
                Left.Parent = this;
                Right.Parent = this;
            }

            private void LeftRotation()
            {

            }

            public int BalanceFactor => RightHeight - LeftHeight;

            public CurrentState CurrentState
            {
                get
                {
                    if (LeftHeight - RightHeight > 1)
                    {
                        return CurrentState.LeftHeavy;
                    }
                    if (RightHeight - LeftHeight > 1)
                    {
                        return CurrentState.RightHeavy;
                    }

                    return CurrentState.Balanced;
                }
            }

            private int LeftHeight => GetMaximumHeight(Left);

            private int RightHeight => GetMaximumHeight(Right);

            private int GetMaximumHeight(AVLTreeNode<T> input)
            {
                if (input != null)
                {
                    return 1 + Math.Max(GetMaximumHeight(input.Left), GetMaximumHeight(input.Right));
                }

                return 0;
            }

            public int CompareTo([AllowNull] T other)
            {
                return NodeValue.CompareTo(other);
            }

            public IEnumerator<T> GetEnumerator()
            {
                var rootNode = this;

                if (rootNode == null) { yield break; }

                foreach (var element in InOrderEnumerator())
                {
                    yield return element;
                }
            }

            public IEnumerable<T> PreOrderEnumerator()
            {
                var rootNode = this;

                if (rootNode == null) { yield break; }

                yield return rootNode.NodeValue;

                if (rootNode.Left != null)
                {
                    foreach (var element in rootNode.Left)
                    {
                        yield return element;
                    }
                }

                if (rootNode.Right != null)
                {
                    foreach (var element in rootNode.Right)
                    {
                        yield return element;
                    }
                }
            }

            public IEnumerable<T> InOrderEnumerator()
            {
                var rootNode = this;

                if (rootNode == null) { yield break; }

                if (rootNode.Left != null)
                {
                    foreach (var element in rootNode.Left)
                    {
                        yield return element;
                    }
                }

                yield return rootNode.NodeValue;

                if (rootNode.Right != null)
                {
                    foreach (var element in rootNode.Right)
                    {
                        yield return element;
                    }
                }
            }

            public IEnumerable<T> PostOrderEnumerator()
            {
                var rootNode = this;

                if (rootNode.Left != null)
                {
                    foreach (var element in rootNode.Left)
                    {
                        yield return element;
                    }
                }

                if (rootNode.Right != null)
                {
                    foreach (var element in rootNode.Right)
                    {
                        yield return element;
                    }
                }

                yield return rootNode.NodeValue;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
