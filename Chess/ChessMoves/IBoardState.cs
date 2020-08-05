﻿using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IBoardState
    {
        public IChessPiece[,] Board { get; set; }
        IChessPiece this[(int, int) index] { get; }
        IChessPiece this[int first, int second] { get; set; }
        IChessPiece GetMovablePiece { get; }
        bool IsCheckMate { get; set; }
        bool IsCheck { get; set; }
        Player TurnToMove { get; }
        bool CheckCastling(IUserMove move);
        bool CheckPassant(IUserMove enPassantUserMove, out IChessPiece chessPiece);
        IChessPiece GetPiece(IUserMove move);
        void PerformPassant(IUserMove enPassantUserMove, IChessPiece chessPiece);
        void SetMove(IUserMove move);
        IChessPiece GetKing(Player player);
        IEnumerable<IUserMove> GetAllKingMoves(IChessPiece currentKing);
        bool IsPathClear(IEnumerable<(int, int)> path);
        void PerformCastling(IUserMove move);
        void PerformMove(IChessPiece chessPiece, IUserMove move);
        void Promote(IChessPiece piece);
        void Remove(IChessPiece target);
    }
}
