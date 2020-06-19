using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ChessMoves
{
    public class Piece
    {
        public const int BOARDSIZE = 8;
        public (int, int) CurrentPosition { get; private set; }
        public Player PlayerColour { get; private set; }
        public PieceType PieceType { get; internal set; }
        public virtual IEnumerable<IEnumerable<(int, int)>> GetLegalMoves() => null;
        public void UpdatePosition((int, int) newPosition) => CurrentPosition = newPosition;
        public bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);
        public Piece((int, int) currentPosition, Player playerColour)
        {
            CurrentPosition = currentPosition;
            PlayerColour = playerColour;
        }
    }
}
