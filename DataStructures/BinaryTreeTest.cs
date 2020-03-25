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
    }
}
