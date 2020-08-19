using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveUserMove : UserMove, IUserMove
    {
        public MoveUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public new virtual void GetCurrentState(IBoardState board) => board.PerformMove(this);

        public new bool ValidateDestination(IChessPiece piece, IBoardState boardState) => piece.CanReach(this, boardState);
    }
}
