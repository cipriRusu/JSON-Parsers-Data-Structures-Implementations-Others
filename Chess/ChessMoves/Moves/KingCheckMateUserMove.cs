using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class KingCheckMateUserMove : UserMove, IUserMove
    {
        public KingCheckMateUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public void PerformMoveType(ChessBoard board)
        {
            var internalMove = new MoveType(NotationIndex, PlayerColor).Move;
            internalMove.PerformMoveType(board);

            if (new CurrentPlayerStatus(Piece.Opponent(PlayerColor), board).IsCheckMated)
            {
                board.IsCheckMate = true;
            }
            else
            {
                new UserMoveException(this, "Check move not valid");
            }
        }
    }
}
