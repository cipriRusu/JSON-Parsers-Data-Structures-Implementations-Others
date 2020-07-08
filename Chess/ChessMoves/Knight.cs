using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
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

            if (CheckIndexes(CurrentPosition.Item1 - 2, CurrentPosition.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 2, CurrentPosition.Item2 + 1), 1));
            }
            if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 2), 1));
            }
            if (CheckIndexes(CurrentPosition.Item1 - 2, CurrentPosition.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 2, CurrentPosition.Item2 - 1), 1));
            }
            if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 2), 1));
            }
            if (CheckIndexes(CurrentPosition.Item1 + 2, CurrentPosition.Item2 + 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 2, CurrentPosition.Item2 + 1), 1));
            }
            if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 2), 1));
            }
            if (CheckIndexes(CurrentPosition.Item1 + 2, CurrentPosition.Item2 - 1))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 2, CurrentPosition.Item2 - 1), 1));
            }
            if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 2))
            {
                legalMoves.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 2), 1));
            }

            return legalMoves;
        }

        internal override void Move(UserMove move, ChessBoard chessBoard)
        {
            var validPath = ValidatePath(chessBoard, move).SelectMany(x => x);

            if(validPath.Any())
            {
                chessBoard
                    .PerformMove(CurrentPosition, validPath.Last());
            }
        }

        protected override IEnumerable<IEnumerable<(int, int)>> ValidatePath(ChessBoard board, UserMove move)
        {
            if (move.UserMoveType == UserMoveType.Move)
            {
                return
                    GetLegalMoves()
                    .Where(
                        x => x.Single() == move.MoveIndex);
            }

            if (move.UserMoveType == UserMoveType.Capture)
            {
                return
                    GetLegalMoves()
                    .Where(
                        x => x.Single() == move.MoveIndex &&
                        board[x.Single().Item1, x.Single().Item2].PlayerColour ==
                        Opponent(PlayerColour));


            }

            return null;
        }
    }
}