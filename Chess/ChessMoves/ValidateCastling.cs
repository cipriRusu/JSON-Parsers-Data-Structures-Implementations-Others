using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class ValidateCastling
    {
        private IBoardState chessBoard;

        public ValidateCastling(IBoardState chessBoard) => this.chessBoard = chessBoard;

        public bool IsValid(IUserMove move)
        {
            if (move is KingCastlingUserMove)
            {
                switch (move.PlayerColor)
                {
                    case Player.White:
                        return ValidateKingSide(7);
                    case Player.Black:
                        return ValidateKingSide(0);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if(move is QueenCastlingUserMove)
            {
                switch (move.PlayerColor)
                {
                    case Player.White:
                        return ValidateQueenSide(7);
                    case Player.Black:
                        return ValidateQueenSide(0);
                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }

            return false;
        }

        public bool ValidateKingSide(int sideIndex)
        {
            var castlingPath = Enumerable.Range(4, 4).Select(x => (sideIndex, x));

            bool isPassAttacked = OnPassAttacks(castlingPath);

            return !isPassAttacked
                   && chessBoard.IsPathClear(castlingPath.Skip(1).SkipLast(1))
                   && NullAndMoveValidation(sideIndex, 7);
        }

        public bool ValidateQueenSide(int sideIndex)
        {
            var castlingPath = Enumerable.Range(0, 5).Select(x => (sideIndex, x));

            var isPassAttacked = OnPassAttacks(castlingPath.Reverse());

            return !isPassAttacked
                && chessBoard.IsPathClear(castlingPath.Skip(1).SkipLast(1))
                && NullAndMoveValidation(sideIndex, 0);
        }

        private bool OnPassAttacks(IEnumerable<(int, int)> castlingPath) =>
            castlingPath.Skip(1)
                        .Take(2)
                        .Select(x => new UserMove(x, chessBoard.TurnToMove))
            .Any(x => new AttackStatus(chessBoard, chessBoard.GetKing(chessBoard.TurnToMove)).IsCurrentMoveAttacked(x));

        private bool NullAndMoveValidation(int columnIndex, int rowIndex) =>
            chessBoard[(columnIndex, 4)] != null &&
            chessBoard[(columnIndex, rowIndex)] != null &&
            !chessBoard[(columnIndex, 4)].IsMoved &&
            !chessBoard[(columnIndex, rowIndex)].IsMoved;
    }
}
