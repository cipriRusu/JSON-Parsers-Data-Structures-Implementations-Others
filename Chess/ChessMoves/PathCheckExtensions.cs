﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public static class PathCheckExtensions
    {
        public static bool IsMovePathClear(this IEnumerable<(int, int)> input, Piece[,] board) =>
            input.Skip(1).All(x => board[x.Item1, x.Item2] == null);

        public static bool IsCapturePathClear(this IEnumerable<(int, int)> input, Piece[,] board)
        {
            return
                board[input.First().Item1, input.First().Item2] != null && 
                board[input.Last().Item1, input.Last().Item2] != null && 
                input.Skip(1).SkipLast(1).All(x => board[x.Item1, x.Item2] == null);
        }
    }
}
