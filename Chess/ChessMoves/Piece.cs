using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;

namespace ChessMoves
{
    [Serializable]
    public class Piece
    {
        public Piece() { }
        public const int BOARDSIZE = 8;
        public (int, int) CurrentPosition { get; internal set; }
        public Player PlayerColour { get; internal set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public PieceType PieceType { get; internal set; }
        public virtual Path GetLegalMoves() => null;
        public bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);
        internal Index customIndex = new Index();
        public Piece(string chessBoardIndex, Player playerColour)
        {
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
            File = chessBoardIndex.First();
            Rank = chessBoardIndex.Last();
        }
        public Piece((int, int) position, Player playerColour)
        {
            InitializePiece(position);
            PlayerColour = playerColour;
        }
        public void Update((int, int) newPosition)
        {
            InitializePiece(newPosition);
        }

        public static Player Opponent(Player player)
        {
            switch (player)
            {
                case Player.White:
                    return Player.Black;
                case Player.Black:
                    return Player.White;
                default:
                    throw new ArgumentException("Invalid player");
            }
        }

        protected virtual IEnumerable<IEnumerable<(int, int)>> ValidatePath(ChessBoard board, UserMove move)
        {
            switch (move.UserMoveType)
            {
                case UserMoveType.Move:
                    return GetLegalMoves().Where(x => IsLast(x.Last(), move.MoveIndex));
                case UserMoveType.Capture:
                    return GetLegalMoves().Where(x => IsLast(x.Last(), move.MoveIndex) &&
                    IsOpponentColour(board, x.Last()));
                default:
                    throw new ArgumentException("Invalid move type or not yet handled");
            }
        }

        internal virtual bool IsChecked(ChessBoard board, Player player) => false;

        internal virtual bool IsMoveValid(ChessBoard board, UserMove move)
        {
            var currentPath = ValidatePath(board, move).SelectMany(x => x);

            return currentPath.Any() && board.IsPathClear(currentPath.Skip(1).SkipLast(1));
        }

        private bool IsOpponentColour(ChessBoard board, (int, int) expectedOpponent) =>
            board[expectedOpponent.Item1, expectedOpponent.Item2].PlayerColour == Opponent(PlayerColour);

        private bool IsLast((int, int) actualLast, (int, int) expectedLast) => actualLast == expectedLast;

        private void InitializePiece((int, int) position)
        {
            var rankAndFile = new RankAndFile(position);
            CurrentPosition = position;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }
    }
}