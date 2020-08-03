using ChessMoves.Moves;
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
            if (move.PlayerColor == Player.White)
            {
                return
                    board[7, 4] != null &&
                    board[7, 7] != null &&
                    !board[7, 4].IsMoved &&
                    !board[7, 7].IsMoved;
            }
            else if (move.PlayerColor == Player.Black)
            {
                return 
                    board[0, 4] != null &&
                    board[0, 7] != null &&
                    !board[0, 4].IsMoved &&
                    !board[0, 7].IsMoved;
            }

            return false;
        }

        private bool VerifyQueenCastling(IUserMove move)
        {
            if (move.PlayerColor == Player.White)
            {
                return
                    board[7, 4] != null &&
                    board[7, 0] != null &&
                    !board[7, 4].IsMoved &&
                    !board[7, 0].IsMoved;

            }
            else if (move.PlayerColor == Player.Black)
            {
                return
                    board[0, 4] != null &&
                    board[0, 0] != null &&
                    !board[0, 4].IsMoved &&
                    !board[0, 0].IsMoved;
            }

            return false;
        }

        public void PerformKingSideCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    (board[7, 7], board[7, 5]) = (board[7, 5], board[7, 7]);
                    (board[7, 4], board[7, 6]) = (board[7, 6], board[7, 4]);
                    break;
                case Player.Black:
                    (board[0, 7], board[0, 5]) = (board[0, 5], board[0, 7]);
                    (board[0, 4], board[0, 6]) = (board[0, 6], board[0, 4]);
                    break;
            }
        }

        public void PerformQueenSideCastling(IUserMove move)
        {
            switch (move.PlayerColor)
            {
                case Player.White:
                    (board[7, 0], board[7, 3]) = (board[7, 3], board[7, 0]);
                    (board[7, 4], board[7, 2]) = (board[7, 2], board[7, 4]);
                    break;
                case Player.Black:
                    (board[0, 0], board[0, 3]) = (board[0, 3], board[0, 0]);
                    (board[0, 4], board[0, 2]) = (board[0, 2], board[0, 4]);
                    break;
            }
        }
    }
}