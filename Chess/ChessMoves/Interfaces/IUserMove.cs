using ChessGame.Interfaces;
using System;

namespace ChessMoves
{
    public interface IUserMove : ILocation, IPlayer, INotation, IPieceType { }
}
