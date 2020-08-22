using ChessMoves;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChessGame
{
    public interface ICastable : IPiece 
    {
        CastlingDirection CastlingDirection { get; set; }
        bool IsMoved { get; set; }
        bool CanCastle(IBoard board);
    }
}
