using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class Board : IBoard
    {
        public Board(IPiece[,] board) => this.board = board;

        private IPiece[,] board = new IPiece[ChessboardSize, ChessboardSize];
        private const int ChessboardSize = 8;
        public IPiece this[(int, int) index] => board[index.Item1, index.Item2];
        public IPiece this[int first, int second] => board[first, second];
        public IPiece GetKing(Player player) => GetAllPieces()
                .Where(x => x != null)
                .Where(x => x.PieceType == PieceType.King)
                .Single(x => x.PlayerColour == player);
        private IPiece CurrentMovablePiece { get; set; }

        public IEnumerable<IUserMove> AllKingMoves(IPiece currentKing)
        {
            var allLegalMoves = currentKing.Moves().Where(x => board[x.End.Item1, x.End.Item2] == null);

            foreach (var move in allLegalMoves)
                yield return new UserMove(move.End, currentKing.PlayerColour);
        }

        public bool IsMovePathClear(IPath input) => input.Path.Skip(1).All(x => board[x.Item1, x.Item2] == null);
        public bool IsCapturePathClear(IPath input) => input.Path.Skip(1).SkipLast(1).All(x => board[x.Item1, x.Item2] == null);

        public void PerformMove(IUserMove move)
        {
            CurrentMovablePiece = GetMovablePiece(move);

            CurrentMovablePiece.MarkPassant(CurrentMovablePiece, move);
            var (firstIndex, secondIndex) = CurrentMovablePiece.Index;

            board[move.Index.Item1, move.Index.Item2] =
            board[CurrentMovablePiece.Index.Item1, CurrentMovablePiece.Index.Item2];

            board[move.Index.Item1, move.Index.Item2].Update(move);

            board[firstIndex, secondIndex] = null;

            board[move.Index.Item1, move.Index.Item2].FlagAsMoved(true);
        }

        public void Promote(IPiece piece) =>
            board[piece.Index.Item1, piece.Index.Item2] =
            new Queen(string.Concat(piece.File, piece.Rank), piece.PlayerColour);

        public void Remove(IPiece target) =>
            board[target.Index.Item1,
                target.Index.Item2] = null;

        private IPiece GetMovablePiece(IUserMove move)
        {
            var movablePiece = GetAllPieces()
                .Where(x => x != null)
                .Where(x => x.PlayerColour == move.PlayerColor)
                .Where(x => x.PieceType == move.PieceType)
                .Where(x => move.ValidateDestination(x, this) &&
                new ConstraintValidator(x, move).IsValid);

            MoveAndPieceExceptions(movablePiece);

            return movablePiece.Single();
        }

        public IPiece GetPiece(IUserMove move) => GetAllPieces()
            .Where(x => x != null)
            .Where(x => x.PlayerColour == move.PlayerColor)
            .Where(x => x.PieceType == move.PieceType)
            .Single(x => new ConstraintValidator(x, move).IsValid);

        public void GetAndPerform(IUserMove move) => move.GetCurrentState(this);

        public bool CheckCastling(IUserMove move) => 
            new CastlingMoveValidator(this).IsValid(move);

        public void PerformCastling(IUserMove move) =>
            new PerformCastling(this).Perform(move);

        public bool CheckPassant(IUserMove move, out IPiece chessPiece) =>
            new PassantMoveValidator(this).IsValid(move, out chessPiece);

        public void PerformPassant(IUserMove move, IPiece chessPiece) =>
            new PerformPassant(this).Perform(move, chessPiece);

        private IEnumerable<IPiece> GetAllPieces() =>
            Enumerable.Range(0, ChessboardSize).SelectMany(i =>
            Enumerable.Range(0, ChessboardSize).Select(j => board[i, j]));

        private void MoveAndPieceExceptions(IEnumerable<IPiece> movablePiece)
        {
            if (!movablePiece.Any())
            {
                throw new UserMoveException("No movable piece found");
            }
            if (movablePiece.Count() > 1)
            {
                throw new PieceException("Multiple pieces found that can handle current move");
            }
        }
    }
}