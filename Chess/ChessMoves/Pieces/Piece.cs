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
    }
}