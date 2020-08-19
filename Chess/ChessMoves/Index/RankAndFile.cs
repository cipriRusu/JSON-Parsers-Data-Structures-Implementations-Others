using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class RankAndFile
    {
        const int CHESSBOARDSIZE = 8;
        public char Rank { get; private set; }
        public char File { get; private set; }
        public string GetRankAndFile => string.Concat(File, Rank);
        public RankAndFile((int, int) input)
        {
            if (CheckIndexes(input.Item1, input.Item2))
            {
                File = Enumerable.Range('a', CHESSBOARDSIZE)
                .Select(x => Convert.ToChar(x)).Where((x, y) => y == input.Item2).Single();

                Rank = Enumerable.Range(1, CHESSBOARDSIZE)
                    .Select(x => Convert.ToChar(x + '0')).Where((x, y) => y == CHESSBOARDSIZE - 1 - input.Item1).Single();
            }
            else
            {
                throw new ArgumentException("Index value not valid");
            }
        }

        private bool CheckIndexes(int a, int b) => (0 <= a && a <= 7) && (0 <= b && b <= 7);
    }
}
