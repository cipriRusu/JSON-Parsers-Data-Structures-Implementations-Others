using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public abstract class Piece : IChessPiece
    {
        private readonly Index matrixIndexConvertor = new Index();

        public Piece(string chessBoardIndex, Player playerColour)
        {
            CurrentPosition = matrixIndexConvertor.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
            File = chessBoardIndex.First();
            Rank = chessBoardIndex.Last();
        }

        public (int, int) CurrentPosition { get; internal set; }
        public Player PlayerColour { get; internal set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public PieceType PieceType { get; internal set; }
        public bool IsMoved { get; internal set; }
        public bool IsPassantCapturable { get; private set; }
        public void MarkPassant(IChessPiece piece, IUserMove move)
        {
            if (piece.PieceType == PieceType.Pawn)
            {
                switch (piece.PlayerColour)
                {
                    case Player.White:
                        IsPassantCapturable = piece.CurrentPosition.Item1 - move.MoveIndex.Item1 == 2;
                        break;
                    case Player.Black:
                        IsPassantCapturable = move.MoveIndex.Item1 - piece.CurrentPosition.Item1 == 2;
                        break;
                }
            }
        }

        public virtual bool CanReach(IUserMove move, IBoardState chessBoard) => 
            Moves().Any(x => x.End == move.MoveIndex && chessBoard.IsMovePathClear(x));

        public virtual bool CanCapture(IUserMove move, IBoardState chessBoard) =>
            Captures().Any(x => x.End == move.MoveIndex && chessBoard.IsCapturePathClear(x));

        public virtual IEnumerable<IPath> Moves() => null;
        public virtual IEnumerable<IPath> Captures() => null;

        public void Update(IUserMove move)
        {
            var rankAndFile = new RankAndFile(move.MoveIndex);
            CurrentPosition = move.MoveIndex;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }

        public void Promote(IBoardState chessBoard) => chessBoard.Promote(this);

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

        public virtual void PerformMove(IUserMove move, IBoardState chessBoard)
        {
            var validPath = Moves().Where(x => x.End == move.MoveIndex && chessBoard.IsMovePathClear(x));
        }

        public virtual void PerformCapture(IUserMove move, IBoardState chessBoard)
        {
            var validPath = Captures().Where(x => x.End == move.MoveIndex && chessBoard.IsCapturePathClear(x));
        }

        public void FlagAsMoved(bool isMoved) => IsMoved = isMoved;
    }
}