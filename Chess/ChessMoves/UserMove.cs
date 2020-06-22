using System;
using System.Linq;

namespace ChessMoves
{
    public class UserMove
    {
        public PieceType PieceType;
        public Player PlayerColor;
        public UserMoveType UserMoveType;
        public (int, int) MoveIndex;
        public char SourceFile { get; private set; }
        public char SourceRank { get; private set; }

        private readonly Index customIndex = new Index();

        public UserMove(string input)
        {
            GetPieceType(input);
        }

        private bool IsRank(char c) => "1234567".Contains(c);
        private bool IsFile(char c) => "abcdefgh".Contains(c);
        private void GetPieceType(string input)
        {
            switch (input.First())
            {
                case 'K':
                    PieceType = PieceType.King;
                    break;
                case 'Q':
                    PieceType = PieceType.Queen;
                    break;
                case 'R':
                    PieceType = PieceType.Rock;
                    break;
                case 'B':
                    PieceType = PieceType.Bishop;
                    break;
                case 'N':
                    PieceType = PieceType.Knight;
                    break;
                default:
                    PieceType = PieceType.Pawn;
                    break;
            }
        }
    }
}
