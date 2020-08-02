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
        IEnumerable<IChessPiece> GetAllPieces();
        void Remove(IChessPiece target);
        void CurrentMove(IUserMove move);
        bool IsPathClear(IEnumerable<(int, int)> path);
        void PerformMove(IChessPiece chessPiece, (int, int) targetMove);
        void Promote(IChessPiece piece);
        IEnumerable<(int, int)> ValidAttacks(IChessPiece currentKing, PieceType[] attackers, params PathType[] pathTypes);
    }
}
