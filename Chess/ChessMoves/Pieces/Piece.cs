using System;
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
        public bool PassantCapturable { get; private set; }
        public bool IsPassantCapturable { get; private set; }
        public void MarkPassant(IChessPiece piece, (int, int) destination)
        {
            if (piece.PieceType == PieceType.Pawn)
            {
                switch (piece.PlayerColour)
                {
                    case Player.White:
                        IsPassantCapturable = destination.Item2 - piece.CurrentPosition.Item2 == 2;
                        break;
                    case Player.Black:
                        IsPassantCapturable = piece.CurrentPosition.Item2 - destination.Item2 == 2;
                        break;
                }
            }
        }

        public virtual bool CanReach(IUserMove move, IBoardState chessBoard) => 
            Moves().Any(x => x.Last() == move.MoveIndex && chessBoard.IsPathClear(x.Skip(1)));

        public virtual bool CanCapture(IUserMove move, IBoardState chessBoard) => 
            Captures().Any(x => x.Last() == move.MoveIndex && chessBoard.IsPathClear(x.Skip(1).SkipLast(1)));

        public virtual IPath Moves() => null;
        public virtual IPath Captures() => null;

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
            var validPath = Moves().Where(x => x.Last() == move.MoveIndex).SelectMany(x => x);

            if(chessBoard.IsPathClear(validPath.Skip(1)))
            {
                chessBoard.PerformMove(this, move);
            }
        }

        public virtual void PerformCapture(IUserMove move, IBoardState chessBoard)
        {
            var validPath = Captures().Where(x => x.Last() == move.MoveIndex).SelectMany(x => x);

            var validTarget = chessBoard[validPath.Last()];

            if (chessBoard.IsPathClear(validPath.Skip(1).SkipLast(1)) && validTarget.PlayerColour == Opponent(PlayerColour))
            {
                chessBoard.PerformMove(this, move);
            }
        }
    }
}