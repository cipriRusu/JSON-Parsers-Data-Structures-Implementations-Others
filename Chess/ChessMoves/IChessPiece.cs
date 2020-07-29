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
        Path Moves() { return null; }
        Path Captures() { return null; }
        void MarkPassant(IChessPiece piece, (int, int) destination) { }
        bool CanReach((int, int) destination, ChessBoard chessBoard) =>
            Moves().Any(x => x.Last() == destination && chessBoard.IsPathClear(x.Skip(1)));
        bool CanCapture((int, int) target, ChessBoard chessBoard) =>
            Captures().Any(x => x.Last() == target && chessBoard.IsPathClear(x.Skip(1).SkipLast(1)));
        virtual void PerformMove((int, int) targetMove, ChessBoard chessBoard) { }
        virtual void PerformCapture((int, int) targetCapture, ChessBoard chessBoard) { }
        void PerformCastlingMove((int, int) targetMove, ChessBoard chessBoard) => chessBoard.PerformMove(this, targetMove);
    }
}
