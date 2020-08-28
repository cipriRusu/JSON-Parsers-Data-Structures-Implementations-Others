using ChessGame.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ChessMoves.Moves
{
    public class StandardUserMove : UserMove, IUserMove
    {
        public StandardUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public override bool CanReach(IBoardOperation boardOperation, IPathTypes pathTypes)
        {
            var path = pathTypes.Moves.Where(x => x.End == Index);

            return path.Count() > 0 && boardOperation.IsClear(path.Single(), 1, 0);
        }

        public override void Move(IBoardOperation boardOperation)
        {
            if (!boardOperation.CurrentPieces.Any()) 
                throw new UserMoveException(this, "No piece available to handle current move");

            if (boardOperation.CurrentPieces.Count() > 1) 
                throw new PieceException(this, boardOperation.CurrentPieces, "Multiple pieces can handle current move");

            boardOperation.Apply(boardOperation.CurrentPieces.Single(), this);
        }
    }
}
