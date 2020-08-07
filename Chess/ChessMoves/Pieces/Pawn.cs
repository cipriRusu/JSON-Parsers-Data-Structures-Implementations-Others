﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class Pawn : Piece, IChessPiece
    {
        public Pawn(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour) => 
            PieceType = PieceType.Pawn;

        public override IPath Moves() => new Path(this, PathType.Pawn);
        public override IPath Captures() => new Path(this, PathType.PawnCapture);
        public override void PerformCapture(IUserMove move, IBoardState chessBoard)
        {
            var targetPiece = chessBoard[move.MoveIndex];

            if(Opponent(PlayerColour) == targetPiece.PlayerColour)
            {
                chessBoard.PerformMove(this, move);
            }
        }
    }
}