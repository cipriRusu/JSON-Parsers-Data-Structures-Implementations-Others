using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public interface IPiece : ILocation, IMovable
    {
        Player PlayerColour { get; }
        PieceType PieceType { get; }
        bool IsMoved { get; }
        bool IsPassantCapturable { get; }
        void Promote(IBoard chessBoard);
        void MarkPassant(IPiece piece, IUserMove move);
        bool CanReach(IUserMove move);
        bool CanCapture(IUserMove move);
        void Update(IUserMove move);
        void FlagAsMoved(bool isMoved);
    }
}
