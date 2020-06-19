using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    internal class Knight : Piece
    {
        public Knight((int, int) currentPosition, Player playerColour) :
            base(currentPosition, playerColour)
        { base.PieceType = PieceType.Knight; }

        public override IEnumerable<IEnumerable<(int, int)>> GetLegalMoves()
        {
            var legalMoves = new List<IEnumerable<(int, int)>>();

            if (CheckIndexes(base.CurrentPosition.Item1 - 2, CurrentPosition.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 2, CurrentPosition.Item2 + 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 2), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 - 2, CurrentPosition.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 2, CurrentPosition.Item2 - 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 2), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 + 2, CurrentPosition.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 2, CurrentPosition.Item2 + 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 2), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 + 2, CurrentPosition.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 2, CurrentPosition.Item2 - 1), 1));
            }
            if (CheckIndexes(base.CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 2), 1));
            }

            return legalMoves;
        }
    }
}