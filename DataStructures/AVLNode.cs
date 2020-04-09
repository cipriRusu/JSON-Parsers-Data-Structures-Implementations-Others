using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    public enum TreeState
    {
        Balanced,
        LeftHeavy,
        RightHeavy
    }

    public class AVLNode<T> : IEnumerable<T>, IComparable<T> where T : IComparable
    {
        public AVLNode(T value, AVLNode<T> parent, AVLTree<T> current)
        {
            Value = value;
            Parent = parent;
            _current = current;
        }

        private AVLTree<T> _current;

        AVLNode<T> _left;
        public AVLNode<T> Left
        {
            get { return _left; }
            internal set
            {
                _left = value;
                if (_left != null)
                {
                    _left.Parent = this;
                }
            }
        }

        AVLNode<T> _right;
        public AVLNode<T> Right
        {
            get { return _right; }
            internal set
            {
                _right = value;
                if (_right != null)
                {
                    _right.Parent = this;
                }
            }
        }

        public AVLNode<T> Parent;
        public T Value;

        public TreeState State
        {
            get
            {
                if (MaximumLeft - MaximumRight > 1)
                {
                    return TreeState.LeftHeavy;
                }
                if (MaximumRight - MaximumLeft > 1)
                {
                    return TreeState.RightHeavy;
                }

                return TreeState.Balanced;
            }
        }

        public int BalanceIndex => MaximumLeft - MaximumRight;
        public int MaximumLeft => GetMaximumLength(Left);
        public int MaximumRight => GetMaximumLength(Right);

        private int GetMaximumLength(AVLNode<T> aVLNode)
        {
            if (aVLNode != null)
            {
                return 1 + Math.Max(GetMaximumLength(aVLNode.Left), GetMaximumLength(aVLNode.Right));
            }

            return 0;
        }

        internal void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceIndex > 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    LeftRotation();
                }
            }
            if (State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceIndex < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    RightRotation();
                }
            }
        }

        private void RightLeftRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }

        private void LeftRightRotation()
        {
            Left.LeftRotation();
            RightRotation();
        }

        private void RightRotation()
        {
            var newNode = Left;
            ReplaceRoot(newNode);
            Left = newNode.Right;
            newNode.Right = this;
        }

        private void LeftRotation()
        {
            var newNode = Right;
            ReplaceRoot(newNode);
            Right = newNode.Left;
            newNode.Left = this;
        }

        public int CompareTo([AllowNull] T other)
        {
            return Value.CompareTo(other);
        }

        private void ReplaceRoot(AVLNode<T> newNode)
        {
            if (Parent != null)
            {
                if (Parent.Left == this)
                {
                    Parent.Left = newNode;
                }
                if (Parent.Right == this)
                {
                    Parent.Right = newNode;
                }
            }
            else
            {
                _current.root = newNode;
                newNode.Parent = Parent;
                Parent = newNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this;

            if (current == null) { yield break; }

            if (current.Left != null)
            {
                foreach (var v in Left)
                {
                    yield return v;
                }
            }

            yield return current.Value;

            if (current.Right != null)
            {
                foreach (var v in Right)
                {
                    yield return v;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
