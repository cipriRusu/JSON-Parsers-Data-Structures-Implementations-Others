using ChessMoves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Interfaces
{
    public interface IPieceValidator : IPathTypes
    {
        bool IsPiece(IUserMove userMove);
    }
}
