using ChessGame.Interfaces;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public abstract class Piece : IPiece, IPieceState
    {
        private readonly Index Convertor = new Index();

        public Piece(string index, Player player)
        {
            Index = Convertor.GetIndex(index);
            Player = player;
            File = index.First();
            Rank = index.Last();
        }
        public (int, int) Index { get; internal set; }
        public Player Player { get; internal set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public Type PieceType { get; internal set; }
        public virtual IEnumerable<IPath> Moves { get; private set; }
        public virtual IEnumerable<IPath> Captures { get; private set; }
        public virtual bool CanPerform(IUserMove move, IMoveCheck moveCheck) => move.CanHandle(this, moveCheck);
        public virtual void Update(IUserMove move)
        {
            var rankAndFile = new RankAndFile(move.Index);
            Index = move.Index;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }
    }
}