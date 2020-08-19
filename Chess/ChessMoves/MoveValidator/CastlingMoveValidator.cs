using ChessMoves.Moves;
using ChessMoves.Paths;
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
            int PlayerIndex = move.PlayerColor == Player.White ? 7 : 0;

            switch (move)
            {
                case KingCastlingUserMove _:
                    var completePath = Enumerable.Range(4, 4).Select(x => (PlayerIndex, x));
                    bool isPassAttacked = OnPassAttacks(completePath);

                    return
                        !isPassAttacked
                        && chessBoard.IsCapturePathClear(new Path(completePath, completePath.First()))
                        && NullAndMoveValidation(PlayerIndex, 7);

                case QueenCastlingUserMove _:
                    completePath = Enumerable.Range(0, 5).Select(x => (PlayerIndex, x)).Reverse();
                    isPassAttacked = OnPassAttacks(completePath);

                    return
                        !isPassAttacked
                        && chessBoard.IsCapturePathClear(new Path(completePath, completePath.First()))
                        && NullAndMoveValidation(PlayerIndex, 0);
                default:
                    break;
            }

            return false;
        }

        private bool OnPassAttacks(IEnumerable<(int, int)> castlingPath) => false;
        //castlingPath.Skip(1).Take(2).Select(x => new UserMove(x, chessBoard.TurnToMove))
            //.Any(x => new AttackStatus(chessBoard, chessBoard.GetKing(chessBoard.TurnToMove)).IsCurrentMoveAttacked(x));

        private bool NullAndMoveValidation(int columnIndex, int rowIndex) =>
            chessBoard[(columnIndex, 4)] != null &&
            chessBoard[(columnIndex, rowIndex)] != null &&
            !chessBoard[(columnIndex, 4)].IsMoved &&
            !chessBoard[(columnIndex, rowIndex)].IsMoved;
    }
}
