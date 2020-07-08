using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace ChessMoves
{
    [Serializable]
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

        private bool CheckValidator(Player opponent, ChessBoard chessBoard)
        {
            var diags = Diagonals()
                .Where(x =>
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                (chessBoard.IsPiece(x.Last(), PieceType.Queen, opponent) ||
                chessBoard.IsPiece(x.Last(), PieceType.Bishop, opponent)));

            var rowsAndColumns = RowsAndColumns()
                .Where(x =>
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                (chessBoard.IsPiece(x.Last(), PieceType.Rock, opponent) ||
                chessBoard.IsPiece(x.Last(), PieceType.Queen, opponent)));

            var knight = new Knight(CurrentPosition, PlayerColour).GetLegalMoves()
                .Where(x => chessBoard.IsPiece(x.Single(), PieceType.Knight, opponent));

            return diags.Any() || rowsAndColumns.Any() || knight.Any();
        }

        internal override bool IsCheckMated(Player player, ChessBoard chessBoard)
        {
            var moves = GetLegalMoves().Where(x => chessBoard.IsPathClear(x));

            foreach (var move in moves)
            {
                var current = chessBoard.DeepClone();

                current.PerformMove(CurrentPosition, move.Single());

                if (!current.IsChecked(player))
                {
                    return false;
                }
            }

            return moves.Count() > 0;
        }

        internal override bool IsChecked(Player player, ChessBoard chessBoard)
        {
            switch (player)
            {
                case Player.Black:
                    return CheckValidator(Player.White, chessBoard);
                case Player.White:
                    return CheckValidator(Player.Black, chessBoard);
                default:
                    return false;
            }
        }
    }
}