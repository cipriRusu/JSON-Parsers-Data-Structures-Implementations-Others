using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public interface IChessPiece
    {
        char File { get; }
        char Rank { get; }
        (int, int) CurrentPosition { get; }
        Player PlayerColour { get; }
        PieceType PieceType { get; }
        bool IsMoved { get; }
        IPath Moves();
        IPath Captures();
        void Promote(IBoardState chessBoard);
        void MarkPassant(IChessPiece piece, IUserMove move);
        bool CanReach(IUserMove move, IBoardState chessBoard);
        bool CanCapture(IUserMove move, IBoardState chessBoard);
        void Update(IUserMove move);
    }
}
