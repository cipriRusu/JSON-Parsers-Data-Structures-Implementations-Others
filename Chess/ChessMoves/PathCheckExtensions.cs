using System;
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

        public static bool IsOpponentPathClear(this IEnumerable<(int, int)> input, Player player, Piece[,] board, bool isKnight)
        {
            if (player == Player.White)
            {
                if (isKnight == false)
                {
                    return
                        input.IsCapturePathClear(board) && 
                    board[input.First().Item1, input.First().Item2] != null &&
                    board[input.First().Item1, input.First().Item2].PlayerColour == player &&
                    board[input.Last().Item1, input.Last().Item2].PlayerColour == Player.Black;
                }
                else
                {
                    return 
                    board[input.Single().Item1, input.Single().Item2] != null &&
                    board[input.Single().Item1, input.Single().Item2].PlayerColour == Player.Black;
                }
            }

            if (player == Player.Black)
            {
                if (isKnight == false)
                {
                    return
                        input.IsCapturePathClear(board) &&
                board[input.First().Item1, input.First().Item2] != null &&
                board[input.First().Item1, input.First().Item2].PlayerColour == player &&
                board[input.Last().Item1, input.Last().Item2].PlayerColour == Player.White;
                }
                else
                {
                    return
                    board[input.Single().Item1, input.Single().Item2] != null &&
                    board[input.Single().Item1, input.Single().Item2].PlayerColour == Player.White;
                }
            }

            return false;
        }
    }
}
