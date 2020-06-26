﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace ChessMoves
{
    internal class King : Piece
    {
        public King((int, int) currentPosition, Player playerColour) :
            base(currentPosition, playerColour)
        { base.PieceType = PieceType.King; }

        public King(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour)
        {
            base.PieceType = PieceType.King;
            base.CurrentPosition = base.customIndex.GetMatrixIndex(chessBoardIndex);
            base.PlayerColour = playerColour;
        }

        public override IEnumerable<IEnumerable<(int, int)>> GetLegalMoves()
        {
            var legalMoves = new List<IEnumerable<(int, int)>>();

            if (CheckIndexes(base.CurrentPosition.Item1, base.CurrentPosition.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1, CurrentPosition.Item2 + 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((base.CurrentPosition.Item1 - 1, base.CurrentPosition.Item2 + 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 - 1, CurrentPosition.Item2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1, CurrentPosition.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1, CurrentPosition.Item2 - 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 + 1, CurrentPosition.Item2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 1), 1));
            }

            return legalMoves;
        }

        internal override bool IsChecked(Piece[,] board)
        {
            var diagonals = new Diagonals(CurrentPosition).AllDiagonals;
            var linesColumns = new LinesAndColumns(CurrentPosition).AllRowsColumns;
            var knights = new KnightMoves(CurrentPosition).AllMoves;

            if (PlayerColour == Player.White)
            {
                var diagonalAttacks = diagonals.Where(x =>
                board[x.Last().Item1, x.Last().Item2] != null &&
                board[x.Last().Item1, x.Last().Item2].PlayerColour == Player.Black);

                var verticalHorizontalAttacks = linesColumns.Where(x =>
                board[x.Last().Item1, x.Last().Item2] != null &&
                board[x.Last().Item1, x.Last().Item2].PlayerColour == Player.Black);

                var knightsAttacks = knights.Where(x =>
                board[x.Last().Item1, x.Last().Item2] != null &&
                board[x.Last().Item1, x.Last().Item2].PlayerColour == Player.Black);
            }

            if (PlayerColour == Player.Black)
            {
                var diagonalAttacks = diagonals.Where(x =>
                board[x.Last().Item1, x.Last().Item2] != null &&
                board[x.Last().Item1, x.Last().Item2].PlayerColour == Player.White);

                var verticalHorizontalAttacks = linesColumns.Where(x =>
                board[x.Last().Item1, x.Last().Item2] != null &&
                board[x.Last().Item1, x.Last().Item2].PlayerColour == Player.White);

                var knightsAttacks = knights.Where(x =>
                board[x.Last().Item1, x.Last().Item2] != null &&
                board[x.Last().Item1, x.Last().Item2].PlayerColour == Player.White);

                if(knightsAttacks.Count() > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}