using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IMove
    {
        public PieceType PieceType { get; }
        public Player PlayerColor { get; }
        public (int, int) MoveIndex { get; }
        public char SourceFile { get; }
        public char SourceRank { get; }
    }
}
