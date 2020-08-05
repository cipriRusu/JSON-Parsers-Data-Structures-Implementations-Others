using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class PassantMoveValidator
    {
        private IBoardState chessBoard;

        public PassantMoveValidator(IBoardState chessBoard) => this.chessBoard = chessBoard;

        public bool IsValid(IUserMove move, out IChessPiece chessPiece)
        {
            var performerPiece = chessBoard.GetPiece(move);

            switch (move.PlayerColor)
            {
                case Player.White:
                    chessPiece = performerPiece;
                    return IsClearAndMarkedForCapture(move, chessPiece, 1);

                case Player.Black:
                    chessPiece = performerPiece;
                    return IsClearAndMarkedForCapture(move, chessPiece, -1);
            }

            chessPiece = null;
            return false;
        }

        private bool IsClearAndMarkedForCapture(IUserMove move, IChessPiece performerPiece, int neighbouringIndex)
        {
            return 
                chessBoard[performerPiece.CurrentPosition.Item1, performerPiece.CurrentPosition.Item2 + neighbouringIndex] != null &&
                chessBoard[performerPiece.CurrentPosition.Item1, performerPiece.CurrentPosition.Item2 + neighbouringIndex].IsPassantCapturable &&
                chessBoard[move.MoveIndex] == null;
        }
    }
}
