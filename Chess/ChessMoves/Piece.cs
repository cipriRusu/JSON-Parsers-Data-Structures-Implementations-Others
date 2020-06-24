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

        internal virtual Piece[,] Move(UserMove move, Piece[,] board)
        {
            var moves = GetLegalMoves().Where(x => x.Last() == move.MoveIndex);

            if (move.UserMoveType == UserMoveType.Move)
            {
                if (moves.Count() > 0)
                {
                    var legalMoves = moves.SelectMany(x => x);
                    board[legalMoves.Last().Item1, legalMoves.Last().Item2] = board[CurrentPosition.Item1, CurrentPosition.Item2];
                    board[CurrentPosition.Item1, CurrentPosition.Item2] = null;
                    board[legalMoves.Last().Item1, legalMoves.Last().Item2].UpdatePosition(move.MoveIndex);
                }
            }

            return board;
        }
    }
}