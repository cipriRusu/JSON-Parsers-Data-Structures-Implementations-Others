using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PerformPassant
    {
        private ChessBoard chessBoard;

        public PerformPassant(ChessBoard chessBoard) => this.chessBoard = chessBoard;

        internal void Perform(IUserMove move, IChessPiece chessPiece)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    chessBoard.Remove(chessBoard[chessPiece.CurrentPosition.Item1, chessPiece.CurrentPosition.Item2 + 1]);
                    chessBoard.PerformMove(chessPiece, move);
                    break;

                case Player.Black:
                    chessBoard.Remove(chessBoard[chessPiece.CurrentPosition.Item1, chessPiece.CurrentPosition.Item2 - 1]);
                    chessBoard.PerformMove(chessPiece, move);
                    break;
            }
        }
    }
}
