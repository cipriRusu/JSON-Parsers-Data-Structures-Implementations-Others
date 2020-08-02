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
        IUserMove CurrentMove { set; }
        IChessPiece GetMovablePiece { get; }
        bool CheckCastling(IUserMove move);
        bool CheckPassant(IUserMove move, out IChessPiece piece);
        void PerformPassant(IUserMove move, IChessPiece piece);
        IChessPiece GetKing(Player player);
        IEnumerable<IUserMove> GetClearKingMoves(IPath paths);
        void Remove(IChessPiece target);
        void PerformCastling(IUserMove move);
        bool IsPathClear(IEnumerable<(int, int)> path);
        void PerformMove(IChessPiece chessPiece, IUserMove move);
        void Promote(IChessPiece piece);
    }
}
