using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class ConvertUserMovesTest
    {
        [Fact]
        public void ComputePawnOnlyMovesFromUserInput()
        {
            var input = new string[] { "e4 e5" };

            var actual = new ConvertUserMoves().ConvertMoves(input);

            var expected = new List<UserMove>()
            {
                new UserMove("e4") {PieceType = PieceType.Pawn, PlayerColor = Player.White},
                new UserMove("e5") {PieceType = PieceType.Pawn, PlayerColor = Player.Black}
            };

            Assert.Equal(expected, actual, new UserMoveComparer());
        }

        [Fact]
        public void ComputePawnAndKnightMovesFromUserInput()
        {
            var input = new string[] { "e4 e5", "Nf3 Nc6" };

            var actual = new ConvertUserMoves().ConvertMoves(input);

            var expected = new List<UserMove>()
            {
                new UserMove("e4") {PieceType = PieceType.Pawn, PlayerColor = Player.White },
                new UserMove("e5") {PieceType = PieceType.Pawn, PlayerColor = Player.Black},
                new UserMove("Nf3"){PieceType = PieceType.Knight, PlayerColor = Player.White },
                new UserMove("Nc6"){PieceType = PieceType.Knight, PlayerColor = Player.Black }
            };

            Assert.Equal(expected, actual, new UserMoveComparer());
        }
    }
}
