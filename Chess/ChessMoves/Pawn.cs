using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    internal class Pawn : Piece
    {
        public Pawn((int, int) inputIndex, Player playerColour) :
            base(inputIndex, playerColour)
        { base.PieceType = PieceType.Pawn; }

        public Pawn(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour)
        {
            base.PieceType = PieceType.Pawn;
            base.CurrentPosition = base.customIndex.GetMatrixIndex(chessBoardIndex);
            base.PlayerColour = playerColour;
        }

        public override Path GetLegalMoves() => new Path(CurrentPosition, new PathType[] { PathType.Pawn }, PlayerColour);

        internal override bool IsMoveValid(ChessBoard board, UserMove move)
        {
            var path = ValidatePath(board, move).SelectMany(x => x);

            return path.Any() && board.IsPathClear(path.Skip(1));
        }

        protected IEnumerable<IEnumerable<(int, int)>> PawnCapture()
        {
            var captures = new List<IEnumerable<(int, int)>>();

            if (PlayerColour == Player.White)
            {
                if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 1))
                {
                    captures.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 1), 1));
                }
                if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 1))
                {
                    captures.Add(Enumerable.Repeat((CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 1), 1));
                }
            }
            else if (PlayerColour == Player.Black)
            {
                if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 1))
                {
                    captures.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 1), 1));
                }
                if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 1))
                {
                    captures.Add(Enumerable.Repeat((CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 1), 1));
                }
            }

            return captures;
        }

        protected override IEnumerable<IEnumerable<(int, int)>> ValidatePath(ChessBoard board, UserMove move)
        {
            if (move.UserMoveType == UserMoveType.Move)
            {
                return base.ValidatePath(board, move);
            }
            if(move.UserMoveType == UserMoveType.Capture)
            {
                return
                        PawnCapture()
                        .Where(
                            x => x.Single() == move.MoveIndex &&
                            board[x.Single().Item1, x.Single().Item2].PlayerColour ==
                            Opponent(PlayerColour));
            }

            return null;
        }
    }
}