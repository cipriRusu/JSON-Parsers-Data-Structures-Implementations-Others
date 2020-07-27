using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class CaptureUserMove : UserMove
    {
        public CaptureUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
