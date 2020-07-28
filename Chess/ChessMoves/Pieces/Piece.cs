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
        public virtual Path Moves() => null;
        public virtual Path Captures() => null;

        public void Update((int, int) newPosition)
        {
            var rankAndFile = new RankAndFile(newPosition);
            CurrentPosition = newPosition;
            File = rankAndFile.File;
            Rank = rankAndFile.Rank;
        }

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

        public virtual bool CanReach((int, int) destination) => Moves().Any(x => x.Last() == destination);
        public virtual bool CanCapture((int, int) target) => Captures().Any(x => x.Last() == target);

        public virtual void PerformMove((int, int) targetMove, ChessBoard chessBoard) 
        {
            var validPath = Moves().Where(x => x.Last() == targetMove).SelectMany(x => x);

            if(chessBoard.IsPathClear(validPath.Skip(1)))
            {
                chessBoard.PerformMove(this, targetMove);
            }
        }

        public virtual void PerformCapture((int, int) targetCapture, ChessBoard chessBoard)
        {
            var validPath = Captures().Where(x => x.Last() == targetCapture).SelectMany(x => x);

            var validTarget = chessBoard[validPath.Last()];

            if (chessBoard.IsPathClear(validPath.Skip(1).SkipLast(1)) && validTarget.PlayerColour == Opponent(PlayerColour))
            {
                chessBoard.PerformMove(this, targetCapture);
            }
        }
    }
}