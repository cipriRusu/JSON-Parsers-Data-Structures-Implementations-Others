﻿using ChessMoves;
using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Performers
{
    class MoveChecker
    {
        public MoveChecker(Piece piece) => Piece = piece;

        public Piece Piece { get; }

        internal bool CanPerform(IUserMove move)
        {
            if (move is MoveUserMove)
                return move.HasPath(Piece.Moves());
            else if (move is CaptureUserMove)
                return move.HasPath(Piece.Captures());
            return false;
        }
    }
}
