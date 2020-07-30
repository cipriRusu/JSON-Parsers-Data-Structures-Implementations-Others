﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveUserMove : UserMove, IUserMove
    {
        public MoveUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public virtual void GetCurrentState(IBoardState board) 
        {
            board.CurrentMove(this);

            board.PerformMove(board.GetMovablePiece, MoveIndex);

            CheckVerification(board);
        }
    }
}
