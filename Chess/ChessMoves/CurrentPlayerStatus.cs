﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CurrentPlayerStatus
    {
        private readonly Player turnToMove;
        private readonly IBoardState chessBoard;
        private IChessPiece _currentKing;
        private IChessPiece King => chessBoard.GetAllPieces().Where(x => x != null
        && x.PieceType == PieceType.King
        && x.PlayerColour == turnToMove).Single();

        public CurrentPlayerStatus(Player turnToMove, IBoardState chessBoard)
        {
            this.turnToMove = turnToMove;
            this.chessBoard = chessBoard;
            _currentKing = King;
        }

        public bool IsChecked => KingCheckStatus();

        public bool IsCheckMated => KingCheckMateStatus();

        public bool KingPositionCheckStatus((int, int) position)
        {
            var currentBoardState = chessBoard.DeepClone();
            currentBoardState.PerformMove(King, position);
            return new CurrentPlayerStatus(turnToMove, currentBoardState).IsChecked;
        }

        private bool KingCheckStatus()
        {
            IEnumerable<IEnumerable<(int, int)>> diagonalAttacks = 
                GetAttacks(_currentKing,
                new PieceType[] { PieceType.Queen, PieceType.Bishop }, PathType.Diagonals);

            IEnumerable<IEnumerable<(int, int)>> verticalHorizontalAttacks =
                GetAttacks(_currentKing,
                new PieceType[] { PieceType.Queen, PieceType.Rock }, PathType.RowsAndColumns);

            IEnumerable<IEnumerable<(int, int)>> knightAttacks =
                GetAttacks(_currentKing,
                new PieceType[] { PieceType.Knight }, PathType.Knight);

            IEnumerable<IEnumerable<(int, int)>> pawnAttacks =
                GetAttacks(_currentKing,
                new PieceType[] { PieceType.Pawn }, PathType.PawnCapture);

            return diagonalAttacks.Any() || verticalHorizontalAttacks.Any() || knightAttacks.Any() || pawnAttacks.Any();
        }

        private bool KingCheckMateStatus()
        {
            var legalMoves = King.Moves().Where(x => chessBoard.IsPathClear(x));

            foreach (var move in legalMoves)
            {
                var currentBoardState = chessBoard.DeepClone();

                currentBoardState.PerformMove(King, move.Single());

                if (!new CurrentPlayerStatus(turnToMove, currentBoardState).IsChecked)
                {
                    return false;
                }
            }

            return legalMoves.Count() > 0;
        }

        private IEnumerable<IEnumerable<(int, int)>> GetAttacks(IChessPiece currentKing, PieceType[] attackers, params PathType[] pathTypes)
        {
            return new Path(currentKing, pathTypes)
                .Where(x =>
                chessBoard[x.Last()] != null
                && chessBoard.IsPathClear(x.Skip(1).SkipLast(1))
                && chessBoard[x.Last()].PlayerColour == Piece.Opponent(turnToMove)
                && attackers.Contains(chessBoard[x.Last()].PieceType));
        }
    }
}
