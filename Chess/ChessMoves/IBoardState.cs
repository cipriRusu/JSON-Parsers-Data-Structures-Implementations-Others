using ChessMoves.Moves;
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
        IChessPiece GetMovablePiece { get; }
        IChessPiece GetKing(Player player);
        IEnumerable<IUserMove> GetAllKingMoves(IPath paths);
        bool IsKingAttackedStatus(Player player);
        void Remove(IChessPiece target);
        void CurrentMove(IUserMove move);
        bool IsPathClear(IEnumerable<(int, int)> path);
        void PerformMove(IChessPiece chessPiece, IUserMove move);
        void Promote(IChessPiece piece);
    }
}
