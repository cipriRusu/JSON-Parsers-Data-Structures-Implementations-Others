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
        void MarkPassant(IChessPiece piece, IUserMove move) { }
        bool CanReach(IUserMove move, IBoardState chessBoard) => Moves().Any(x => x.Last() == move.MoveIndex && chessBoard.IsPathClear(x.Skip(1)));
        bool CanCapture(IUserMove move, IBoardState chessBoard) => Captures().Any(x => x.Last() == move.MoveIndex && chessBoard.IsPathClear(x.Skip(1).SkipLast(1)));
        virtual void PerformMove(IUserMove move, IBoardState chessBoard) { }
        virtual void PerformCapture(IUserMove move, IBoardState chessBoard) { }
        void PerformCastlingMove(IUserMove move, IBoardState chessBoard) => chessBoard.PerformMove(this, move);
        void Update(IUserMove move);
    }
}
