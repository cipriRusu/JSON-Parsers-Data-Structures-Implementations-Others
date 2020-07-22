using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    internal class SpecialMoveHandler
    {
        private UserMove move;
        private ChessBoard chessBoard;
        private readonly int KING_SIDE = +3;
        private readonly int QUEEN_SIDE = -4;

        public SpecialMoveHandler(UserMove move, ChessBoard chessBoard)
        {
            this.move = move;
            this.chessBoard = chessBoard;

            HandleCastling();
        }

        private void HandleCastling()
        {
            if (!FindKing().IsMoved)
            {
                var swapRock = GetSwapRock(FindKing(), move.UserMoveType);

                switch (move.UserMoveType)
                {
                    case UserMoveType.KingCastling when ValidateCastling(move, CastlingPath(move)):
                        PerformCastling(FindKing(), swapRock, 2, -2);
                        chessBoard.SwitchTurn();
                        break;
                    case UserMoveType.QueenCastling when ValidateCastling(move, CastlingPath(move)):
                        PerformCastling(FindKing(), swapRock, -2, 3);
                        chessBoard.SwitchTurn();
                        break;
                }
            }
        }

        private IEnumerable<(int, int)> CastlingPath(UserMove move)
        {
            switch (move.UserMoveType)
            {
                case UserMoveType.KingCastling:
                    return FullRow(move).Skip(FullRow(move).Count() + QUEEN_SIDE);
                case UserMoveType.QueenCastling:
                    return FullRow(move).SkipLast(KING_SIDE);
                default:
                    return null;
            }
        }
        
        private void PerformCastling(Piece currentKing, Piece swapRock, int kingMoveIndex, int rockMoveIndex)
        {
            chessBoard.PerformMove(
                currentKing.CurrentPosition, 
               (currentKing.CurrentPosition.Item1, 
                currentKing.CurrentPosition.Item2 + kingMoveIndex));
            
            chessBoard.PerformMove(
                swapRock.CurrentPosition, 
               (swapRock.CurrentPosition.Item1, 
                swapRock.CurrentPosition.Item2 + rockMoveIndex));
        }

        private bool ValidateCastling(UserMove currentMove, IEnumerable<(int, int)> castlingPath) => 
            new CurrentPlayerStatus(move.PlayerColor, chessBoard)
                .IsCastlingValid(currentMove, castlingPath);

        private IEnumerable<(int, int)> FullRow(UserMove move)
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

        private Piece GetSwapRock(Piece currentKing, UserMoveType move)
        {
            switch (move)
            {
                case UserMoveType.KingCastling:
                    return GetCastlingRock(currentKing, KING_SIDE);
                case UserMoveType.QueenCastling:
                    return GetCastlingRock(currentKing, QUEEN_SIDE);
                default:
                    return null;
            }
        }

        private Piece GetCastlingRock(Piece currentKing, int castlingSide)
        {
            var locationIndex =
                (currentKing.CurrentPosition.Item1,
                 currentKing.CurrentPosition.Item2 + castlingSide);

            return chessBoard[locationIndex] != null &&
                  !chessBoard[locationIndex].IsMoved ?
                   chessBoard[locationIndex] : null;
        }

        private Piece FindKing() =>
            chessBoard.GetAllPieces().Where(
            x => x != null &&
            x.PieceType == PieceType.King &&
            x.PlayerColour == move.PlayerColor).Single();
    }
}