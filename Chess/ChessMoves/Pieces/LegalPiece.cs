using ChessGame;
using ChessMoves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public class LegalPiece
    {
        private IBoard board;
        public LegalPiece(IBoard board) => this.board = board;
        public IPiece GetMovablePiece(IUserMove move, out IPath path)
        {
            var piece = board
                .Where(x => x != null)
                .Where(x => x.PlayerColour == move.PlayerColor)
                .Where(x => x.GetType() == move.PieceType)
                .Where(x =>
                x.CanPerform(move) &&
                new ConstraintValidator(x, move).IsValid &&
                new MoveValidator(board, move).ValidatePath(x.GetPath(move)));


            if (piece.Count() > 1) throw new PieceException("Multiple pieces can handle current move");

            if (!piece.Any()) throw new UserMoveException(move, "Input invalid for available pieces");

            var legalPath = piece.Single().GetPath(move);

            path = legalPath;
            return piece.Single();
        }
    }
}
