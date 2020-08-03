using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class QueenCastlingUserMove : UserMove, IUserMove
    {
        private int CastlingPathLength = 5;
        public QueenCastlingUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public void GetCurrentState(IBoardState board)
        {

        }
    }
}
