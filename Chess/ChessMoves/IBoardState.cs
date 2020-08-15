using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IBoardState
    {
        IChessPiece this[(int, int) index] { get; }
        IChessPiece this[int first, int second] { get; }
        IChessPiece PieceToMove { get; }
        bool IsCheckMate { get; set; }
        bool IsCheck { get; set; }
        Player TurnToMove { get; set; }
        bool CheckCastling(IUserMove move);
        bool CheckPassant(IUserMove enPassantUserMove, out IChessPiece chessPiece);
        IChessPiece GetPiece(IUserMove move);
        void GetAndPerform(IUserMove move);
        void PerformPassant(IUserMove enPassantUserMove, IChessPiece chessPiece);
        void SetMove(IUserMove move);
        IChessPiece GetKing(Player player);
        IEnumerable<IUserMove> AllKingMoves(IChessPiece currentKing);
        bool IsMovePathClear(IPath input);
        void PerformCastling(IUserMove move);
        void PerformMove(IChessPiece chessPiece, IUserMove move);
        void Promote(IChessPiece piece);
        void Remove(IChessPiece target);
        bool IsCapturePathClear(IPath path);
    }
}
