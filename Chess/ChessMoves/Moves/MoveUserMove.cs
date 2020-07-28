using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveUserMove : UserMove, IUserMove
    {
        public MoveUserMove(string input, Player playerTurn) : base(input, playerTurn)  { }

        public void Move(ChessBoard board)
        {
            var toMove = board.GetAllPieces().Where(x => x != null && x.CanReach(MoveIndex));
        }
    }
}
