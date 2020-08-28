using ChessGame;
using ChessGame.Interfaces;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public interface IPiece : ILocation, IPathTypes
    {
        Player PlayerColour { get; }
        void Update(IUserMove move);
        bool CanPerform(IBoardOperation boardOperation);
    }
}
