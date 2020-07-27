using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PieceException : Exception
    {
        private UserMove move;
        private IEnumerable<Piece> targetPiece;

        public PieceException(string message) { }

        public PieceException(UserMove move, IEnumerable<Piece> targetPiece, string message) : base(message)
        {
            this.move = move;
            this.targetPiece = targetPiece;
        }
    }
}
