using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IGame
    {
        public IPiece this[(int, int) input] { get; }
        Player TurnToMove { get; set; }
        bool IsCheckMate { get; }
        bool IsCheck { get; }
    }
}
