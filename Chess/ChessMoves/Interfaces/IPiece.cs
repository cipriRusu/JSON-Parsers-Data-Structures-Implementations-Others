using ChessGame;
using ChessGame.Interfaces;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public interface IPiece : IPieceState
    {
        void Update(IUserMove move);
        bool CanPerform(IUserMove move, IMoveCheck boardCheck);
    }
}
