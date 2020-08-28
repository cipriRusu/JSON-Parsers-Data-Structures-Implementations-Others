using ChessGame.Interfaces;
using System;

namespace ChessMoves
{
    public interface IUserMove : ILocation
    {
        Type PieceType { get; }
        Player PlayerColor { get; }
        string NotationIndex { get; }
        bool CanReach(IBoardOperation boardOperation, IPathTypes pathTypes);
        void Move(IBoardOperation boardOperation);
    }
}
