using ChessMoves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public interface IKing : IPiece, ICastable
    {
        public bool IsChecked(IBoard board);
        public bool IsCheckMate(IBoard board);
    }
}
