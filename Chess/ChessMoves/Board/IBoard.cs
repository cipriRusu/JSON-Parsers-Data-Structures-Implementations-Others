using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IBoard
    {
        IPiece this[(int, int) index] { get; }
        IPiece this[int first, int second] { get; }
        bool CheckCastling(IUserMove move);
        bool CheckPassant(IUserMove enPassantUserMove, out IPiece chessPiece);
        IPiece GetPiece(IUserMove move);
        void GetAndPerform(IUserMove move);
        void PerformPassant(IUserMove enPassantUserMove, IPiece chessPiece);
        void PerformMove(IUserMove move);
        IPiece GetKing(Player player);
        IEnumerable<IUserMove> AllKingMoves(IPiece currentKing);
        bool IsMovePathClear(IPath input);
        void PerformCastling(IUserMove move);
        void Promote(IPiece piece);
        void Remove(IPiece target);
        bool IsCapturePathClear(IPath path);
    }
}
