using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PerformCastling
    {
        private ChessBoard chessBoard;

        public PerformCastling(ChessBoard chessBoard)
        {
            this.chessBoard = chessBoard;
        }

        internal void Perform(IUserMove move)
        {
            switch (move)
            {
                case KingCastlingUserMove _:
                    KingSideSwapper(move);
                    break;
                case QueenCastlingUserMove _:
                    QueenSideSwapper(move);
                    break;
            }
        }

        private void KingSideSwapper(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    chessBoard.PerformMove(chessBoard[7, 4], new UserMove("Kg1", move.PlayerColor));
                    chessBoard.PerformMove(chessBoard[7, 7], new UserMove("Rf1", move.PlayerColor));
                    break;
                case Player.Black:
                    chessBoard.PerformMove(chessBoard[0, 4], new UserMove("Kg8", move.PlayerColor));
                    chessBoard.PerformMove(chessBoard[0, 7], new UserMove("Rf8", move.PlayerColor));
                    break;
                default:
                    break;
            }
        }

        private void QueenSideSwapper(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    chessBoard.PerformMove(chessBoard[7, 4], new UserMove("Kc1", move.PlayerColor));
                    chessBoard.PerformMove(chessBoard[7, 0], new UserMove("Rd1", move.PlayerColor));
                    break;
                case Player.Black:
                    chessBoard.PerformMove(chessBoard[0, 4], new UserMove("Kc8", move.PlayerColor));
                    chessBoard.PerformMove(chessBoard[0, 0], new UserMove("Rd8", move.PlayerColor));
                    break;
                default:
                    break;
            }
        }
    }
}
