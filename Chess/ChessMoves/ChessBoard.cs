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

        public IEnumerable<IChessPiece> GetAllPieces() =>
            Enumerable.Range(0, CHESSBOARD_SIZE).SelectMany(i =>
            Enumerable.Range(0, CHESSBOARD_SIZE).Select(j => board[i, j]));

        public bool IsPiece((int, int) currentPosition, PieceType pieceType, Player player)
        {
            return
                this[currentPosition] != null &&
                this[currentPosition].CurrentPosition == currentPosition &&
                this[currentPosition].PieceType == pieceType &&
                this[currentPosition].PlayerColour == player;
        }

        public void PerformMove(IChessPiece piece, IUserMove move)
        {
            piece.MarkPassant(piece, move.MoveIndex);
            var formerPosition = piece.CurrentPosition;

            board[move.MoveIndex.Item1, move.MoveIndex.Item2] = board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2];
            board[move.MoveIndex.Item1, move.MoveIndex.Item2].Update(move);
            board[formerPosition.Item1, formerPosition.Item2] = null;

            board[move.MoveIndex.Item1, move.MoveIndex.Item2].IsMoved = true;
        }

        public IChessPiece GetKing(Player player) => GetAllPieces()
                .Where(x => x != null)
                .Where(x => x.PieceType == PieceType.King)
                .Where(x => x.PlayerColour == player).Single();

        public void CurrentMove(IUserMove move) =>
        GetMovablePiece = GetAllPieces()
        .Where(x => x != null)
        .Where(x => x.PlayerColour == move.PlayerColor)
        .Where(x => x.PieceType == move.PieceType)
        .Where(x => move.ValidateDestination(x, this) &&
        new ConstraintValidator(x, move).IsValid).Single();

        public void Promote(IChessPiece piece) =>
            board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2] = 
            new Queen(string.Concat(piece.File, piece.Rank), piece.PlayerColour);

        public void Remove(IChessPiece target) => board[target.CurrentPosition.Item1, target.CurrentPosition.Item2] = null;

        public bool IsPathClear(IEnumerable<(int, int)> input) => input.All(x => board[x.Item1, x.Item2] == null);

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

        private bool ValidAttacks(
            IChessPiece currentKing, PieceType[] attackers, params PathType[] pathTypes) => new Path(currentKing, pathTypes)
                .Where(x => board[x.Last().Item1, x.Last().Item2] != null)
                .Where(x => IsPathClear(x.Skip(1).SkipLast(1)))
                .Where(x => board[x.Last().Item1, x.Last().Item2].PlayerColour == Piece.Opponent(currentKing.PlayerColour))
                .Where(x => attackers.Contains(board[x.Last().Item1, x.Last().Item2].PieceType))
                .SelectMany(x => x).Any();

        public bool IsKingAttackedStatus(Player player)
        {
            var diagonalAttacks = 
                ValidAttacks(GetKing(player),
                new PieceType[] { PieceType.Queen, PieceType.Bishop },
                PathType.Diagonals);

            var verticalHorizontalAttacks = 
                ValidAttacks(GetKing(player),
                new PieceType[] { PieceType.Queen, PieceType.Rock },
                PathType.RowsAndColumns);

            var knightAttacks = 
                ValidAttacks(GetKing(player),
                new PieceType[] { PieceType.Knight },
                PathType.Knight);

            var pawnAttacks = 
                ValidAttacks(GetKing(player),
                new PieceType[] { PieceType.Pawn },
                PathType.PawnCapture);

            return diagonalAttacks || verticalHorizontalAttacks || knightAttacks || pawnAttacks;
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
    }
}