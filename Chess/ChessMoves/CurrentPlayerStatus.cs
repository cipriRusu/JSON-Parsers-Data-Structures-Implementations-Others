using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CurrentPlayerStatus
    {
        private Player turnToMove;
        private ChessBoard chessBoard;
        private Piece _currentKing
        {
            get => FindKing();
            set => _currentKing = value;
        }

        public CurrentPlayerStatus(Player turnToMove, ChessBoard chessBoard)
        {
            this.turnToMove = turnToMove;
            this.chessBoard = chessBoard;
        }

        public bool IsChecked => KingCheckStatus();
        public bool IsCheckMated => KingCheckMateStatus();

        public void GetCurrentState(Player turnToMove, ChessBoard chessBoard)
        {
            this.turnToMove = turnToMove;
            this.chessBoard = chessBoard;
        }

        private bool KingCheckStatus()
        {
            IEnumerable<IEnumerable<(int, int)>> diagonalAttacks =
                GetAttacks(_currentKing,
                new PathType[] { PathType.Diagonals },
                new PieceType[] { PieceType.Queen, PieceType.Bishop });

            IEnumerable<IEnumerable<(int, int)>> verticalHorizontalAttacks =
                GetAttacks(_currentKing,
                new PathType[] { PathType.RowsAndColumns },
                new PieceType[] { PieceType.Queen, PieceType.Rock });

            IEnumerable<IEnumerable<(int, int)>> knightAttacks =
                GetAttacks(_currentKing,
                new PathType[] { PathType.Knight },
                new PieceType[] { PieceType.Knight });

            IEnumerable<IEnumerable<(int, int)>> pawnAttacks =
                GetAttacks(_currentKing,
                new PathType[] { PathType.PawnCapture },
                new PieceType[] { PieceType.Pawn });

            return diagonalAttacks.Any() || verticalHorizontalAttacks.Any() || knightAttacks.Any() || pawnAttacks.Any();
        }

        private IEnumerable<IEnumerable<(int, int)>> GetAttacks(Piece currentKing, PathType[] pathTypes, PieceType[] attackers)
        {
            return new Path(currentKing.CurrentPosition, pathTypes)
                .Where(x =>
                chessBoard[x.Last()] != null
                && chessBoard.IsPathClear(x.Skip(1).SkipLast(1))
                && chessBoard[x.Last()].PlayerColour == Piece.Opponent(turnToMove)
                && attackers.Contains(chessBoard[x.Last()].PieceType));
        }

        internal bool IsCastlingValid(UserMove move, IEnumerable<(int, int)> castlingPath)
        {
            switch (move.UserMoveType)
            {
                case UserMoveType.KingCastling:
                    return CastlingValidator(castlingPath, 1);
                case UserMoveType.QueenCastling:
                    return CastlingValidator(castlingPath, 2);
                default:
                    return true;
            }
        }

        private bool CastlingValidator(IEnumerable<(int, int)> castlingPath, int edgeSkip) => 
            KingCastlingValidation(castlingPath) && 
            castlingPath.Skip(edgeSkip)
                        .SkipLast(1)
                        .Select(x => !KingAttackStatus(x))
                        .All(x => true);

        private bool KingCastlingValidation(IEnumerable<(int, int)> castlingPath) =>
            !KingCheckStatus()
            && chessBoard.IsPathClear(castlingPath.Skip(1).SkipLast(1));

        private bool KingAttackStatus((int, int) targetPosition)
        {
            var currentBoardState = chessBoard.DeepClone();

            currentBoardState.PerformMove(FindKing().CurrentPosition, targetPosition);

            return new CurrentPlayerStatus(turnToMove, currentBoardState).IsChecked;
        }

        private bool KingCheckMateStatus()
        {
            var kingMoves = FindKing().Moves().Where(x => chessBoard.IsPathClear(x));

            foreach (var move in kingMoves)
            {
                var currentBoardState = chessBoard.DeepClone();

                currentBoardState.PerformMove(FindKing().CurrentPosition, move.Single());

                if (!new CurrentPlayerStatus(turnToMove, currentBoardState).IsChecked)
                {
                    return false;
                }
            }

            return kingMoves.Count() > 0;
        }

        private Piece FindKing() =>
            chessBoard.GetAllPieces().Where(
            x => x != null
                 && x.PieceType == PieceType.King
                 && x.PlayerColour == turnToMove).Single();
    }
}
