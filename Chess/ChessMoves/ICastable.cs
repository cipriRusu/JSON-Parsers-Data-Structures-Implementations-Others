using ChessMoves;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChessGame
{
    public interface ICastable : IPiece 
    { 
        bool IsMoved { get; set; }
        bool CanPerformCastling(IBoard board);
    }
}
