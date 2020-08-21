using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IUserMove : ILocation
    {
        Type PieceType { get; }
        Player PlayerColor { get; }
        string NotationIndex { get; }
        bool HasPath(IEnumerable<IPath> paths);
    }
}
