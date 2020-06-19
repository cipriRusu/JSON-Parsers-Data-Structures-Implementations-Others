using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    internal class Bishop : Piece
    {
        public Bishop((int, int) currentPosition, Player playerColour) :
            base(currentPosition, playerColour)
        { PieceType = PieceType.Bishop; }

        public override IEnumerable<IEnumerable<(int, int)>> GetLegalMoves()
        {
            var firstDiag = new List<(int, int)>();
            var secondDiag = new List<(int, int)>();
            var thirdDiag = new List<(int, int)>();
            var fourthDiag = new List<(int, int)>();

            for(int i = CurrentPosition.Item1, j = CurrentPosition.Item2;
                i >= 0 && j >= 0; i--, j--)
            {
                firstDiag.Add((i, j));
            }

            for (int i = CurrentPosition.Item1, j = CurrentPosition.Item2;
                i >= 0 && j <= 7; i--, j++)
            {
                secondDiag.Add((i, j));
            }

            for (int i = CurrentPosition.Item1, j = CurrentPosition.Item2;
               i <= 7 && j >= 0; i++, j--)
            {
                thirdDiag.Add((i, j));
            }

            for (int i = CurrentPosition.Item1, j = CurrentPosition.Item2;
               i <= 7 && j <= 7; i++, j++)
            {
                fourthDiag.Add((i, j));
            }

            var firstSubArrays = firstDiag.Select((x, y) => firstDiag.Take(y + 1)).Skip(1);
            var secondSubArrays = secondDiag.Select((x, y) => secondDiag.Take(y + 1)).Skip(1);
            var thirdSubArrays = thirdDiag.Select((x, y) => thirdDiag.Take(y + 1)).Skip(1);
            var fourthSubArrays = fourthDiag.Select((x, y) => fourthDiag.Take(y + 1)).Skip(1);

            return firstSubArrays.Concat(secondSubArrays).Concat(thirdSubArrays).Concat(fourthSubArrays);
        }
    }
}