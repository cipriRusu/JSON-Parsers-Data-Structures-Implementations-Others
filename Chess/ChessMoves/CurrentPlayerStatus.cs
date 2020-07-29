﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CurrentPlayerStatus
    {
        private readonly Player turnToMove;
        private readonly ChessBoard chessBoard;
        private IChessPiece _currentKing;
        private IChessPiece King => chessBoard.GetAllPieces().Where(x => x != null
        && x.PieceType == PieceType.King
        && x.PlayerColour == turnToMove).Single();

        public CurrentPlayerStatus(Player turnToMove, ChessBoard chessBoard)
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
                new PathType[] { PathType.Diagonals },
                new PieceType[] { PieceType.Queen, PieceType.Bishop });

            IEnumerable<IEnumerable<(int, int)>> verticalHorizontalAttacks =
                GetAttacks(_currentKing,
                new PathType[] { PathType.RowsAndColumns },
                new PieceType[] { PieceType.Queen, PieceType.Rock });

            IEnumerable<IEnumerable<(int, int)>> knightAttacks =
                GetAttacks(_currentKing,
                new PathType[] { PathType.Knight },
                new PieceType[] { PieceType.Knight });

            IEnumerable<IEnumerable<(int, int)>> pawnAttacks =
                GetAttacks(_currentKing,
                new PathType[] { PathType.PawnCapture },
                new PieceType[] { PieceType.Pawn });

            return diagonalAttacks.Any() || verticalHorizontalAttacks.Any() || knightAttacks.Any() || pawnAttacks.Any();
        }

        private bool KingCheckMateStatus()
        {
            var legalMoves = King.Moves().Where(x => chessBoard.IsPathClear(x));

            foreach(var move in legalMoves)
            {
                var currentBoardState = chessBoard.DeepClone();

                currentBoardState.PerformMove(King, move.Single());

                if(!new CurrentPlayerStatus(turnToMove, currentBoardState).IsChecked)
                {
                    return false;
                }
            }

            return legalMoves.Count() > 0;
        }

        private IEnumerable<IEnumerable<(int, int)>> GetAttacks(IChessPiece currentKing, PathType[] pathTypes, PieceType[] attackers)
        {
            return new Path(currentKing.CurrentPosition, pathTypes)
                .Where(x =>
                chessBoard[x.Last()] != null
                && chessBoard.IsPathClear(x.Skip(1).SkipLast(1))
                && chessBoard[x.Last()].PlayerColour == Piece.Opponent(turnToMove)
                && attackers.Contains(chessBoard[x.Last()].PieceType));
        }
    }
}