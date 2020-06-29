using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public static class PathCheckExtensions
    {
        public static bool CheckPath(this IEnumerable<(int, int)> input, Piece[,] board, UserMoveType userMove)
        {
            if (UserMoveType.Move == userMove)
            {
                return input.IsMovePathClear(board);
            }
            if (UserMoveType.Capture == userMove)
            {
                return input.IsCapturePathClear(board);
            }

            return false;
        }

        private static bool IsMovePathClear(this IEnumerable<(int, int)> input, Piece[,] board) =>
            input.Skip(1).All(x => board[x.Item1, x.Item2] == null);

        private static bool IsCapturePathClear(this IEnumerable<(int, int)> input, Piece[,] board)
        {
            return
                board[input.First().Item1, input.First().Item2] != null &&
                board[input.Last().Item1, input.Last().Item2] != null &&
                input.Skip(1).SkipLast(1).All(x => board[x.Item1, x.Item2] == null);
        }

        public static bool IsOpponentPathClear(
            this IEnumerable<(int, int)> input, Player player, Piece[,] board, bool isKnight)
        {
            switch (player)
            {
                case Player.White:
                    return isKnight == false ? IsOpponent(input, player, board, Player.Black) :
                        IsOpponentKnight(input, board, Player.Black);

                case Player.Black:
                    return isKnight == false ? IsOpponent(input, player, board, Player.White) :
                        IsOpponentKnight(input, board, Player.White);

                default:
                    return false;
            }

            static bool IsOpponentKnight(
                IEnumerable<(int, int)> input, Piece[,] board, Player opponentPlayer)
            {
                return
                    board[input.Single().Item1, input.Single().Item2] != null &&
                    board[input.Single().Item1, input.Single().Item2].PlayerColour == opponentPlayer;
            }

            static bool IsOpponent(
                IEnumerable<(int, int)> input, Player player, Piece[,] board, Player opponentPlayer)
            {
                return
                    input.IsCapturePathClear(board) &&
                    board[input.First().Item1, input.First().Item2] != null &&
                    board[input.First().Item1, input.First().Item2].PlayerColour == player &&
                    board[input.Last().Item1, input.Last().Item2].PlayerColour == opponentPlayer;
            }
        }
    }
}
