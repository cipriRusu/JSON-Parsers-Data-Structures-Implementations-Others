using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional_LINQ.SudokuBoardChecker
{
    public class SudokuBoardCheckerTest
    {
        [Fact]
        public void BoardCheckerReturnsTrueForValidBoard()
        {
            var sudokuValidator = new SudokuBoardChecker();

            var inputMatrix = new int[9, 9]
            {
                {6, 3, 9, 5, 7, 4, 1, 8, 2 } ,
                {5, 4, 1, 8, 2, 9, 3, 7, 6 } ,
                {7, 8, 2, 6, 1, 3, 9, 5, 4 } ,
                {1, 9, 8, 4, 6, 7, 5, 2, 3 } ,
                {3, 6, 5, 9, 8, 2, 4, 1, 7 } ,
                {4, 2, 7, 1, 3, 5, 8, 6, 9 } ,
                {9, 5, 6, 7, 4, 8, 2, 3, 1 } ,
                {8, 1, 3, 2, 9, 6, 7, 4, 5 } ,
                {2, 7, 4, 3, 5, 1, 6, 9, 8 } ,
            };

            Assert.True(sudokuValidator.SudokuValidator(inputMatrix));
        }

        [Fact]
        public void BoardCheckerReturnsFalseForInvalidBoardMissingSingleValue()
        {
            var sudokuValidator = new SudokuBoardChecker();

            var inputMatrix = new int[9, 9]
            {
                {6, 3, 9, 5, 7, 4, 1, 8, 2 } ,
                {5, 4, 1, 8, 2, 9, 3, 7, 6 } ,
                {7, 8, 2, 6, 1, 3, 9, 5, 4 } ,
                {1, 9, 8, 4, 6, 7, 5, 2, 3 } ,
                {3, 6, 5, 9, 8, 2, 4, 1, 7 } ,
                {4, 2, 7, 1, 3, 5, 8, 6, 9 } ,
                {9, 5, 6, 7, 4, 8, 2, 3, 1 } ,
                {8, 1, 3, 2, 9, 6, 7, 4, 5 } ,
                {2, 7, 4, 3, 5, 1, 6, 9, 9 } ,
            };

            Assert.False(sudokuValidator.SudokuValidator(inputMatrix));
        }

        [Fact]
        public void BoarDcheckerReturnsFalseForInvalidBoardMissingMultipleValues()
        {
            var sudokuValidator = new SudokuBoardChecker();

            var inputMatrix = new int[9, 9]
            {
                {6, 3, 9, 5, 7, 4, 1, 8, 2 } ,
                {5, 4, 1, 8, 2, 9, 3, 7, 6 } ,
                {7, 8, 2, 6, 6, 3, 9, 5, 4 } ,
                {1, 9, 8, 4, 6, 7, 5, 2, 3 } ,
                {3, 6, 5, 9, 8, 2, 4, 1, 7 } ,
                {4, 2, 7, 1, 3, 5, 8, 6, 9 } ,
                {9, 5, 6, 7, 4, 8, 2, 3, 1 } ,
                {8, 1, 3, 2, 9, 6, 7, 4, 5 } ,
                {2, 7, 4, 3, 5, 1, 6, 9, 9 } ,
            };

            Assert.False(sudokuValidator.SudokuValidator(inputMatrix));
        }
    }
}
