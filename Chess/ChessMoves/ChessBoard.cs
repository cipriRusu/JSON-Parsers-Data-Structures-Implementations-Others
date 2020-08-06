using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class ChessBoard : IBoardState
    {
        public ChessBoard()
        {
            InitializeWhite();
            InitializeBlack();
        }

        private IChessPiece[,] board = new IChessPiece[ChessboardSize, ChessboardSize];
        private const int ChessboardSize = 8;

        public IChessPiece this[(int, int) index] => board[index.Item1, index.Item2];
        public IChessPiece this[int first, int second] => board[first, second];
        public IChessPiece PieceToMove { get; private set; }
        public bool IsCheckMate { get; set; }
        public bool IsCheck { get; set; }
        public Player TurnToMove { get; set; } = Player.White;
        public IChessPiece GetKing(Player player) => GetAllPieces()
                .Where(x => x != null)
                .Where(x => x.PieceType == PieceType.King)
                .Single(x => x.PlayerColour == player);

        public IEnumerable<IUserMove> AllKingMoves(IChessPiece currentKing)
        {
            var allLegalMoves = currentKing.Moves().Where(x => board[x.Single().Item1, x.Single().Item2] == null);

            foreach (var move in allLegalMoves)
                yield return new UserMove(move.Single(), currentKing.PlayerColour);
        }

        public bool IsPathClear(IEnumerable<(int, int)> input) =>
            input.All(x => board[x.Item1, x.Item2] == null);

        public void PerformMove(IChessPiece piece, IUserMove move)
        {
            piece.MarkPassant(piece, move);
            var (firstIndex, secondIndex) = piece.CurrentPosition;

            board[move.MoveIndex.Item1, move.MoveIndex.Item2] =
            board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2];

            board[move.MoveIndex.Item1, move.MoveIndex.Item2].Update(move);

            board[firstIndex, secondIndex] = null;

            board[move.MoveIndex.Item1, move.MoveIndex.Item2].FlagAsMoved(true);
        }

        public void Promote(IChessPiece piece) =>
            board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2] =
            new Queen(string.Concat(piece.File, piece.Rank), piece.PlayerColour);

        public void Remove(IChessPiece target) =>
            board[target.CurrentPosition.Item1,
                target.CurrentPosition.Item2] = null;

        public void SetMove(IUserMove move)
        {
            var movablePiece = GetAllPieces()
                .Where(x => x != null)
                .Where(x => x.PlayerColour == move.PlayerColor)
                .Where(x => x.PieceType == move.PieceType)
                .Where(x => move.ValidateDestination(x, this) &&
                new ConstraintValidator(x, move).IsValid);

            MoveAndPieceExceptions(movablePiece);

            PieceToMove = movablePiece.Single();
        }

        public IChessPiece GetPiece(IUserMove move) => GetAllPieces()
            .Where(x => x != null)
            .Where(x => x.PlayerColour == move.PlayerColor)
            .Where(x => x.PieceType == move.PieceType)
            .Single(x => new ConstraintValidator(x, move).IsValid);

        public void GetAndPerform(IUserMove move) => move.GetCurrentState(this);

        public bool CheckCastling(IUserMove move) =>
            new CastlingMoveValidator(this).IsValid(move);

        public void PerformCastling(IUserMove move) =>
            new PerformCastling(this).Perform(move);

        public bool CheckPassant(IUserMove move, out IChessPiece chessPiece) =>
            new PassantMoveValidator(this).IsValid(move, out chessPiece);

        public void PerformPassant(IUserMove move, IChessPiece chessPiece) =>
            new PerformPassant(this).Perform(move, chessPiece);

        private IEnumerable<IChessPiece> GetAllPieces() =>
            Enumerable.Range(0, ChessboardSize).SelectMany(i =>
            Enumerable.Range(0, ChessboardSize).Select(j => board[i, j]));

        private IEnumerable<IUserMove> GetMoveType(IEnumerable<string> input) => 
            new MovementParser(input).AllMoves;

        private void MoveAndPieceExceptions(IEnumerable<IChessPiece> movablePiece)
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

        private void InitializeBlack()
        {
            board[0, 0] = new Rock("a8", Player.Black);
            board[0, 1] = new Knight("b8", Player.Black);
            board[0, 2] = new Bishop("c8", Player.Black);
            board[0, 3] = new Queen("d8", Player.Black);
            board[0, 4] = new King("e8", Player.Black);
            board[0, 5] = new Bishop("f8", Player.Black);
            board[0, 6] = new Knight("g8", Player.Black);
            board[0, 7] = new Rock("h8", Player.Black);

            board[1, 0] = new Pawn("a7", Player.Black);
            board[1, 1] = new Pawn("b7", Player.Black);
            board[1, 2] = new Pawn("c7", Player.Black);
            board[1, 3] = new Pawn("d7", Player.Black);
            board[1, 4] = new Pawn("e7", Player.Black);
            board[1, 5] = new Pawn("f7", Player.Black);
            board[1, 6] = new Pawn("g7", Player.Black);
            board[1, 7] = new Pawn("h7", Player.Black);
        }

        private void InitializeWhite()
        {
            board[7, 0] = new Rock("a1", Player.White);
            board[7, 1] = new Knight("b1", Player.White);
            board[7, 2] = new Bishop("c1", Player.White);
            board[7, 3] = new Queen("d1", Player.White);
            board[7, 4] = new King("e1", Player.White);
            board[7, 5] = new Bishop("f1", Player.White);
            board[7, 6] = new Knight("g1", Player.White);
            board[7, 7] = new Rock("h1", Player.White);

            board[6, 0] = new Pawn("a2", Player.White);
            board[6, 1] = new Pawn("b2", Player.White);
            board[6, 2] = new Pawn("c2", Player.White);
            board[6, 3] = new Pawn("d2", Player.White);
            board[6, 4] = new Pawn("e2", Player.White);
            board[6, 5] = new Pawn("f2", Player.White);
            board[6, 6] = new Pawn("g2", Player.White);
            board[6, 7] = new Pawn("h2", Player.White);
        }
    }
}