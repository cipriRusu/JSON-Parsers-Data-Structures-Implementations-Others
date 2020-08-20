using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IUserMove
    {
        PieceType PieceType { get; }
        Player PlayerColor { get; }
        (int, int) Index { get; }
        char File { get; }
        char Rank { get; }
        void GetCurrentState(IBoard board);
        bool ValidateDestination(IPiece piece, IBoard boardState);
    }
}
