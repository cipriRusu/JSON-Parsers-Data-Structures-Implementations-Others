using System;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    internal class Index
    {
        //Used for conversion of chessboard index to standard matrix index

        private string[] letters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };

        public (int, int) GetIndex(string chessBoardIndex)
        {
            var isIndexPresent = letters.Select((x, y) =>
                letters.Select((a, b) =>
                new
                {
                    Key = a + (letters.Count() - y),
                    Value = (y, b)
                }))
                .SelectMany(x => x)
                .ToDictionary(y => y.Key, y => y.Value)
                .TryGetValue(chessBoardIndex, out (int, int)matrixIndex);

            if (!isIndexPresent)
            {
                throw new ArgumentException("Chess Board Index not valid!!");
            }

            return (matrixIndex.Item1, matrixIndex.Item2);
        }
    }
}
