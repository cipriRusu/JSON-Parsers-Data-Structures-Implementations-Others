using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class ChessBoard : IBoardState
    {
        private IChessPiece[,] board;
        private const int ChessboardSize = 8;

        public IChessPiece this[(int, int) index]
        {
            get => board[index.Item1, index.Item2];
            set => board[index.Item1, index.Item2] = value;
        }

        public IChessPiece this[int first, int second]
        {
            get => board[first, second];
            set => board[first, second] = value;
        }

        public IChessPiece this[IChessPiece piece]
        {
            get => piece;
            set => board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2] = value;
        }
        public IChessPiece GetMovablePiece { get; private set; }
        public bool IsCheckMate { get; set; }
        public bool IsCheck { get; set; }
        public ChessBoard() => new Game(this);
        public Player TurnToMove { get; private set; } = Player.White;

        public void SetBoardLayout(IChessPiece[,] pieces) => board = pieces;
        public bool IsCastlingValid(IUserMove move) => new ValidateCastling(this).IsValid(move);

        public IChessPiece GetKing(Player player) => GetAllPieces()
                .Where(x => x != null)
                .Where(x => x.PieceType == PieceType.King).Single(x => x.PlayerColour == player);

        public IEnumerable<IUserMove> GetAllKingMoves(IChessPiece currentKing)
        {
            var allLegalMoves = currentKing.Moves().Where(x => board[x.Single().Item1, x.Single().Item2] == null);

            foreach (var move in allLegalMoves)
                yield return new UserMove(move.Single(), currentKing.PlayerColour);
        }

        public bool IsPathClear(IEnumerable<(int, int)> input) => input.All(x => board[x.Item1, x.Item2] == null);

        public void PerformMove(IChessPiece piece, IUserMove move)
        {
            piece.MarkPassant(piece, move);
            var (firstIndex, secondIndex) = piece.CurrentPosition;

            board[move.MoveIndex.Item1,
                move.MoveIndex.Item2] = board[piece.CurrentPosition.Item1,
                piece.CurrentPosition.Item2];
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

        public void SetCurrentMove(IUserMove move)
        {
            var movablePiece = GetAllPieces()
                .Where(x => x != null)
                .Where(x => x.PlayerColour == move.PlayerColor)
                .Where(x => x.PieceType == move.PieceType)
                .Where(x => move.ValidateDestination(x, this) &&
                new ConstraintValidator(x, move).IsValid);

            MoveAndPieceExceptions(movablePiece);

            GetMovablePiece = movablePiece.Single();
        }

        public IChessPiece GetPiece(IUserMove move) => GetAllPieces()
            .Where(x => x != null)
            .Where(x => x.PlayerColour == move.PlayerColor)
            .Where(x => x.PieceType == move.PieceType)
            .Single(x => new ConstraintValidator(x, move).IsValid);

        public void PerformCastling(IUserMove move) => new PerformCastling(this).Perform(move);

        public bool CheckPassant(IUserMove move, out IChessPiece chessPiece) =>new ValidatePassant(this).CheckPassant(move, out chessPiece);

        public void PerformPassant(IUserMove move, IChessPiece chessPiece)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    this[chessPiece.CurrentPosition.Item1, chessPiece.CurrentPosition.Item2 + 1] = null;
                    PerformMove(chessPiece, move);
                    break;

                case Player.Black:
                    this[chessPiece.CurrentPosition.Item1, chessPiece.CurrentPosition.Item2 - 1] = null;
                    PerformMove(chessPiece, move);
                    break;
            }
        }

        private IEnumerable<IChessPiece> GetAllPieces() =>
            Enumerable.Range(0, ChessboardSize).SelectMany(i =>
            Enumerable.Range(0, ChessboardSize).Select(j => board[i, j]));

        private IEnumerable<IUserMove> GetMoveType(IEnumerable<string> input)
        {
            foreach (var move in input.Select(x => x.Split(' ')))
            {
                switch (move.Length)
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

        private void SwitchTurn()
        {
            switch (TurnToMove)
            {
                case Player.White:
                    TurnToMove = Player.Black;
                    break;
                case Player.Black:
                    TurnToMove = Player.White;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}