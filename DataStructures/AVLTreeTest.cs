using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataStructures
{
    public class AVLTreeTest
    {
        [Fact]
        public void AVLTreeCreatesEmptyTree()
        {
            var avl = new AVLTree<int>();
            Assert.Empty(avl);
        }

        [Fact]
        public void AVLTreeCountReturnsTrueForNumberOfElement()
        {
            var avl = new AVLTree<int>();
            avl.Add(2);
            avl.Add(1);
            avl.Add(9);

            Assert.Equal(3, avl.Count);
        }

        [Fact]
        public void AVLTreeAddInitiatesLeftRotation()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(2);
            avl.Add(3);

            var expected = new int[] { 1, 2, 3 };
            var actual = new int[avl.Count];

            avl.CopyTo(actual, 0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AVLTreeAddInitiatesRightRotation()
        {
            var avl = new AVLTree<int>();

            avl.Add(3);
            avl.Add(2);
            avl.Add(1);

            var expected = new int[] { 1, 2, 3 };
            var actual = new int[avl.Count];

            avl.CopyTo(actual, 0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AVLTreeAddInitiatesLeftRightRotation()
        {
            var avl = new AVLTree<int>();

            avl.Add(3);
            avl.Add(1);
            avl.Add(2);

            var expected = new int[] { 1, 2, 3 };
            var actual = new int[avl.Count];

            avl.CopyTo(actual, 0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AVLTreeAddInitiatesRightLeftRotation()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(3);
            avl.Add(2);

            var expected = new int[] { 1, 2, 3 };
            var actual = new int[avl.Count];

            avl.CopyTo(actual, 0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AVLTreeAddInitiatesMultipleRotations()
        {
            var avl = new AVLTree<int>();

            avl.Add(2);
            avl.Add(1);
            avl.Add(7);
            avl.Add(15);
            avl.Add(9);
            avl.Add(3);

            var expected = new int[] { 1, 2, 3, 7, 9, 15 };
            var actual = new int[avl.Count];

            avl.CopyTo(actual, 0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AVLTreeClearEmptiesExistingTree()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(10);
            avl.Add(7);

            avl.Clear();

            Assert.Empty(avl);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForExistingElementInTree()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(2);
            avl.Add(7);
            avl.Add(5);

            Assert.Contains(7, avl);
        }

        [Fact]
        public void AVLTreeContainsReturnsFalseForAbsentElementInTree()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(10);
            avl.Add(3);

            Assert.DoesNotContain(7, avl);
        }

        [Fact]
        public void AVLTreeRemoveReturnFalseForAbsentElementInTree()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(2);
            avl.Add(3);

            Assert.False(avl.Remove(7));
        }

        [Fact]
        public void AVLTreeRemoveReturnsTrueForPresentElementInTreeLeafNode()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(2);
            avl.Add(3);

            Assert.True(avl.Remove(3));
        }

        [Fact]
        public void AVLTreeRemoveReturnsValidOutputForMultipleDeletionsAndRotations()
        {
            var avl = new AVLTree<int>();

            avl.Add(2);
            avl.Add(1);
            avl.Add(7);
            avl.Add(12);
            avl.Add(3);
            avl.Add(8);
            avl.Add(9);
            avl.Add(10);
            avl.Add(0);
            avl.Add(4);
            avl.Add(5);

            avl.Remove(4);
            avl.Remove(1);
            avl.Remove(3);

            var expected = new int[] { 0, 2, 5, 7, 8, 9, 10, 12 };
            var actual = new int[avl.Count];

            avl.CopyTo(actual, 0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AVLTreeAddThrowsArgumentExceptionForDuplicateElementAlreadyPresent()
        {
            var avl = new AVLTree<int>();

            avl.Add(2);

            Assert.Throws<ArgumentException>(()=> avl.Add(2));
        }

        [Fact]
        public void AVLTreeCopyToArrayThrowsArgumentNullExceptionForNullInpuArray()
        {
            var avl = new AVLTree<int>();

            avl.Add(2);
            avl.Add(1);

            Assert.Throws<ArgumentNullException>(() => avl.CopyTo(null, 0));
        }

        [Fact]
        public void AvlTreeCopyToArrayThrowsArgumentExceptionForShorterThanCollectionArray()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(2);
            avl.Add(3);
            avl.Add(4);
            avl.Add(5);

            var source = new int[3];

            Assert.Throws<ArgumentException>(() => avl.CopyTo(source, 0));
        }
    }
}