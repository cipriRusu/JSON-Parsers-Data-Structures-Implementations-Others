using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class Piece
    {
        public const int BOARDSIZE = 8;
        public (int, int) CurrentPosition { get; internal set; }
        public Player PlayerColour { get; internal set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public PieceType PieceType { get; internal set; }
        public virtual IEnumerable<IEnumerable<(int, int)>> GetLegalMoves() => null;
        public bool CheckIndexes(int x, int y) => (x >= 0 && x <= 7) && (y >= 0 && y <= 7);

        internal Index customIndex = new Index();

        public void UpdatePosition((int, int) newPosition)
        {
            var rankAndFile = new RankAndFile(newPosition);
            CurrentPosition = newPosition;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }

        public Piece(string chessBoardIndex, Player playerColour)
        {
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
            File = chessBoardIndex.First();
            Rank = chessBoardIndex.Last();
        }

        public Piece((int, int) pieceIndex, Player playerColour)
        {
            var rankAndFile = new RankAndFile(CurrentPosition);
            CurrentPosition = pieceIndex;
            PlayerColour = playerColour;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }

        internal virtual bool IsChecked(Piece[,] board) => false;

        internal virtual Piece[,] Move(UserMove move, Piece[,] board)
        {
            var moves = GetLegalMoves().Where(x => x.Last() == move.MoveIndex && x.IsMovePathClear(board));

            if (move.UserMoveType == UserMoveType.Move)
            {
                if (moves.Count() > 0)
                {
                    board[move.MoveIndex.Item1, move.MoveIndex.Item2] = board[CurrentPosition.Item1, CurrentPosition.Item2];
                    board[CurrentPosition.Item1, CurrentPosition.Item2] = null;
                    board[move.MoveIndex.Item1, move.MoveIndex.Item2].UpdatePosition(move.MoveIndex);
                }
            }

            return board;
        }

        internal virtual bool IsCheckMate(Piece[,] testBoard) => false;
        internal virtual IEnumerable<IEnumerable<(int, int)>> PawnCapture() => null;
    }
}