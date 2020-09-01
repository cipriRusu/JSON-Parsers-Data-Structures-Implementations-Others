using System;

namespace ChessMoves
{
    public interface IUserMove : ILocation
    {
        Type PieceType { get; }
        Player PlayerColor { get; }
        string NotationIndex { get; }
    }
}
