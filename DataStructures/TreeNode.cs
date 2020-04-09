using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataStructures
{
    public class TreeNode<T> : IEnumerable<T>, IComparable<T> where T : IComparable<T>
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
