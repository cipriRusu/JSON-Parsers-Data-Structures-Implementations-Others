using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public interface IPiece : ILocation
    {
        Player PlayerColour { get; }
        PieceType PieceType { get; }
        bool IsMoved { get; }
        bool IsPassantCapturable { get; }
        IEnumerable<IPath> Moves();
        IEnumerable<IPath> Captures();
        void Promote(IBoard chessBoard);
        void MarkPassant(IPiece piece, IUserMove move);
        bool CanReach(IUserMove move, IBoard chessBoard);
        bool CanCapture(IUserMove move, IBoard chessBoard);
        void Update(IUserMove move);
        void FlagAsMoved(bool isMoved);
    }
}
