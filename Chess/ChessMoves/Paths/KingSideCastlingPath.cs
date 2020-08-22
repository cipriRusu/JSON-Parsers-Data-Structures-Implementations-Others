﻿using ChessMoves;
using ChessMoves.Paths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Paths
{
    public class KingSideCastlingPath : IEnumerable<IPath>
    {
        private int BLACKINDEX = 0;
        private int WHITEINDEX = 7;
        private (int, int) StartIndex;
        private Player PlayerColour;
        public KingSideCastlingPath((int, int) startIndex, Player playerColour)
        {
            StartIndex = startIndex;
            PlayerColour = playerColour;
        }

        private IEnumerable<IEnumerable<(int, int)>> Positions()
        {
            var path = new List<(int, int)>();

            if(PlayerColour == Player.White)
            {
                for(int i = StartIndex.Item2; i >= 4; i--)
                {
                    path.Add((WHITEINDEX, i));
                }
            }
            else
            {
                for (int i = StartIndex.Item2; i >= 4; i--)
                {
                    path.Add((BLACKINDEX, i));
                }
            }

            yield return path;
        }

        public IEnumerator<IPath> GetEnumerator()
        {
            foreach (var position in Positions())
                yield return new Path(position, StartIndex);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
