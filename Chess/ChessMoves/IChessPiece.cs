using System;
using System.Collections.Generic;
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
        Path Moves() { return null; }
        Path Captures() { return null; }
        virtual bool CanReach((int, int) destination, ChessBoard chessBoard) { return false; }
        virtual bool CanCapture((int, int) target, ChessBoard chessBoard) { return false; }
        virtual void PerformMove((int, int) targetMove, ChessBoard chessBoard) { }
        virtual void PerformCapture((int, int) targetCapture, ChessBoard chessBoard) { }
        void PerformCastlingMove((int, int) targetMove, ChessBoard chessBoard) => chessBoard.PerformMove(this, targetMove);
    }
}
