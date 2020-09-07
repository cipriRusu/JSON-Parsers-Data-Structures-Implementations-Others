using ChessGame.Interfaces;
using System.Runtime.CompilerServices;

namespace ChessMoves
{
    public interface IPieceState : ILocation, IPlayer, IPathTypes, IType
    {

    }
}