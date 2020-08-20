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
        public PieceType PieceType { get; internal set; }
        public bool IsMoved { get; internal set; }
        public bool IsPassantCapturable { get; private set; }
        public void MarkPassant(IPiece piece, IUserMove move)
        {
            if (piece.PieceType == PieceType.Pawn)
            {
                switch (piece.PlayerColour)
                {
                    case Player.White:
                        IsPassantCapturable = piece.Index.Item1 - move.Index.Item1 == 2;
                        break;
                    case Player.Black:
                        IsPassantCapturable = move.Index.Item1 - piece.Index.Item1 == 2;
                        break;
                }
            }
        }

        public virtual bool CanReach(IUserMove move) => Moves().Any(x => x.End == move.Index);
        public virtual bool CanCapture(IUserMove move) => Captures().Any(x => x.End == move.Index);

        public virtual IEnumerable<IPath> Moves() => null;
        public virtual IEnumerable<IPath> Captures() => null;

        public void Update(IUserMove move)
        {
            var rankAndFile = new RankAndFile(move.Index);
            Index = move.Index;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }

        public void Promote(IBoard chessBoard) => chessBoard.Promote(this);

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

        public virtual void PerformMove(IUserMove move, IBoard chessBoard)
        {
            var validPath = Moves().Where(x => x.End == move.Index && chessBoard.IsMovePathClear(x));
        }

        public virtual void PerformCapture(IUserMove move, IBoard chessBoard)
        {
            var validPath = Captures().Where(x => x.End == move.Index && chessBoard.IsCapturePathClear(x));
        }

        public void FlagAsMoved(bool isMoved) => IsMoved = isMoved;
    }
}