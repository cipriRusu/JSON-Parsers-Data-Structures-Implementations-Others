using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class PassantMoveValidator
    {
        private IBoard chessBoard;

        public PassantMoveValidator(IBoard chessBoard) => this.chessBoard = chessBoard;

        public bool IsValid(IUserMove move, out IPiece chessPiece)
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

        private bool IsClearAndMarkedForCapture(IUserMove move, IPiece performerPiece, int neighbouringIndex)
        {
            return 
                chessBoard[performerPiece.Index.Item1, performerPiece.Index.Item2 + neighbouringIndex] != null &&
                chessBoard[performerPiece.Index.Item1, performerPiece.Index.Item2 + neighbouringIndex].IsPassantCapturable &&
                chessBoard[move.Index] == null;
        }
    }
}
