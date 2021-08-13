using ChessGame.Interfaces;
using System.Linq;

namespace ChessMoves
{
    public class CaptureUserMove : UserMove, IUserMove
    {
        public CaptureUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public override bool CanHandle(IPieceState pieceState, IMoveCheck moveCheck)
        {
            if (pieceState.PieceType == PieceType && pieceState.Player == Player)
            {
                var path = pieceState.Captures.Where(x => x.End == Index);

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
