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

        public Piece(string chessBoardIndex, Player playerColour)
        {
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
            File = chessBoardIndex.First();
            Rank = chessBoardIndex.Last();
        }

        public Piece((int, int) pieceIndex, Player playerColour)
        {
            var rankAndFile = new RankAndFile(pieceIndex);
            CurrentPosition = pieceIndex;
            PlayerColour = playerColour;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }

        public void UpdatePosition((int, int) newPosition)
        {
            var rankAndFile = new RankAndFile(newPosition);
            CurrentPosition = newPosition;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }

        internal virtual bool IsChecked(Piece[,] board) => false;
        internal virtual Piece[,] Move(UserMove move, Piece[,] board) => Movement(move, board);
        internal virtual Piece[,] MoveTo((int, int) input, Piece[,] board) => SwapPiecesAndUpdate(input, board);
        internal virtual bool IsCheckMate(Piece[,] chessBoard) => false;
        internal virtual IEnumerable<IEnumerable<(int, int)>> PawnCapture() => null;

        private Piece[,] SwapPiecesAndUpdate((int, int) input, Piece[,] board)
        {
            board[input.Item1, input.Item2] = board[CurrentPosition.Item1, CurrentPosition.Item2];
            board[CurrentPosition.Item1, CurrentPosition.Item2] = null;
            board[input.Item1, input.Item2].UpdatePosition(input);

            return board;
        }

        private Piece[,] Movement(UserMove move, Piece[,] board)
        {
            var moves =
                GetLegalMoves()
                .Where(x => x.Last() == move.MoveIndex && x.CheckPath(board, move.UserMoveType));

            return move.UserMoveType == UserMoveType.Move && moves.Count() > 0 ?
            SwapPiecesAndUpdate(move.MoveIndex, board) : board;
        }
    }
}