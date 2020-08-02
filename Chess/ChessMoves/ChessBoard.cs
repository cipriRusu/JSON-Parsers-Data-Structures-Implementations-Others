using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class ChessBoard : IBoardState
    {
        private IUserMove currentMove;
        private IChessPiece[,] board = new IChessPiece[CHESSBOARD_SIZE, CHESSBOARD_SIZE];
        public IChessPiece this[(int, int) index]
        {
            get => board[index.Item1, index.Item2];
            set => board[index.Item1, index.Item2] = value;
        }

        public static readonly int CHESSBOARD_SIZE = 8;
        public ChessBoard() => board = new GameStartup().StartUpBoard;
        public Player TurnToMove { get; private set; } = Player.White;
        public bool IsCheckMate { get; set; }
        public bool IsCheck { get; set; }

        public IChessPiece GetKing(Player player) =>
            GetAllPieces().Where(x => x != null
            && x.PieceType == PieceType.King
            && x.PlayerColour == player).Single();

        public IChessPiece GetMovablePiece => GetHandledPiece(currentMove);

        public IUserMove CurrentMove { set => currentMove = value; }

        public IEnumerable<IUserMove> GetClearKingMoves(IPath paths)
        {
            var moves = paths.SelectMany(x => x).Where(x => this[x] == null);

            foreach (var move in moves)
            {
                yield return new UserMove(move, TurnToMove);
            }
        }

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

        private IEnumerable<IChessPiece> GetAllPieces() =>
            Enumerable.Range(0, CHESSBOARD_SIZE).SelectMany(i =>
            Enumerable.Range(0, CHESSBOARD_SIZE).Select(j => board[i, j]));

        public void PerformMove(IChessPiece piece, IUserMove move)
        {
            piece.MarkPassant(piece, move);
            var formerPosition = piece.CurrentPosition;

            this[move.MoveIndex] = piece;
            this[move.MoveIndex].Update(move);
            this[formerPosition] = null;
        }

        private IChessPiece GetHandledPiece(IUserMove move)
        {
            var validPiece = GetAllPieces().Where(x =>
            x != null &&
            x.PlayerColour == move.PlayerColor &&
            x.PieceType == move.PieceType &&
            move.ValidateDestination(x, this) &&
            new ConstraintValidator(x, move).IsValid);

            MoveAndPieceExceptions(validPiece);

            return validPiece.Single();
        }

        public void Promote(IChessPiece piece) =>
            board[piece.CurrentPosition.Item1,
                piece.CurrentPosition.Item2] = new Queen(
                      string.Concat(piece.File, piece.Rank),
                      piece.PlayerColour);

        public void Remove(IChessPiece target) => this[(target.CurrentPosition.Item1, target.CurrentPosition.Item2)] = null;

        public bool IsPathClear(IEnumerable<(int, int)> input) => input.All(x => this[x] == null);

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

        public bool CheckCastling(IUserMove move)
        {
            switch (move)
            {
                case KingCastlingUserMove _:
                    return CheckKingSideCastling(move);
                case QueenCastlingUserMove _:
                    return CheckQueenSideCastling(move);
            }

            throw new UserMoveException("Move type not valid!!");
        }

        private bool CheckKingSideCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    return board[7, 4] != null && board[7, 7] != null && !board[7, 4].IsMoved && !board[7, 7].IsMoved;
                case Player.Black:
                    return board[0, 4] != null && board[0, 7] != null && !board[0, 4].IsMoved && !board[0, 7].IsMoved;
                default:
                    throw new UserMoveException("Castling not valid!");
            }

            throw new UserMoveException("Move type not valid!");
        }

        private bool CheckQueenSideCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    return board[7, 4] != null && board[7, 0] != null && !board[7, 4].IsMoved && !board[7, 0].IsMoved;
                case Player.Black:
                    return board[0, 4] != null && board[0, 0] != null && !board[0, 4].IsMoved && !board[0, 0].IsMoved;
                default:
                    throw new UserMoveException("Castling not valid!");
            }

            throw new UserMoveException("Move type not valid!");
        }

        public void PerformCastling(IUserMove move)
        {
            switch (move)
            {
                case KingCastlingUserMove _:
                    PerformKingSideCastling(move);
                    break;
                case QueenCastlingUserMove _:
                    PerformQueenSideCastling(move);
                    break;
            }
        }

        private void PerformQueenSideCastling(IUserMove move)
        {
            if (move.PlayerColor == Player.White)
            {
                (this[(7, 2)], this[(7, 4)]) = (this[(7, 4)], this[(7, 2)]);
                (this[(7, 0)], this[(7, 3)]) = (this[(7, 3)], this[(7, 0)]);
            }
            else if (move.PlayerColor == Player.Black)
            {
                (this[(0, 2)], this[(0, 4)]) = (this[(0, 4)], this[(0, 2)]);
                (this[(0, 3)], this[(0, 0)]) = (this[(0, 0)], this[(0, 3)]);
            }
        }

        private void PerformKingSideCastling(IUserMove move)
        {
            if (move.PlayerColor == Player.White)
            {
                (this[(7, 5)], this[(7, 7)]) = (this[(7, 7)], this[(7, 5)]);
                (this[(7, 6)], this[(7, 4)]) = (this[(7, 4)], this[(7, 6)]);
            }
            else if (move.PlayerColor == Player.Black)
            {
                (this[(0, 5)], this[(0, 7)]) = (this[(0, 7)], this[(0, 5)]);
                (this[(0, 6)], this[(0, 4)]) = (this[(0, 4)], this[(0, 6)]);
            }
        }

        private static void MoveAndPieceExceptions(IEnumerable<IChessPiece> validPiece)
        {
            if (!validPiece.Any())
            {
                throw new UserMoveException("Invalid Move!!");
            }
            if (validPiece.Count() > 1)
            {
                throw new PieceException("Multiple pieces can perform move!!");
            }
        }

        private void CheckKingCastlingPath(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    break;
                case Player.Black:
                    break;
            }
        }

        public bool CheckPassant(IUserMove move, out IChessPiece piece)
        {
            piece = GetAllPieces().Where(x =>
            x != null &&
            x.PlayerColour == move.PlayerColor &&
            x.PieceType == PieceType.Pawn &&
            new ConstraintValidator(x, move).IsValid).Single();

            switch (move.PlayerColor)
            {
                case Player.White when
                board[move.MoveIndex.Item1, move.MoveIndex.Item2] == null &&
                this[(piece.CurrentPosition.Item1, piece.CurrentPosition.Item2 + 1)] != null &&
                this[(piece.CurrentPosition.Item1, piece.CurrentPosition.Item2 + 1)].IsPassantCapturable:
                    return true;
                case Player.Black when
                board[move.MoveIndex.Item1, move.MoveIndex.Item2] == null &&
                this[(piece.CurrentPosition.Item1, piece.CurrentPosition.Item2 - 1)] != null &&
                this[(piece.CurrentPosition.Item1, piece.CurrentPosition.Item2 - 1)].IsPassantCapturable:
                    return true;
            }

            return false;
        }

        public void PerformPassant(IUserMove move, IChessPiece piece)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    this[move.MoveIndex] = piece;
                    this[piece.CurrentPosition] = null;
                    board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2 + 1] = null;
                    this[move.MoveIndex].Update(move);
                    break;

                case Player.Black:
                    this[move.MoveIndex] = piece;
                    this[piece.CurrentPosition] = null;
                    board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2 - 1] = null;
                    this[move.MoveIndex].Update(move);
                    break;
            }
        }
    }
}