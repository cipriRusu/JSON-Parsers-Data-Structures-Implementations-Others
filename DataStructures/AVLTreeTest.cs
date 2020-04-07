using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataStructures
{
    public class AVLTreeTest
    {
        [Fact]
        public void AVLTreeInitializesEmptyTree()
        {
            var avlTree = new AVLTree<int>();

            Assert.Empty(avlTree);
        }

        [Fact]
        public void AVLTreePopulatesWithSingleElement()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(3);

            Assert.Single(avlTree);
        }

        [Fact]
        public void AVLTreeClearClearsExistentData()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(7);
            avlTree.Add(2);
            avlTree.Add(10);

            avlTree.Clear();

            Assert.Empty(avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForValidRootValue()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(7);
            avlTree.Add(2);
            avlTree.Add(10);

            Assert.Contains(7, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForValidLowerThanRootValue()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(7);
            avlTree.Add(2);
            avlTree.Add(10);

            Assert.Contains(2, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForValidBiggerThanRootValue()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(7);
            avlTree.Add(2);
            avlTree.Add(10);

            Assert.Contains(10, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForPresentValueInUnbalancedTree()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(3);
            avlTree.Add(2);
            avlTree.Add(1);

            Assert.Contains(1, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnTrueForPresenValuesAfterLeftRotation()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(1);
            avlTree.Add(2);
            avlTree.Add(3);

            Assert.Contains(1, avlTree);
            Assert.Contains(2, avlTree);
            Assert.Contains(3, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForPresentValuesAfterLeftRotationDeeper()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(1);
            avlTree.Add(3);
            avlTree.Add(4);
            avlTree.Add(2);

            Assert.Contains(1, avlTree);
            Assert.Contains(3, avlTree);
            Assert.Contains(4, avlTree);
            Assert.Contains(2, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnTrueForPresentValuesAfterRightRotation()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(3);
            avlTree.Add(2);
            avlTree.Add(1);

            Assert.Contains(1, avlTree);
            Assert.Contains(2, avlTree);
            Assert.Contains(3, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnTrueForPresentValuesAfterRightRotationDeeper()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(4);
            avlTree.Add(2);
            avlTree.Add(1);
            avlTree.Add(3);

            Assert.Contains(4, avlTree);
            Assert.Contains(2, avlTree);
            Assert.Contains(1, avlTree);
            Assert.Contains(3, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForPresentValuesAfterRightLeftRotation()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(3);
            avlTree.Add(1);
            avlTree.Add(2);

            Assert.Contains(3, avlTree);
            Assert.Contains(1, avlTree);
            Assert.Contains(2, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForPresentValuesAfterLeftRightRotation()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(1);
            avlTree.Add(3);
            avlTree.Add(2);

            Assert.Contains(1, avlTree);
            Assert.Contains(3, avlTree);
            Assert.Contains(2, avlTree);
        }

        [Fact]
        public void AVLTreeContainsReturnsTrueForPresentValuesAfterAllRotations()
        {
            var avlTree = new AVLTree<int>();

            avlTree.Add(2);
            avlTree.Add(1);
            avlTree.Add(7);
            avlTree.Add(5);
            avlTree.Add(4);
            avlTree.Add(10);
            avlTree.Add(15);
            avlTree.Add(23);
            avlTree.Add(20);
        }
    }
}