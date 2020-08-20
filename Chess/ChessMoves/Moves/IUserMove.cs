using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IUserMove : ILocation
    {
        Type PieceType { get; }
        Player PlayerColor { get; }
        void GetCurrentState(IBoard board);
        bool ValidateDestination(IPiece piece, IBoard boardState);
    }
}
