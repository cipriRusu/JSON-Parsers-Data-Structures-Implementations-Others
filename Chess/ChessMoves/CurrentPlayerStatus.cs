using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CurrentPlayerStatus
    {
        private readonly Player turnToMove;
        private readonly IBoardState chessBoard;
        private IChessPiece _currentKing;
        private IChessPiece King => chessBoard.GetAllPieces().Where(x => x != null
        && x.PieceType == PieceType.King
        && x.PlayerColour == turnToMove).Single();

        public CurrentPlayerStatus(Player turnToMove, IBoardState chessBoard)
        {
            this.turnToMove = turnToMove;
            this.chessBoard = chessBoard;
            _currentKing = King;
        }

        public bool IsChecked => KingCheckStatus();

        public bool IsCheckMated => KingCheckMateStatus();

        public bool KingPositionCheckStatus(IUserMove move)
        {
            var currentBoardState = chessBoard.DeepClone();
            currentBoardState.PerformMove(King, move);
            return new CurrentPlayerStatus(turnToMove, currentBoardState).IsChecked;
        }

        private bool KingCheckStatus()
        {
            var diagonalAttacks = chessBoard
                .ValidAttacks(
                _currentKing,
                new PieceType[] { PieceType.Queen, PieceType.Bishop }, 
                PathType.Diagonals);

            var verticalHorizontalAttacks = chessBoard
                .ValidAttacks(
                _currentKing,
                new PieceType[] { PieceType.Queen, PieceType.Rock },
                PathType.RowsAndColumns);

            var knightAttacks = chessBoard.
                ValidAttacks(
                _currentKing,
                new PieceType[] { PieceType.Knight },
                PathType.Knight);

            var pawnAttacks = chessBoard.
                ValidAttacks(_currentKing,
                new PieceType[] { PieceType.Pawn },
                PathType.PawnCapture);

            return diagonalAttacks.Any() || verticalHorizontalAttacks.Any() || knightAttacks.Any() || pawnAttacks.Any();
        }

        private bool KingCheckMateStatus()
        {
            var legalMoves = King.Moves();

            //.Where(x => new UserMove(x.Single(), turnToMove));

            //foreach (var move in legalMoves)
            //{
            //    var currentBoardState = chessBoard.DeepClone();

            //    currentBoardState.PerformMove(King, move.Single());

            //    if (!new CurrentPlayerStatus(turnToMove, currentBoardState).IsChecked)
            //    {
            //        return false;
            //    }
            //}

            //return legalMoves.Count() > 0;

            return false;
        }
    }
}
