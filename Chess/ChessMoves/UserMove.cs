using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class UserMove
    {
        public PieceType PieceType;
        public Player PlayerColor;
        public (int, int) MoveIndex;
        private readonly CustomIndex customIndex = new CustomIndex();

        public UserMove(string input)
        {
            switch (input.Length)
            {
                case 2:
                    PieceType = PieceType.Pawn;
                    MoveIndex = customIndex.GetMatrixIndex(input);
                    break;
                case 3:
                    GetPieceType(input);
                    MoveIndex = customIndex.GetMatrixIndex(input.Substring(1));
                    break;
                case 4:
                    MoveIndex = customIndex.GetMatrixIndex(input.Substring(2));
                    GetPieceType(input);
                        break;
                default:
                    throw new ArgumentException("User move format not correct");
            }
        }

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
                    break;
            }
        }
    }
}
