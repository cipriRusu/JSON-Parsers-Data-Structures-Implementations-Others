using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IBoardState
    {
        IChessPiece this[(int, int) index] { get; }
        IChessPiece GetMovablePiece { get; }
        bool IsCheckMate { get; set; }
        bool IsCheck { get; set; }
        bool CanPerformCastling(IUserMove move);
        bool CheckPassant(IUserMove enPassantUserMove);
        void PerformPassant(IUserMove enPassantUserMove);
        void CurrentMove(IUserMove move);
        IChessPiece GetKing(Player player);
        IEnumerable<IUserMove> GetAllKingMoves(IChessPiece currentKing);
        bool IsPathClear(IEnumerable<(int, int)> path);
        void PerformKingSideCastling(IUserMove move);
        void PerformQueenSideCastling(IUserMove move);
        void PerformMove(IChessPiece chessPiece, IUserMove move);
        void Promote(IChessPiece piece);
        void Remove(IChessPiece target);
    }
}
