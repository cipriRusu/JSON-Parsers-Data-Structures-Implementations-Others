using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IChessPiece
    {
        virtual Path Moves() { return null; }
        virtual Path Captures() { return null; }
        virtual bool CanReach((int, int) destination) { return false; }
    }
}
