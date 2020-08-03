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
        void GetCurrentState(IBoardState board);
        bool ValidateDestination(IChessPiece piece, IBoardState boardState);
    }
}
