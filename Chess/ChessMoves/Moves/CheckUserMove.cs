﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class CheckUserMove : UserMove
    {
        public CheckUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}