using System;
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
            var current = board.GetAllPieces()
                    .Where(x => x != null
                                && x.PlayerColour == PlayerColor
                                && x.PieceType == PieceType
                                && x.CanReach(MoveIndex, board)
                                && new ConstraintValidator(x, this).IsValid);

            MoveAndPieceExceptions(this, current);

            current.Single().PerformMove(MoveIndex, board);

            CheckVerification(board);
        }
    }
}
