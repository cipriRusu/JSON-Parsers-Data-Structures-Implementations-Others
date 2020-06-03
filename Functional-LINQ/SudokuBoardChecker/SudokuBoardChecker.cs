using System.Linq;
using Xunit.Sdk;

namespace Functional_LINQ.SudokuBoardChecker
{
    public class SudokuBoardChecker
    {
        public bool SudokuValidator(int[,] inputMatrix) => 
            MatrixChecker(inputMatrix, true) && 
            MatrixChecker(inputMatrix, false);

        private static bool MatrixChecker(int[,] inputMatrix, bool checkColumn)
        {
            var indexes = Enumerable.Range(0, inputMatrix.GetLength(0));

            return indexes
                .Select(x => indexes
                    .Select(y => checkColumn ? inputMatrix[y, x] : inputMatrix[x, y])
                        .ContainsAllDigits())
                .All(y => y == true);
        }
    }
}
