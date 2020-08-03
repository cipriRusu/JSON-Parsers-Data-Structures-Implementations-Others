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

        public CurrentPlayerStatus(Player turnToMove, IBoardState chessBoard)
        {
            this.turnToMove = turnToMove;
            this.chessBoard = chessBoard;
            _currentKing = chessBoard.GetKing(turnToMove);
        }

        public bool IsChecked => chessBoard.IsKingAttackedStatus(turnToMove);
        public bool IsCheckMated => KingCheckMateStatus();
        public bool KingPositionCheckStatus(IUserMove move)
        {
            var currentBoardState = chessBoard.DeepClone();
            currentBoardState.PerformMove(_currentKing, move);
            return new CurrentPlayerStatus(turnToMove, currentBoardState).IsChecked;
        }

        private bool KingCheckMateStatus()
        {
            var legalMoves = _currentKing.Moves();

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
