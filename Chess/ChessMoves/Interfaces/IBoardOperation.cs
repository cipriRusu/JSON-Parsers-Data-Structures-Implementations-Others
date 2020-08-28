using ChessMoves;
using ChessMoves.Paths;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChessGame.Interfaces
{
    public interface IBoardOperation
    {
        IUserMove CurrentMove { get; }
        IEnumerable<IPiece> CurrentPieces { get; }
        bool IsClear(IPath path, int frontSkip = 0, int endSkip = 0);
        bool IsOpponent(IPath path, Player player);
        void Apply(IPiece piece, IUserMove move);
    }
}
