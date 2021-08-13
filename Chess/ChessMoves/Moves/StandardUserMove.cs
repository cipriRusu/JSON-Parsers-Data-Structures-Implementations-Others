using ChessGame.Interfaces;
using System;
using System.Linq;

namespace ChessMoves.Moves
{
    public class StandardUserMove : UserMove, IUserMove
    {
        public StandardUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public override bool CanHandle(IPieceState pieceState, IMoveCheck moveCheck)
        {
            if (pieceState.PieceType == PieceType && pieceState.Player == Player)
            {
                var path = pieceState.Moves.Where(x => x.End == Index);

                return path.Any() && path.Any() && moveCheck.IsClear(path.Single());
            }

            return false;
        }

        public override void Perform(IMovePerform boardMove)
        {
            var current = boardMove.Performers.Single();

            Action(current, Index);

            current.Update(this);
        }
    }
}
