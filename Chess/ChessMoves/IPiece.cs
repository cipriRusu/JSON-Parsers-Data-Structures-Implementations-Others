using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IChessPiece
    {
        Path Moves();
        Path Captures();
    }
}
