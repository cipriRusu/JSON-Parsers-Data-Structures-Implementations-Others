using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class KnightMoves
    {
        private (int, int) startPoint;
        public IEnumerable<IEnumerable<(int, int)>> AllMoves => GetLegalMoves();
        public KnightMoves((int, int) startPoint) => 
            this.startPoint = startPoint;

        private List<IEnumerable<(int, int)>> GetLegalMoves()
        {
            var legalMoves = new List<IEnumerable<(int, int)>>();

            if (CheckIndexes(startPoint.Item1 - 2, startPoint.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((startPoint.Item1 - 2, startPoint.Item2 + 1), 1));
            }
            if (CheckIndexes(startPoint.Item1 - 1, startPoint.Item2 + 2))
            {
                legalMoves.Add(Enumerable.Repeat((startPoint.Item1 - 1, startPoint.Item2 + 2), 1));
            }
            if (CheckIndexes(startPoint.Item1 - 2, startPoint.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((startPoint.Item1 - 2, startPoint.Item2 - 1), 1));
            }
            if (CheckIndexes(startPoint.Item1 - 1, startPoint.Item2 - 2))
            {
                legalMoves.Add(Enumerable.Repeat((startPoint.Item1 - 1, startPoint.Item2 - 2), 1));
            }
            if (CheckIndexes(startPoint.Item1 + 2, startPoint.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((startPoint.Item1 + 2, startPoint.Item2 + 1), 1));
            }
            if (CheckIndexes(startPoint.Item1 + 1, startPoint.Item2 + 2))
            {
                legalMoves.Add(Enumerable.Repeat((startPoint.Item1 + 1, startPoint.Item2 + 2), 1));
            }
            if (CheckIndexes(startPoint.Item1 + 2, startPoint.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((startPoint.Item1 + 2, startPoint.Item2 - 1), 1));
            }
            if (CheckIndexes(startPoint.Item1 + 1, startPoint.Item2 - 2))
            {
                legalMoves.Add(Enumerable.Repeat((startPoint.Item1 + 1, startPoint.Item2 - 2), 1));
            }

            return legalMoves;
        }

        private bool CheckIndexes(int first, int second) => 
            (0 <= first && first <= 7) && (0 <= second && second <= 7);
    }
}
