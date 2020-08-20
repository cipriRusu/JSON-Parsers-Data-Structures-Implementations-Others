using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CurrentPlayerStatus
    {
        private readonly Player turnToMove;
        private readonly IBoard chessBoard;
        private IChessPiece _currentKing;

        public CurrentPlayerStatus(Player turnToMove, IBoard chessBoard)
        {
            this.turnToMove = turnToMove;
            this.chessBoard = chessBoard;
            _currentKing = chessBoard.GetKing(turnToMove);
        }

        public bool IsChecked => new AttackStatus(chessBoard, _currentKing).IsAttacked;
        public bool IsCheckMated => new AttackStatus(chessBoard, _currentKing).IsCheckMated;
    }
}
