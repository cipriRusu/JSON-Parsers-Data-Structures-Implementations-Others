using ChessMoves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Interfaces
{
    public interface IValidate : IPathTypes
    {
        bool IsPiece(IUserMove userMove);
    }
}
