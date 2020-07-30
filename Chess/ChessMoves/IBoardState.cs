using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IBoardState
    {
        IChessPiece this[(int, int) index] { get; }
        bool IsCheckMate { get; set; }
        bool IsCheck { get; set; }
        IEnumerable<IChessPiece> GetAllPieces();
        void Remove(IChessPiece target);
        bool IsPathClear(IEnumerable<(int, int)> path);
        void PerformMove(IChessPiece chessPiece, (int, int) targetMove);
        void Promote(IChessPiece piece);
    }
}
