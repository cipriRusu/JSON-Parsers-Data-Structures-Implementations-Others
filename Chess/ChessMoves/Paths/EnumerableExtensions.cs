using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Paths
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<int> CountUp(int from, int to)
        {
            while (from <= to)
            {
                yield return from;
                from++;
            }
        }
        public static IEnumerable<int> CountDown(int from, int to)
        {
            while(from >= to)
            {
                yield return from;
                from--;
            }
        }
    }
}
