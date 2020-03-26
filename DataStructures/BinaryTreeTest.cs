using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataStructures
{
    public class BinaryTreeTest
    {
        [Fact]
        public void BinaryTreeInitializesEmptyBinaryTree()
        {
            //Null binary tree is a valid, empty binary tree
            var binTree = new BinaryTree<int>();

            Assert.Empty(binTree);
        }

        [Fact]
        public void BinaryTreePopulatesTreeWithSingleElement()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(3);

            Assert.Single(binTree);
        }

        [Fact]
        public void BinaryTreeClearClearsExistentData()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(7);
            binTree.Add(2);
            binTree.Add(10);

            binTree.Clear();

            Assert.Empty(binTree);
        }

        [Fact]
        public void BinaryTreeContainsReturnsTrueForValidRootValue()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(7);
            binTree.Add(2);
            binTree.Add(10);

            Assert.Contains(7, binTree);
        }

        [Fact]
        public void BinaryTreeContainsReturnsTrueForValidLowerThanRootValue()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(7);
            binTree.Add(2);
            binTree.Add(10);

            Assert.Contains(2, binTree);
        }

        [Fact]
        public void BinaryTreeContainsReturnsTrueForValidBiggerThanRootValue()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(7);
            binTree.Add(2);
            binTree.Add(10);

            Assert.Contains(10, binTree);
        }

        [Fact]
        public void BinaryTreeContainsReturnsTrueForPresentValueInThirdLevel()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(3);
            binTree.Add(2);
            binTree.Add(1);

            Assert.Contains(1, binTree);
        }

        [Fact]
        public void BinaryTreeContainsReturnsTrueForPresnetValueNestedInBranch()
        {
            var BinTree = new BinaryTree<int>();

            BinTree.Add(10);
            BinTree.Add(1);
            BinTree.Add(6);
            BinTree.Add(3);

            Assert.Contains(3, BinTree);
        }

        [Fact]
        public void BinaryTreeContainsReturnsFalseForAbsentValueInTree()
        {
            var BinTree = new BinaryTree<int>();

            BinTree.Add(10);
            BinTree.Add(1);
            BinTree.Add(6);
            BinTree.Add(3);

            Assert.DoesNotContain(11, BinTree);
        }

        [Fact]
        public void BinaryTreeCopyToCopiesTreeValuesIntoArray()
        {
            var BinTree = new BinaryTree<int>();

            BinTree.Add(10);
            BinTree.Add(1);
            BinTree.Add(6);
            BinTree.Add(3);

            var sourceArray = new int[BinTree.Count];

            BinTree.CopyTo(sourceArray, 0);

            Assert.Equal(10, sourceArray[BinTree.Count - 1]);
        }

        [Fact]
        public void BinaryTreeCopytoCopiesComplexMultilayeredBinaryTree()
        {
            var BinTree = new BinaryTree<int>();

            BinTree.Add(2);
            BinTree.Add(10);
            BinTree.Add(9);
            BinTree.Add(3);
            BinTree.Add(7);
            BinTree.Add(5);
            BinTree.Add(1);
            BinTree.Add(0);

            var sourceArray = new int[BinTree.Count];

            BinTree.CopyTo(sourceArray, 0);

            Assert.Equal(2, sourceArray[BinTree.Count - 1]);
        }

        [Fact]
        public void BinaryTreeRemoveDoesNotRemoveAbsentValueFromPresentNode()
        {
            var binTree = new BinaryTree<int>();
            binTree.Add(7);
            binTree.Add(2);
            binTree.Add(10);

            Assert.False(binTree.Remove(4));
        }

        [Fact]
        public void BinaryTreeRemoveDeletesFromSingleValidPresentNode()
        {
            var binTree = new BinaryTree<int>();
            binTree.Add(7);
            binTree.Add(2);
            binTree.Add(10);

            Assert.True(binTree.Remove(10));
        }
    }
}
