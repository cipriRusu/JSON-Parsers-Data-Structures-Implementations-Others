using ChessGame.Interfaces;
using System.Linq;

namespace ChessMoves.Moves
{
    public class StandardUserMove : UserMove, IUserMove
    {
        public StandardUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public override bool CanHandle(IValidate validator, IBoardCheck boardCheck)
        {
            if (validator.IsPiece(this))
            {
                var path = validator.Moves.Where(x => x.End == Index);

                return path.Any() 
                    && (boardCheck.IsClear(path.Single()) ? true : 
                    throw new UserMoveException(this, "Illegal move due to unclear path!"));
            }

            return false;
        }
    }
}
