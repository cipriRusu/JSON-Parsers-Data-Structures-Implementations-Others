using ChessGame;
using ChessGame.Interfaces;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public interface IPiece : ILocation, IPlayer, IPathTypes
    {
        void Update(IUserMove move);
        bool CanPerform(IUserMove move, IBoardCheck boardCheck);
    }
}
