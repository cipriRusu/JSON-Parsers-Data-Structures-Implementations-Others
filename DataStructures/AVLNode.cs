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
        public T Value;
        private AVLNode<T> _left;
        public AVLNode<T> Left
        {
            get
            {
                return _left;
            }
            internal set
            {
                _left = value;

                if(_left != null)
                {
                    _left.Parent = this;
                }
            }
        }

        private AVLNode<T> _right;
        public AVLNode<T> Right
        {
            get
            {
                return _right;
            }
            internal set
            {
                _right = value;

                if(_right != null)
                {
                    _right.Parent = this;
                }
            }
        }
        public AVLNode<T> Parent;
        private AVLTree<T> _tree;

        public AVLNode(T value, AVLNode<T> parent, AVLTree<T> current)
        {
            Parent = parent;
            Value = value;
            _tree = current;
        }

        public int BalanceFactor => LeftLength - RightLength;

        public TreeState State
        {
            get
            {
                if (LeftLength - RightLength > 1)
                {
                    return TreeState.LeftHeavy;
                }
                if (RightLength - LeftLength > 1)
                {
                    return TreeState.RightHeavy;
                }

                return TreeState.Balanced;
            }
        }

        public int LeftLength => GetMaximumLength(Left);

        public int RightLength => GetMaximumLength(Right);

        private int GetMaximumLength(AVLNode<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(GetMaximumLength(node.Right), GetMaximumLength(node.Left));
            }

            return 0;
        }

        internal void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceFactor > 0)
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
                if (Left != null && Left.BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    RightRotation();
                }
            }
        }

        private void RightRotation()
        {
            var newRoot = Left;
            ReplaceRoot(newRoot);
            Left = newRoot.Right;
            newRoot.Right = this;
        }

        private void LeftRightRotation()
        {
            Left.LeftRotation();
            RightRotation();
        }

        private void LeftRotation()
        {
            var newRoot = Right;
            ReplaceRoot(newRoot);
            Right = newRoot.Left;
            newRoot.Left = this;
        }

        private void RightLeftRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }

        private void ReplaceRoot(AVLNode<T> newRoot)
        {
            if (Parent != null)
            {
                if (Parent.Right == this)
                {
                    Parent.Right = newRoot;
                }
                if (Parent.Left == this)
                {
                    Parent.Left = newRoot;
                }
            }
            else
            {
                _tree.root = newRoot;
                newRoot.Parent = Parent;
                Parent = newRoot;
            }
        }

        public int CompareTo([AllowNull] T other)
        {
            return Value.CompareTo(other);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this == null) yield break;

            if (Left != null)
            {
                foreach (var v in Left)
                {
                    yield return v;
                }
            }

            yield return Value;

            if (Right != null)
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
