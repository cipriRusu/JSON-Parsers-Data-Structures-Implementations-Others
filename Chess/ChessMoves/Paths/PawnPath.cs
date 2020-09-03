using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Paths
{
    public class PawnPath : IEnumerable<IEnumerable<(int, int)>>
    {
        private (int, int) StartIndex;
        private Player PlayerColour;
        public PawnPath((int, int) startIndex, Player playerColour)
        {
            StartIndex = startIndex;
            PlayerColour = playerColour;
        }

        private bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);

        private IEnumerable<IEnumerable<(int, int)>> AllPawnPaths()
        {
            const int BLACKSTARTPOSITION = 1;
            const int WHITESTARTPOSITION = 6;

            var paths = new List<(int, int)>();

            if (PlayerColour == Player.Black)
            {
                if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2))
                {
                    for (int i = StartIndex.Item1; i <= StartIndex.Item1 + 1; i++)
                    {
                        paths.Add((i, StartIndex.Item2));
                    }

                    if (StartIndex.Item1 == BLACKSTARTPOSITION)
                    {
                        paths.Add((paths.Last().Item1 + 1, paths.Last().Item2));
                    }
                }
            }
            else if (PlayerColour == Player.White)
            {
                if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2))
                {
                    for (int i = StartIndex.Item1; i >= StartIndex.Item1 - 1; i--)
                    {
                        paths.Add((i, StartIndex.Item2));
                    }

                    if (StartIndex.Item1 == WHITESTARTPOSITION)
                    {
                        paths.Add((paths.Last().Item1 - 1, paths.Last().Item2));
                    }
                }
            }

            return paths.Select((x, y) => paths.Take(y + 1)).Skip(1);
        }

        public IEnumerator<IEnumerable<(int, int)>> GetEnumerator()
        {
            foreach(var path in AllPawnPaths())
            {
                yield return path;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
