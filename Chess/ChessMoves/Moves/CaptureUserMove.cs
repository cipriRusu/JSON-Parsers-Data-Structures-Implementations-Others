using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CaptureUserMove : UserMove, IUserMove
    {
        public CaptureUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public void GetCurrentState(IBoardState board)
        {
            var current = board.GetAllPieces()
                .Where(x => x != null
                            && x.PlayerColour == PlayerColor
                            && x.PieceType == PieceType
                            && x.CanCapture(MoveIndex, board)
                            && new ConstraintValidator(x, this).IsValid);

            MoveAndPieceExceptions(this, current);

            current.Single().PerformCapture(MoveIndex, board);

            CheckVerification(board);
        }
    }
}
