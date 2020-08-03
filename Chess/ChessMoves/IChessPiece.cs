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
        bool IsPassantCapturable { get; }
        IPath Moves() { return null; }
        IPath Captures() { return null; }
        void Promote(IBoardState chessBoard) { }
        void MarkPassant(IChessPiece piece, (int, int) destination) { }
        bool CanReach(IUserMove move, IBoardState chessBoard) => 
            Moves().Any(x => x.Last() == move.MoveIndex && 
            chessBoard.IsPathClear(x.Skip(1)));
        bool CanCapture(IUserMove move, IBoardState chessBoard) => 
            Captures().Any(x => x.Last() == move.MoveIndex && 
            chessBoard.IsPathClear(x.Skip(1).SkipLast(1)));
        virtual void PerformMove((int, int) targetMove, IBoardState chessBoard) { }
        virtual void PerformCapture((int, int) targetCapture, IBoardState chessBoard) { }
        void Update(IUserMove move);
    }
}
