using System;
using System.Collections.Generic;

namespace ChessMoves
{
    public class Piece
    {
        public const int BOARDSIZE = 8;
        public (int, int) CurrentPosition { get; internal set; }
        public Player PlayerColour { get; internal set; }
        public PieceType PieceType { get; internal set; }
        public virtual IEnumerable<IEnumerable<(int, int)>> GetLegalMoves() => null;
        public void UpdatePosition((int, int) newPosition) => CurrentPosition = newPosition;
        public bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);
        internal CustomIndex customIndex = new CustomIndex();
        public Piece(string chessBoardIndex, Player playerColour)
        {
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
        }

        public Piece((int, int) pieceIndex, Player playerColour)
        {
            CurrentPosition = pieceIndex;
            PlayerColour = playerColour;
        }
    }
}