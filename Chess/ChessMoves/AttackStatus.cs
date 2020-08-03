﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class AttackStatus
    {
        private IBoardState boardState;
        private IChessPiece chessPiece;
        public bool IsAttacked => IsAttackedStatus();

        public AttackStatus(IBoardState boardState, IChessPiece chessPiece)
        {
            this.boardState = boardState;
            this.chessPiece = chessPiece;
        }

        public bool IsAttackedStatus()
        {
            var diagonalAttacks =
                ValidAttacks(chessPiece,
                new PieceType[] { PieceType.Queen, PieceType.Bishop },
                PathType.Diagonals);

            var verticalHorizontalAttacks =
                ValidAttacks(chessPiece,
                new PieceType[] { PieceType.Queen, PieceType.Rock },
                PathType.RowsAndColumns);

            var knightAttacks =
                ValidAttacks(chessPiece,
                new PieceType[] { PieceType.Knight },
                PathType.Knight);

            var pawnAttacks =
                ValidAttacks(chessPiece,
                new PieceType[] { PieceType.Pawn },
                PathType.PawnCapture);

            return diagonalAttacks || verticalHorizontalAttacks || knightAttacks || pawnAttacks;
        }

        private bool ValidAttacks(
            IChessPiece currentKing, PieceType[] attackers, params PathType[] pathTypes) => new Path(currentKing, pathTypes)
                .Where(x => boardState[x.Last()] != null)
                .Where(x => boardState.IsPathClear(x.Skip(1).SkipLast(1)))
                .Where(x => boardState[x.Last()].PlayerColour == Piece.Opponent(currentKing.PlayerColour))
                .Where(x => attackers.Contains(boardState[x.Last()].PieceType))
                .SelectMany(x => x).Any();
    }
}
