using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChessMoves.Moves
{
    public class EnPassantUserMove : UserMove, IUserMove
    {
        public EnPassantUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public void PerformMoveType(ChessBoard board)
        {
            var validPiece = board.GetAllPieces()
                .Where(
                x =>
                x != null &&
                x.PlayerColour == PlayerColor &&
                x.PieceType == PieceType.Pawn &&
                new ConstraintValidator(x, this).IsValid).Single();

            switch(PlayerColor)
            {
                case Player.White:
                    PerformPassant(board, validPiece, 1);
                    break;
                case Player.Black:
                    PerformPassant(board, validPiece, -1);
                    break;
            }
        }

        private void PerformPassant(ChessBoard board, IChessPiece validPiece, int opponentOffset)
        {
            var opponent = board[(validPiece.CurrentPosition.Item1, validPiece.CurrentPosition.Item2 + opponentOffset)];

            if (opponent != null && opponent.PlayerColour != PlayerColor)
            {
                board.Remove(opponent);
                board.PerformMove(validPiece, MoveIndex);
            }
            else
            {
                throw new UserMoveException(this, "En passant capture not valid!");
            }
        }
    }
}
