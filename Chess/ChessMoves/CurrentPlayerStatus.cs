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
            Piece currentKing = FindKing();

            IEnumerable<IEnumerable<(int, int)>> diagonalAttacks =
                GetAttacks(currentKing,
                new PathType[] { PathType.Diagonals },
                new PieceType[] { PieceType.Queen, PieceType.Bishop });

            IEnumerable<IEnumerable<(int, int)>> verticalHorizontalAttacks =
                GetAttacks(currentKing,
                new PathType[] { PathType.RowsAndColumns },
                new PieceType[] { PieceType.Queen, PieceType.Rock });

            IEnumerable<IEnumerable<(int, int)>> knightAttacks =
                GetAttacks(currentKing,
                new PathType[] { PathType.Knight },
                new PieceType[] { PieceType.Knight });

            IEnumerable<IEnumerable<(int, int)>> pawnAttacks =
                GetAttacks(currentKing, 
                new PathType[] { PathType.PawnCapture }, 
                new PieceType[] { PieceType.Pawn });

            return diagonalAttacks.Any() || verticalHorizontalAttacks.Any() || knightAttacks.Any() || pawnAttacks.Any();
        }

        private IEnumerable<IEnumerable<(int, int)>> GetAttacks(Piece currentKing, PathType[] pathTypes, PieceType[] attackers)
        {
            return new Path(currentKing.CurrentPosition, pathTypes)
                .Where(x =>
                chessBoard[x.Last()] != null &&
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                chessBoard[x.Last()].PlayerColour == Piece.Opponent(turnToMove) &&
                attackers.Contains(chessBoard[x.Last()].PieceType));
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
            chessBoard.GetAllPieces().Where(x => x != null &&
            x.PieceType == PieceType.King &&
            x.PlayerColour == turnToMove).Single();
    }
}
