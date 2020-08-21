using ChessGame;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public interface IPiece : ILocation, IPerformer, IPerformable
    {
        Player PlayerColour { get; }
        void UpdateAfterMove(IUserMove move);
    }
}
