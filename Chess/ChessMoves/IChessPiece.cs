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
        Path Moves() { return null; }
        Path Captures() { return null; }
        virtual bool CanReach((int, int) destination) { return false; }
        virtual bool CanCapture((int, int) target) { return false; }
        virtual void PerformMove((int, int) targetMove, ChessBoard chessBoard) { }
        virtual void PerformCapture((int, int) targetCapture, ChessBoard chessBoard) { }
    }
}
