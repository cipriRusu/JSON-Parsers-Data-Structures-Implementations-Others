using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class KingCheckMateUserMove : UserMove, IUserMove
    {
        public KingCheckMateUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public new void GetCurrentState(IBoardState board)
        {
            var internalMove = new MoveType(NotationIndex, PlayerColor).Move;
            internalMove.GetCurrentState(board);

            if (new CurrentPlayerStatus(Piece.Opponent(PlayerColor), board).IsCheckMated)
            {
                //TODO
            }
            else
            {
                new UserMoveException(this, "Check move not valid");
            }
        }
    }
}
