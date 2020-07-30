using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IBoardState
    {
        IEnumerable<IChessPiece> GetAllPieces();
        void Remove(IChessPiece target);
        bool IsPathClear(IEnumerable<(int, int)> path);
        void PerformMove(IChessPiece chessPiece, (int, int) targetMove);
    }
}
