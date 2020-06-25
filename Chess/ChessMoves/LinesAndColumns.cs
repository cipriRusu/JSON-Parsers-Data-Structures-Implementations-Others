using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class LinesAndColumns
    {
        private (int, int) startPoint;
        public IEnumerable<IEnumerable<(int, int)>> AllRowsColumns => GetRowsAndColumns();
        public LinesAndColumns((int, int) startPoint) => this.startPoint = startPoint;
        private IEnumerable<IEnumerable<(int, int)>> GetRowsAndColumns()
        {
            var firstColumn = new List<(int, int)>();
            var firstRow = new List<(int, int)>();
            var secondColumn = new List<(int, int)>();
            var secondRow = new List<(int, int)>();

            for (int i = startPoint.Item1; i >= 0; i--)
            {
                firstColumn.Add((i, startPoint.Item2));
            }

            for (int i = startPoint.Item2; i <= 7; i++)
            {
                firstRow.Add((startPoint.Item1, i));
            }

            for (int i = startPoint.Item1; i <= 7; i++)
            {
                secondColumn.Add((i, startPoint.Item2));
            }

            for (int i = startPoint.Item2; i >= 0; i--)
            {
                secondRow.Add((startPoint.Item1, i));
            }

            var firstSubs = firstColumn.Select((x, y) => firstColumn.Take(y + 1)).Skip(1);
            var firstRowSubs = firstRow.Select((x, y) => firstRow.Take(y + 1)).Skip(1);
            var secondSubs = secondColumn.Select((x, y) => secondColumn.Take(y + 1)).Skip(1);
            var secondColSubs = secondRow.Select((x, y) => secondRow.Take(y + 1)).Skip(1);

            return firstSubs.Concat(firstRowSubs).Concat(secondSubs).Concat(secondColSubs);
        }
    }
}
