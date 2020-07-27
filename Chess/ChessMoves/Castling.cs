using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class Castling
    {
        private readonly ChessBoard chessBoard;
        private readonly UserMove move;
        private readonly int KING_SIDE = +3;
        private readonly int QUEEN_SIDE = -4;
        private CurrentPlayerStatus currentPlayerStatus => new CurrentPlayerStatus(move.PlayerColor, chessBoard);

        public Castling(ChessBoard chessBoard, UserMove move)
        {
            this.chessBoard = chessBoard;
            this.move = move;

            CastlingHandler();
        }

        private void CastlingHandler()
        {
            var kingToSwap = currentPlayerStatus.GetKing();
            var rockToSwap = GetSwappableRock(currentPlayerStatus.GetKing(), move.UserMoveType);

            if (!kingToSwap.IsMoved && rockToSwap != null && !rockToSwap.IsMoved)
            {
                if (chessBoard.IsPathClear(GetCastlingPath(move).Skip(1).SkipLast(1)))
                {
                    switch (move.UserMoveType)
                    {
                        case UserMoveType.KingCastling:
                            CheckAndPerformCastling(GetCastlingPath(move), 1, 2, -2);
                            break;
                        case UserMoveType.QueenCastling:
                            CheckAndPerformCastling(GetCastlingPath(move), 2, -2, 3);
                            break;
                    }
                }
                else
                {
                    throw new UserMoveException(move, "Castling move not available with unclear path!");
                }
            }
            else
            {
                throw new UserMoveException(move, "Castling move not available with moved pieces!");
            }
        }

        private void CheckAndPerformCastling(IEnumerable<(int, int)> path, int startSkip, int kingSource, int rockSource)
        {
            if (path.Skip(startSkip).SkipLast(1).All(x => !currentPlayerStatus.PlaceCheckStatus(x)))
            {
                PerformCastling(currentPlayerStatus.GetKing(),
                    GetSwappableRock(currentPlayerStatus.GetKing(), move.UserMoveType), kingSource, rockSource);
            }
            else
            {
                throw new UserMoveException(move, "Castling move not available through Check!");
            }
        }

        private IEnumerable<(int, int)> GetCastlingPath(UserMove move)
        {
            switch (move.UserMoveType)
            {
                case UserMoveType.KingCastling:
                    return GetFullRow(move).Skip(GetFullRow(move).Count() + QUEEN_SIDE);
                case UserMoveType.QueenCastling:
                    return GetFullRow(move).SkipLast(KING_SIDE);
                default:
                    return null;
            }
        }

        private IEnumerable<(int, int)> GetFullRow(UserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    return Enumerable.Range(0, ChessBoard.CHESSBOARD_SIZE).Select(x => (7, x));
                case Player.Black:
                    return Enumerable.Range(0, ChessBoard.CHESSBOARD_SIZE).Select(x => (0, x));
                default:
                    return null;
            }
        }

        private Piece GetRock(Piece currentKing, int castlingSide)
        {
            var locationIndex =
                (currentKing.CurrentPosition.Item1,
                 currentKing.CurrentPosition.Item2 + castlingSide);

            return chessBoard[locationIndex] != null &&
                  !chessBoard[locationIndex].IsMoved ?
                   chessBoard[locationIndex] : null;
        }

        private Piece GetSwappableRock(Piece currentKing, UserMoveType move)
        {
            switch (move)
            {
                case UserMoveType.KingCastling:
                    return GetRock(currentKing, KING_SIDE);
                case UserMoveType.QueenCastling:
                    return GetRock(currentKing, QUEEN_SIDE);
                default:
                    return null;
            }
        }

        private void PerformCastling(Piece king, Piece rock, int kingSource, int rockSource)
        {
            chessBoard.PerformMove(
                king.CurrentPosition,
               (king.CurrentPosition.Item1,
                king.CurrentPosition.Item2 + kingSource));

            chessBoard.PerformMove(
                rock.CurrentPosition,
               (rock.CurrentPosition.Item1,
                rock.CurrentPosition.Item2 + rockSource));

            chessBoard.SwitchTurn();
        }
    }
}
