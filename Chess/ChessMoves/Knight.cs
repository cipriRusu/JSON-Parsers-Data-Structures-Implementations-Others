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

        public override Path GetLegalMoves() => new Path(CurrentPosition, new PathType[] { PathType.Knight });

        internal override bool IsMoveValid(ChessBoard board, UserMove move)
        {
            var currentPath = ValidatePath(board, move).SelectMany(x => x);

            return currentPath.Any();
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