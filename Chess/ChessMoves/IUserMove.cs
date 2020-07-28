using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IUserMove
    {
        PieceType PieceType { get; }
        Player PlayerColor { get; }
        (int, int) MoveIndex { get; }
        char SourceFile { get; }
        char SourceRank { get; }
        public virtual void PerformMoveType(ChessBoard board) { }
    }
}
