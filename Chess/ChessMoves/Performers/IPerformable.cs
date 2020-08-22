using ChessMoves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public interface IPerformable
    {
        bool CanPerform(IUserMove move);
        IPath GetPath(IUserMove move);
    }
}
