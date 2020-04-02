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
        public void BinaryTreeCopyToCopiesSimpleTreeValuesIntoArray()
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
        public void BinaryTreeRemoveDoesNotRemovesAbsentValueFromPresentNode()
        {
            var binTree = new BinaryTree<int>();
            binTree.Add(7);
            binTree.Add(2);
            binTree.Add(10);

            Assert.False(binTree.Remove(4));
        }

        [Fact]
        public void BinaryTreeRemoveDeletesRootNode()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(4);
            binTree.Remove(4);

            Assert.Empty(binTree);
        }

        [Fact]
        public void BinaryTreeRemoveWorksForNoRightChildInDeletionNodeRightBranchOfMainTree()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(4);
            binTree.Add(2);
            binTree.Add(1);
            binTree.Add(3);
            binTree.Add(8);
            binTree.Add(6);
            binTree.Add(5);
            binTree.Add(7);

            binTree.Remove(8);

            Assert.DoesNotContain(8, binTree);
        }

        [Fact]
        public void BinaryTreeRemoveWorksForNoRightChildInDeletionNodeLeftBranchOfMainTree()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(12);
            binTree.Add(9);
            binTree.Add(15);
            binTree.Add(3);
            binTree.Add(11);
            binTree.Add(10);

            binTree.Remove(11);

            Assert.DoesNotContain(11, binTree);
        }

        [Fact]
        public void BinaryTreeRemoveWorksForNoLeftChildOfDeletionNodeOfRightBranchOfMainTree()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(4);
            binTree.Add(2);
            binTree.Add(1);
            binTree.Add(3);
            binTree.Add(6);
            binTree.Add(5);
            binTree.Add(7);
            binTree.Add(8);

            binTree.Remove(6);

            Assert.DoesNotContain(6, binTree);
        }

        [Fact]
        public void BinaryTreeRemoveWorksForNoLeftChildOfDeletionNodeOfLeftBranchOfMainTree()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(15);
            binTree.Add(20);
            binTree.Add(10);
            binTree.Add(3);
            binTree.Add(13);
            binTree.Add(14);

            binTree.Remove(10);

            Assert.DoesNotContain(10, binTree);
        }

        [Fact]
        public void BinaryTreeRemoveWorksForLeftMostChildOfRightChildOfDeletionNodeRightBranchOfMainTree()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(4);
            binTree.Add(2);
            binTree.Add(1);
            binTree.Add(3);
            binTree.Add(6);
            binTree.Add(5);
            binTree.Add(8);
            binTree.Add(7);

            binTree.Remove(6);

            Assert.DoesNotContain(6, binTree);
        }

        [Fact]
        public void BinaryTreeRemoveWorksForLeftMostChildOfRightChildOfDeletionNodeLeftBranchOfMainTree()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(30);
            binTree.Add(40);
            binTree.Add(35);
            binTree.Add(24);
            binTree.Add(20);
            binTree.Add(26);
            binTree.Add(25);
            binTree.Add(28);
            binTree.Add(27);

            binTree.Remove(26);

            Assert.DoesNotContain(26, binTree);
        }

        [Fact]
        public void BinaryTreeRemoveWorksForLeafNode()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(4);
            binTree.Add(2);
            binTree.Add(1);
            binTree.Add(3);
            binTree.Add(6);
            binTree.Add(5);
            binTree.Add(8);
            binTree.Add(7);

            binTree.Remove(7);

            Assert.DoesNotContain(7, binTree);
        }

        [Fact]
        public void BinaryTreeAddThrowsArgumentExceptionForDuplicateValueInTree()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(2);

            Assert.Throws<ArgumentException>(()=> binTree.Add(2));
        }

        [Fact]
        public void BinaryTreeCopyToThrowsArgumentNullExceptionForNullArrayValue()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(2);
            binTree.Add(1);
            binTree.Add(10);

            Assert.Throws<ArgumentNullException>(() => binTree.CopyTo(null, 0));
        }

        [Fact]
        public void BinaryTreeCopyToThrowsArgumentExceptionForUnderLengthArray()
        {
            var binTree = new BinaryTree<int>();

            binTree.Add(2);
            binTree.Add(1);
            binTree.Add(10);
            binTree.Add(7);
            binTree.Add(5);

            var sourceArray = new int[2];

            Assert.Throws<ArgumentException>(()=> binTree.CopyTo(sourceArray, 0));
        }
    }
}
