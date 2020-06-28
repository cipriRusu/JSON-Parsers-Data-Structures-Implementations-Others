using System.Collections.Generic;
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

        internal override bool IsChecked(Piece[,] board) => new KingCheck(board, PlayerColour).IsCheck;

        internal override bool IsCheckMate(Piece[,] board) => new KingCheck(board, PlayerColour).IsCheckMate;
    }
}