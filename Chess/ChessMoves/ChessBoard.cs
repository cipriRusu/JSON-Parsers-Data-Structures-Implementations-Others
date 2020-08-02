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
        public IChessPiece this[(int, int) index] => board[index.Item1, index.Item2];
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

        public void PerformMove(IChessPiece piece, (int, int) destination)
        {
            piece.MarkPassant(piece, destination);
            var formerPosition = piece.CurrentPosition;

            board[destination.Item1, destination.Item2] = board[piece.CurrentPosition.Item1, piece.CurrentPosition.Item2];
            board[destination.Item1, destination.Item2].Update(destination);
            board[formerPosition.Item1, formerPosition.Item2] = null;

            board[destination.Item1, destination.Item2].IsMoved = true;
        }

        public void CurrentMove(IUserMove move) => 
            GetMovablePiece = GetAllPieces().Where(x => 
            x != null && x.PlayerColour == move.PlayerColor && 
            x.PieceType == move.PieceType && 
            x.CanReach(move.MoveIndex, this) && 
            new ConstraintValidator(x, move).IsValid).Single();

        public void Promote(IChessPiece piece) =>
            board[piece.CurrentPosition.Item1,
                  piece.CurrentPosition.Item2] = new Queen(string.Concat(piece.File, piece.Rank),
                                                           piece.PlayerColour);

        public void Remove(IChessPiece target) => board[target.CurrentPosition.Item1, target.CurrentPosition.Item2] = null;

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

        public IEnumerable<(int, int)> ValidAttacks(IChessPiece currentKing, PieceType[] attackers, params PathType[] pathTypes) => new Path(currentKing, pathTypes)
                .Where(x =>
                            this[x.Last()] != null &&
                            IsPathClear(x.Skip(1).SkipLast(1)) &&
                            this[x.Last()].PlayerColour == Piece.Opponent(currentKing.PlayerColour) &&
                            attackers.Contains(this[x.Last()].PieceType)).SelectMany(x => x);

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