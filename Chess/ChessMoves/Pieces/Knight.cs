﻿using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    [Serializable]
    public class Knight : Piece, IPiece
    {
        public Knight(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour) =>
            PieceType = PieceType.Knight;

        public bool CanCapture((int, int) target, IBoard board) => Captures().Any(x => x.End == target);
        public bool CanReach((int, int) destination, IBoard board) => Moves().Any(x => x.End == destination);

        public override IEnumerable<IPath> Moves() => new PathGenerator(this, PathType.Knight).GetEnumerator();
        public override IEnumerable<IPath> Captures() => Moves();
        public override void PerformMove(IUserMove move, IBoard chessBoard)
        {
            var validPath = Moves().Where(x => x.End == move.Index);
            chessBoard.PerformMove(move);
        }
    }
}