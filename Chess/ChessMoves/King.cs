﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ChessMoves
{
    internal class King : Piece
    {
        public King((int, int) currentPosition, Player playerColour) :
            base(currentPosition, playerColour)
        { base.PieceType = PieceType.King; }

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
    }
}