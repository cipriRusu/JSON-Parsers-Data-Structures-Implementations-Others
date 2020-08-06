using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CastlingMoveValidator
    {
        private IBoardState chessBoard;

        public CastlingMoveValidator(IBoardState chessBoard) => this.chessBoard = chessBoard;

        public bool IsValid(IUserMove move)
        {
            switch (move)
            {
                case KingCastlingUserMove _:
                    return ValidateKingSide(move);
                case QueenCastlingUserMove _:
                    return ValidateQueenSide(move);
                default:
                    break;
            }

            return false;
        }

        private bool ValidateKingSide(IUserMove move)
        {
            int PlayerIndex = move.PlayerColor == Player.White ? 7 : 0;

            var castlingPath = Enumerable.Range(4, 4).Select(x => (PlayerIndex, x));

            bool isPassAttacked = OnPassAttacks(castlingPath);

            return !isPassAttacked && 
                chessBoard.IsPathClear(castlingPath.Skip(1).SkipLast(1)) && 
                NullAndMoveValidation(PlayerIndex, 7);
        }

        private bool ValidateQueenSide(IUserMove move)
        {
            int PlayerIndex = move.PlayerColor == Player.White ? 7 : 0;

            var castlingPath = Enumerable.Range(0, 5).Select(x => (PlayerIndex, x));

            var isPassAttacked = OnPassAttacks(castlingPath.Reverse());

            return !isPassAttacked
                && chessBoard.IsPathClear(castlingPath.Skip(1).SkipLast(1))
                && NullAndMoveValidation(PlayerIndex, 0);
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
