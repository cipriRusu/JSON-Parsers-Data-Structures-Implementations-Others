using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class ChessBoard
    {
        public Piece this[int i, int j] => board[i, j];
        public Piece this[(int, int) index] => board[index.Item1, index.Item2];

        private Piece[,] board = new Piece[CHESSBOARD_SIZE, CHESSBOARD_SIZE];

        public readonly static int CHESSBOARD_SIZE = 8;

        public ChessBoard() => InitializeBoard();

        public Player TurnToMove { get; private set; } = Player.White;
        public bool IsCheckMate { get; private set; }
        public bool IsCheck { get; private set; }

        internal void PerformMoves(IEnumerable<string> userMoves)
        {
            foreach (var move in ConvertToUserMoves(userMoves))
            {
                if (IsSpecialMove(move))
                {
                    new SpecialMoveHandler(move, this);
                }
                if (IsStandardMove(move))
                {
                    Move(GetPiece(move), move);
                }
            }
        }

        private void Move(Piece piece, UserMove move)
        {
            PerformMove(piece.CurrentPosition, move.MoveIndex);

            var currentPlayerStatus = new CurrentPlayerStatus(TurnToMove, this);

            if (currentPlayerStatus.IsChecked)
            {
                throw new ArgumentException();
            }

            SwitchTurn();

            var nextPlayerStatus = new CurrentPlayerStatus(TurnToMove, this);

            IsCheck = nextPlayerStatus.IsChecked;

            if (nextPlayerStatus.IsChecked && nextPlayerStatus.IsCheckMated)
            {
                IsCheckMate = true;
            }
        }

        private bool IsStandardMove(UserMove move) =>
            move.UserMoveType == UserMoveType.Move ||
            move.UserMoveType == UserMoveType.Capture;

        private Piece GetPiece(UserMove move) =>
            GetAllPieces().Where(piece =>
            IsPiece(move, piece) &&
            AllMoveConstraints(move, piece) &&
            CanReachTarget(piece, move)).Single();

        private bool AllMoveConstraints(UserMove move, Piece x) =>
            RankConstraint(move, x) ||
            FileConstraint(move, x) ||
            FileAndRankConstraint(move, x) ||
            NoConstraint(move);

        private bool CanReachTarget(Piece piece, UserMove move)
        {
            switch (move.UserMoveType)
            {
                case UserMoveType.Move:
                    return MoveValidation(piece, move, 1);
                case UserMoveType.Capture:
                    return MoveValidation(piece, move, 1, 1);
                default:
                    return false;
            }
        }

        private bool MoveValidation(Piece piece, UserMove move, int startSkip = 0, int endSkip = 0)
        {
            if (move.UserMoveType == UserMoveType.Capture)
            {
                var path = piece.Captures().Where(x => x.Last() == move.MoveIndex).SelectMany(x => x);
                return path.Count() > 0 && IsPathClear(path.Skip(startSkip).SkipLast(endSkip));
            }

            if (move.UserMoveType == UserMoveType.Move)
            {
                var path = piece.Moves().Where(x => x.Last() == move.MoveIndex).SelectMany(x => x);
                return path.Count() > 0 && IsPathClear(path.Skip(1).SkipLast(endSkip));
            }

            return false;
        }

        private bool IsSpecialMove(UserMove move) =>
            move.UserMoveType == UserMoveType.KingCastling ||
            move.UserMoveType == UserMoveType.QueenCastling ||
            move.UserMoveType == UserMoveType.Promote ||
            move.IsEnPassant == true;

        private bool NoConstraint(UserMove move) =>
            move.SourceFile == '\0' &&
            move.SourceRank == '\0';

        private bool FileAndRankConstraint(UserMove move, Piece x) =>
            move.SourceRank != '\0' &&
            move.SourceFile != '\0' &&
            move.SourceRank == x.Rank &&
            move.SourceFile == x.File;

        private bool FileConstraint(UserMove move, Piece x) =>
            move.SourceFile != '\0' &&
            move.SourceRank == '\0' &&
            move.SourceFile == x.File;

        private bool RankConstraint(UserMove move, Piece x) =>
            move.SourceRank != '\0' &&
            move.SourceFile == '\0' &&
            move.SourceRank == x.Rank;

        public bool IsPiece(UserMove move, Piece x) =>
            x != null &&
            x.PlayerColour == move.PlayerColor &&
            x.PieceType == move.PieceType;

        public IEnumerable<Piece> GetAllPieces() =>
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

        public void PerformMove((int, int) source, (int, int) destination)
        {
            board[destination.Item1, destination.Item2] = board[source.Item1, source.Item2];
            board[destination.Item1, destination.Item2].Update(destination);
            board[source.Item1, source.Item2] = null;

            board[destination.Item1, destination.Item2].IsMoved = true;
        }

        public bool IsPathClear(IEnumerable<(int, int)> input) => input.All(x => this[x] == null);

        private IEnumerable<UserMove> ConvertToUserMoves(IEnumerable<string> input)
        {
            foreach (var move in input.Select(x => x.Split(' ')))
            {
                switch (move.Count())
                {
                    case 1:
                        yield return new UserMove(move.First()) { PlayerColor = Player.White };
                        break;
                    case 2:
                        yield return new UserMove(move.First()) { PlayerColor = Player.White };
                        yield return new UserMove(move.Last()) { PlayerColor = Player.Black };
                        break;
                    default:
                        throw new ArgumentException("Input not properly formated");
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

        private void InitializeBoard()
        {
            InitializeWhite();
            InitializeBlack();
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