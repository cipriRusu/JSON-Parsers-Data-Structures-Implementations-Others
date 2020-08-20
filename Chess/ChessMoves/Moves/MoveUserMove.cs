using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveUserMove : UserMove, IUserMove
    {
        public MoveUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public new virtual void GetCurrentState(IBoard board) => board.PerformMove(this);

        public new bool ValidateDestination(IChessPiece piece, IBoard boardState) => piece.CanReach(this, boardState);
    }
}
