using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataStructures
{
    public class AVLTreeTest
    {
        [Fact]
        public void AVLTreeInitializesEmptyAVLTree()
        {
            var avl = new AVLTree<int>();

            Assert.Empty(avl);
        }

        [Fact]
        public void AVLTreePopulatesWithSingleElement()
        {
            var avl = new AVLTree<int>();

            avl.Add(3);

            Assert.Single(avl);
        }

        [Fact]
        public void AVLTreeAddWorksForRightHeavyTree()
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
        public void AVLTreeAddWorksForLeftHeavyTree()
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
        public void AVLTreeAddWorksForLeftHeavyTreeUnbalancedLeftChild()
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
        public void AVLTreeAddWorksForRightHeavyTreeUnbalancedRightChild()
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
        public void AVLTreeCopytoWorksForSmallLengthArray()
        {
            var avl = new AVLTree<int>();

            avl.Add(1);
            avl.Add(3);
            avl.Add(2);

            var actual = new int[avl.Count];
            var expected = new int[] { 1, 2, 3 };

            avl.CopyTo(actual, 0);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void AVLTreeCopyToWorksForMultipleRotationsArray()
        {
            var avl = new AVLTree<int>();

            avl.Add(2);
            avl.Add(8);
            avl.Add(6);
            avl.Add(4);
            avl.Add(10);
            avl.Add(7);
            avl.Add(9);
            avl.Add(5);
            avl.Add(3);
            avl.Add(11);
            avl.Add(15);

            var actual = new int[avl.Count];
            var expected = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 15 };

            avl.CopyTo(actual, 0);

            Assert.Equal(expected, actual);
        }
    }
}