using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;

namespace ChessMoves
{
    [Serializable]
    public abstract class Piece
    {
        public const int BOARDSIZE = 8;
        public (int, int) CurrentPosition { get; internal set; }
        public Player PlayerColour { get; internal set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public PieceType PieceType { get; internal set; }
        public virtual Path Moves() => null;
        public virtual Path Captures() => null;

        internal Index customIndex = new Index();
        public Piece(string chessBoardIndex, Player playerColour)
        {
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
            File = chessBoardIndex.First();
            Rank = chessBoardIndex.Last();
        }

        public void Update((int, int) newPosition)
        {
            var rankAndFile = new RankAndFile(newPosition);
            CurrentPosition = newPosition;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }
    }
}