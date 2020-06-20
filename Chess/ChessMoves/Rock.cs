using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    internal class Rock : Piece
    {
        public Rock((int, int) currentPosition, Player playerColour) : base(currentPosition, playerColour)
        { base.PieceType = PieceType.Rock; }

        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour)
        {
            PieceType = PieceType.Rock;
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
        }

        public override IEnumerable<IEnumerable<(int, int)>> GetLegalMoves()
        {
            var firstColumn = new List<(int, int)>();
            var firstRow = new List<(int, int)>();
            var secondColumn = new List<(int, int)>();
            var secondRow = new List<(int, int)>();

            for(int i = CurrentPosition.Item1; i >= 0; i--)
            {
                firstColumn.Add((i, CurrentPosition.Item2));
            }

            for(int i = CurrentPosition.Item2; i <= 7; i++)
            {
                firstRow.Add((CurrentPosition.Item1, i));
            }

            for(int i = CurrentPosition.Item1; i <= 7; i++)
            {
                secondColumn.Add((i, CurrentPosition.Item2));
            }

            for(int i = CurrentPosition.Item2; i >= 0; i--)
            {
                secondRow.Add((CurrentPosition.Item1, i));
            }

            var firstSubs = firstColumn.Select((x, y) => firstColumn.Take(y + 1)).Skip(1);
            var firstRowSubs = firstRow.Select((x, y) => firstRow.Take(y + 1)).Skip(1);
            var secondSubs = secondColumn.Select((x, y) => secondColumn.Take(y + 1)).Skip(1);
            var secondColSubs = secondRow.Select((x, y) => secondRow.Take(y + 1)).Skip(1);

            return firstSubs.Concat(firstRowSubs).Concat(secondSubs).Concat(secondColSubs);
        }
    }
}