using ChessGame.Interfaces;
using System;
using System.Collections.Generic;

namespace ChessMoves
{
    public interface IUserMove : ILocation, IPlayer, INotation, IPieceType
    {
        void CallBack(Action<IPiece, (int, int)> action);
        bool CanHandle(IPieceState pieceStats, IMoveCheck boardCheck);
        void Perform(IMovePerform boardMove);
    }
}
