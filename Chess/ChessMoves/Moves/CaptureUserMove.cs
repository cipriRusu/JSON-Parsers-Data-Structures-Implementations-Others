using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CaptureUserMove : UserMove, IUserMove
    {
        public CaptureUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public new void GetCurrentState(IBoardState board)
        {
            board.SetMove(this);
            board.PerformMove(board.PieceToMove, this);
            CheckVerification(board);
        }
        public new bool ValidateDestination(IChessPiece piece, IBoardState boardState) => 
            piece.CanCapture(this, boardState);
    }
}
