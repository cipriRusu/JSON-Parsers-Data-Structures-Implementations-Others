using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PieceException : Exception
    {
        private IUserMove move;
        private IEnumerable<IChessPiece> targetPiece;

        public PieceException(string message) { }

        public PieceException(IUserMove move, IEnumerable<IChessPiece> targetPiece, string message) : base(message)
        {
            this.move = move;
            this.targetPiece = targetPiece;
        }
    }
}
