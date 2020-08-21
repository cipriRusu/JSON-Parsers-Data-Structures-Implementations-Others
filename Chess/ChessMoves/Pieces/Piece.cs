using ChessGame.Moves;
using ChessGame.Performers;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
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
        public virtual bool CanPerform(IUserMove move) => new MoveChecker(this).CanPerform(move);
        public virtual IPath GetPath(IUserMove move) => new MovePath(this).GetPath(move);
        public virtual IEnumerable<IPath> Moves() => null;
        public virtual IEnumerable<IPath> Captures() => null;

        public void UpdateAfterMove(IUserMove move)
        {
            var rankAndFile = new RankAndFile(move.Index);
            Index = move.Index;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }
    }
}