using ChessGame.Interfaces;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CaptureUserMove : UserMove, IUserMove
    {
        public CaptureUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public override bool CanReach(IBoardOperation boardOperation, IPathTypes pathTypes)
        {
            var path = pathTypes.Captures.Where(x => x.End == Index);

            return 
                path.Count() > 0 && 
                boardOperation.IsClear(path.Single(), 1, 1) &&
                boardOperation.IsOpponent(path.Single(), PlayerColor);
        }

        public override void Move(IBoardOperation boardOperation)
        {
            if (!boardOperation.CurrentPieces.Any()) 
                throw new UserMoveException(this, "No pieces found that can handle current move");

            if (boardOperation.CurrentPieces.Count() > 1) 
                throw new PieceException(this, boardOperation.CurrentPieces, "Multiple pieces found that can handle current move");

            boardOperation.Apply(boardOperation.CurrentPieces.Single(), this);
        }
    }
}
