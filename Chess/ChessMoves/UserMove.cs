using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

            if (input.Contains('=') && PieceType == PieceType.Pawn)
            {
                PawnPromotion(input);
            }
            else
            {
                GetSource(string.Concat(input.TakeLast(2)));

                GetOrigin(input.Except(string.Concat(input.TakeLast(2))));
            }
        }

        private void PawnPromotion(string input)
        {
            var source = string.Concat(input.Take(2));
            GetSource(source);
            GetPieceType(string.Concat(input.Last()));
            UserMoveType = UserMoveType.Promote;
        }

        private void GetSource(string source)
        {
            if (source.All(x => IsRank(x) || IsFile(x)))
            {
                MoveIndex = customIndex.GetMatrixIndex(source);
            }
        }
        private void GetOrigin(IEnumerable<char> origin)
        {
            foreach (var element in origin)
            {
                if (element == 'x') { UserMoveType = UserMoveType.Capture; }

                if (IsRank(element)) { SourceRank = element; }

                if (IsFile(element)) { SourceFile = element; }
            }
        }
        private bool IsRank(char c) => "12345678".Contains(c);
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
