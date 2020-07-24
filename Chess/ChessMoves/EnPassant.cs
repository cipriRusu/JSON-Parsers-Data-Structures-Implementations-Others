using System;

namespace ChessMoves
{
    internal class EnPassant
    {
        private ChessBoard chessBoard;
        private UserMove move;

        public EnPassant(ChessBoard chessBoard, UserMove move)
        {
            this.chessBoard = chessBoard;
            this.move = move;

            EnPassantHandler();
        }

        private void EnPassantHandler()
        {
            if (move.PlayerColor == Player.White)
            {
                if (chessBoard[move.MoveIndex.Item1 + 1, move.MoveIndex.Item2].PlayerColour == Piece.Opponent(move.PlayerColor)
                    && chessBoard[move.MoveIndex.Item1 + 1, move.MoveIndex.Item2].IsPassantCapturable)
                {
                    chessBoard.Remove((move.MoveIndex.Item1 + 1, move.MoveIndex.Item2));
                }
            }
            if (move.PlayerColor == Player.Black)
            {
                if (chessBoard[move.MoveIndex.Item1 - 1, move.MoveIndex.Item2].PlayerColour == Piece.Opponent(move.PlayerColor)
                    && chessBoard[move.MoveIndex.Item1 - 1, move.MoveIndex.Item2].IsPassantCapturable)
                {
                    chessBoard.Remove((move.MoveIndex.Item1 - 1, move.MoveIndex.Item2));
                }
            }
        }
    }
}