﻿using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class ChessBoard : IBoardState
    {
        private Piece[,] board = new Piece[CHESSBOARD_SIZE, CHESSBOARD_SIZE];
        public IChessPiece this[(int, int) index]
        {
            get => board[index.Item1, index.Item2];
        }

        public static readonly int CHESSBOARD_SIZE = 8;
        public ChessBoard() => board = new GameStartup().StartUpBoard;
        public Player TurnToMove { get; private set; } = Player.White;
        public bool IsCheckMate { get; set; }
        public bool IsCheck { get; set; }
        public IChessPiece GetMovablePiece { get; private set; }

        public bool CanPerformCastling(IUserMove move)
        {
            switch (move)
            {
                case KingCastlingUserMove _:
                    return VerifyKingCastling(move);
                case QueenCastlingUserMove _:
                    return VerifyQueenCastling(move);
            }

            return false;
        }

        public void CurrentMove(IUserMove move) =>
        GetMovablePiece = GetAllPieces()
        .Where(x => x != null)
        .Where(x => x.PlayerColour == move.PlayerColor)
        .Where(x => x.PieceType == move.PieceType)
        .Where(x => move.ValidateDestination(x, this) &&
        new ConstraintValidator(x, move).IsValid).Single();

        private IEnumerable<IChessPiece> GetAllPieces() =>
            Enumerable.Range(0, CHESSBOARD_SIZE).SelectMany(i =>
            Enumerable.Range(0, CHESSBOARD_SIZE).Select(j => board[i, j]));

        public IChessPiece GetKing(Player player) => GetAllPieces()
                .Where(x => x != null)
                .Where(x => x.PieceType == PieceType.King)
                .Where(x => x.PlayerColour == player).Single();

        public IEnumerable<IUserMove> GetAllKingMoves(IChessPiece currentKing)
        {
            var allLegalMoves = currentKing.Moves().Where(x => board[x.Single().Item1, x.Single().Item2] == null);

            foreach (var move in allLegalMoves)
            {
                yield return new UserMove(move.Single(), currentKing.PlayerColour);
            }
        }

        public bool IsPathClear(IEnumerable<(int, int)> input) => input.All(x => board[x.Item1, x.Item2] == null);

        public void PerformMove(IChessPiece piece, IUserMove move)
        {
            piece.MarkPassant(piece, move.MoveIndex);
            var formerPosition = piece.CurrentPosition;

            board[move.MoveIndex.Item1, move.MoveIndex.Item2] = board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2];
            board[move.MoveIndex.Item1, move.MoveIndex.Item2].Update(move);
            board[formerPosition.Item1, formerPosition.Item2] = null;

            board[move.MoveIndex.Item1, move.MoveIndex.Item2].IsMoved = true;
        }

        public void Promote(IChessPiece piece) =>
            board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2] =
            new Queen(string.Concat(piece.File, piece.Rank), piece.PlayerColour);

        public void Remove(IChessPiece target) => board[target.CurrentPosition.Item1, target.CurrentPosition.Item2] = null;

        internal void UserMoves(IEnumerable<string> userMoves)
        {
            if (!userMoves.Any() || userMoves.Count() == 0)
            {
                throw new UserMoveException("No user input provided");
            }

            foreach (var userMove in GetMoveType(userMoves))
            {
                userMove.GetCurrentState(this);

                SwitchTurn();
            }
        }

        private IEnumerable<IUserMove> GetMoveType(IEnumerable<string> input)
        {
            foreach (var move in input.Select(x => x.Split(' ')))
            {
                switch (move.Count())
                {
                    case 1:
                        yield return new MoveType(move.Single(), Player.White).Move;
                        break;
                    case 2:
                        yield return new MoveType(move.First(), Player.White).Move;
                        yield return new MoveType(move.Last(), Player.Black).Move;
                        break;
                }
            }
        }

        public void SwitchTurn()
        {
            switch (TurnToMove)
            {
                case Player.White:
                    TurnToMove = Player.Black;
                    break;
                case Player.Black:
                    TurnToMove = Player.White;
                    break;
            }
        }

        private bool VerifyKingCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    return KingSideVerification(7);
                case Player.Black:
                    return KingSideVerification(0);
            }

            return false;
        }

        private bool VerifyQueenCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    return QueenSideVerification(7);
                case Player.Black:
                    return QueenSideVerification(0);
                default:
                    return false;

            }
        }

        private bool KingSideVerification(int sideIndex)
        {
            var castlingPath = Enumerable.Range(4, 4).Select(x => (sideIndex, x));

            return IsPathClear(castlingPath.Skip(1).SkipLast(1))
                   && board[sideIndex, 4] != null
                   && board[sideIndex, 7] != null
                   && !board[sideIndex, 4].IsMoved
                   && !board[sideIndex, 7].IsMoved;
        }

        private bool QueenSideVerification(int sideIndex)
        {
            var castlingPath = Enumerable.Range(0, 5).Select(x => (sideIndex, x));

            return IsPathClear(castlingPath.Skip(1).SkipLast(1))
                && board[sideIndex, 4] != null
                && board[sideIndex, 0] != null
                && !board[sideIndex, 4].IsMoved
                && !board[sideIndex, 0].IsMoved;
        }

        public void PerformKingSideCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    KingSideSwapper(7);
                    break;
                case Player.Black:
                    KingSideSwapper(0);
                    break;
            }
        }

        public void PerformQueenSideCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    QueenSideSwapper(7);
                    break;
                case Player.Black:
                    QueenSideSwapper(0);
                    break;
            }
        }

        private void KingSideSwapper(int sideIndex)
        {
            (board[sideIndex, 7], board[sideIndex, 5]) = (board[sideIndex, 5], board[sideIndex, 7]);
            (board[sideIndex, 4], board[sideIndex, 6]) = (board[sideIndex, 6], board[sideIndex, 4]);
        }

        private void QueenSideSwapper(int sideIndex)
        {
            (board[sideIndex, 0], board[sideIndex, 3]) = (board[sideIndex, 3], board[sideIndex, 0]);
            (board[sideIndex, 4], board[sideIndex, 2]) = (board[sideIndex, 2], board[sideIndex, 4]);
        }
    }
}