using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public abstract class Piece : IPiece
    {
        private readonly Index matrixIndexConvertor = new Index();

        public Piece(string chessBoardIndex, Player playerColour)
        {
            Index = matrixIndexConvertor.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
            File = chessBoardIndex.First();
            Rank = chessBoardIndex.Last();
        }
        public (int, int) Index { get; internal set; }
        public Player PlayerColour { get; internal set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public Type PieceType { get; internal set; }
        public virtual IEnumerable<IPath> Moves { get; private set; }
        public virtual IEnumerable<IPath> Captures { get; private set; }
        public virtual void Update(IUserMove move)
        {
            var rankAndFile = new RankAndFile(move.Index);
            Index = move.Index;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }
    }
}