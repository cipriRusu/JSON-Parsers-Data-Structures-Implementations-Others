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

        public Knight(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour)
        {
            base.PieceType = PieceType.Knight;
            base.CurrentPosition = base.customIndex.GetMatrixIndex(chessBoardIndex);
            base.PlayerColour = playerColour;
        }

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

        internal override Piece[,] Move(UserMove move, Piece[,] board)
        {
            if (move.UserMoveType == UserMoveType.Move)
            {
                KnightMove(move, board);
            }
            if (move.UserMoveType == UserMoveType.Capture)
            {
                KnightCaptureMove(move, board);
            }

            return board;
        }

        private void KnightMove(UserMove move, Piece[,] board)
        {
            var containsMove = GetLegalMoves().SelectMany(x => x).Where(x => board[x.Item1, x.Item2] == null)
                                .Contains(move.MoveIndex);

            if (containsMove && board[move.MoveIndex.Item1, move.MoveIndex.Item2] == null)
            {
                board[move.MoveIndex.Item1, move.MoveIndex.Item2] = board[CurrentPosition.Item1, CurrentPosition.Item2];
                board[CurrentPosition.Item1, CurrentPosition.Item2] = null;
                board[move.MoveIndex.Item1, move.MoveIndex.Item2].UpdatePosition(move.MoveIndex);
            }
        }

        private void KnightCaptureMove(UserMove move, Piece[,] board)
        {
            var legalMoves = GetLegalMoves().SelectMany(x => x).Where(x => x == move.MoveIndex);

            if (legalMoves.Count() > 0)
            {
                board[move.MoveIndex.Item1, move.MoveIndex.Item2] = board[CurrentPosition.Item1, CurrentPosition.Item2];
                board[CurrentPosition.Item1, CurrentPosition.Item2] = null;
                board[move.MoveIndex.Item1, move.MoveIndex.Item2].UpdatePosition(move.MoveIndex);
            }
        }
    }
}