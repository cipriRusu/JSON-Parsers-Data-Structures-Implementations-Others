using System.Linq;
using System.Collections.Generic;
using Xunit.Sdk;
using System;
using System.Runtime.CompilerServices;

namespace Functional_LINQ.SudokuBoardChecker
{
    public class SudokuBoardChecker
    {
        public bool SudokuValidator(int[,] inputMatrix)
        {
            return
                CheckFullBoard(inputMatrix) &&
                CheckSubBoards(inputMatrix); 
        }

        private bool CheckSubBoards(int[,] inputMatrix)
        {
            var startIndexes = new int[] { 0, 3, 6 };

            var indexes = startIndexes.Select(x => startIndexes.Select(y => (x, y)));

            return indexes
                .SelectMany(x => x)
                .Select(x => MatrixGenerator(inputMatrix, inputMatrix.GetLength(0) / 3, (x.x, x.y))
                    .SelectMany(y => y)
                    .ContainsAllDigits())
                .All(x => x == true);
        }

        private bool CheckFullBoard(int[,] inputMatrix)
        {
            return
                MatrixGenerator(inputMatrix, inputMatrix.GetLength(0), (0, 0))
                    .Union(MatrixGenerator(inputMatrix, inputMatrix.GetLength(0), (0, 0), false))
                .All(x => x.ContainsAllDigits());
        }

        private IEnumerable<IEnumerable<int>> MatrixGenerator(
            int[,] inputMatrix, int length, (int, int) startIndex, bool isRow = true)
        {
            var indexes = Enumerable.Range(0, length);

            return
                indexes.Select(x =>
                    indexes.Select(y => isRow == true ?
                    inputMatrix[x + startIndex.Item1, y + startIndex.Item2] :
                    inputMatrix[y + startIndex.Item2, x + startIndex.Item1]));
        }
    }
}
