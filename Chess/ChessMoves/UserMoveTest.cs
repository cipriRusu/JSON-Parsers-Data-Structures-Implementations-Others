using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class UserMoveTest
    {
        [Fact]
        public void UserMoveInputForPawnReturnsPawnMove()
        {
            var movePiece = new UserMove("e4");
            movePiece.PlayerColor = Player.White;

            Assert.Equal((4, 4), movePiece.MoveIndex);
            Assert.Equal(PieceType.Pawn, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
        }

        [Fact]
        public void UserMoveInputForKnightReturnKnightMove()
        {
            var movePiece = new UserMove("Nc6");
            movePiece.PlayerColor = Player.Black;

            Assert.Equal((2, 2), movePiece.MoveIndex);
            Assert.Equal(PieceType.Knight, movePiece.PieceType);
            Assert.Equal(Player.Black, movePiece.PlayerColor);
        }

        [Fact]
        public void UserMoveInputForBishopReturnsBishopMove()
        {
            var movePiece = new UserMove("Bb5");
            movePiece.PlayerColor = Player.White;

            Assert.Equal((3, 1), movePiece.MoveIndex);
            Assert.Equal(PieceType.Bishop, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
        }

        [Fact]
        public void UserMoveInputForBishopCaptureReturnsMove()
        {
            var movePiece = new UserMove("Bxe5");
        }
    }
}
