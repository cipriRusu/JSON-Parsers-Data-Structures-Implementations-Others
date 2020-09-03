using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Paths
{
    class PawnCapturePath : IEnumerable<IEnumerable<(int, int)>>
    {
        private (int, int) StartIndex;
        private Player PlayerColour;

        public PawnCapturePath((int, int) startIndex, Player playerColour)
        {
            StartIndex = startIndex;
            PlayerColour = playerColour;
        }

        private bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);

        private IEnumerable<IEnumerable<(int, int)>> AllPawnCapture()
        {
            var captures = new List<IEnumerable<(int, int)>>();

            if (PlayerColour == Player.White)
            {
                if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2 + 1))
                {
                    captures.Add(Enumerable.Repeat((StartIndex.Item1 - 1, StartIndex.Item2 + 1), 1));
                }
                if (CheckIndexes(StartIndex.Item1 - 1, StartIndex.Item2 - 1))
                {
                    captures.Add(Enumerable.Repeat((StartIndex.Item1 - 1, StartIndex.Item2 - 1), 1));
                }
            }
            else if (PlayerColour == Player.Black)
            {
                if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2 - 1))
                {
                    captures.Add(Enumerable.Repeat((StartIndex.Item1 + 1, StartIndex.Item2 - 1), 1));
                }
                if (CheckIndexes(StartIndex.Item1 + 1, StartIndex.Item2 + 1))
                {
                    captures.Add(Enumerable.Repeat((StartIndex.Item1 + 1, StartIndex.Item2 + 1), 1));
                }
            }

            return captures;
        }

        public IEnumerator<IEnumerable<(int, int)>> GetEnumerator()
        {
            foreach(var path in AllPawnCapture())
            {
                yield return path;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
