using System;
using System.Diagnostics.CodeAnalysis;
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
            Assert.Equal(UserMoveType.Move, movePiece.UserMoveType);
        }

        [Fact]
        public void UserMoveInputForKnightReturnKnightMove()
        {
            var movePiece = new UserMove("Nc6");
            movePiece.PlayerColor = Player.Black;

            Assert.Equal((2, 2), movePiece.MoveIndex);
            Assert.Equal(PieceType.Knight, movePiece.PieceType);
            Assert.Equal(Player.Black, movePiece.PlayerColor);
            Assert.Equal(UserMoveType.Move, movePiece.UserMoveType);
        }

        [Fact]
        public void UserMoveInputForBishopReturnsBishopMove()
        {
            var movePiece = new UserMove("Bb5");
            movePiece.PlayerColor = Player.White;

            Assert.Equal(UserMoveType.Move, movePiece.UserMoveType);
            Assert.Equal((3, 1), movePiece.MoveIndex);
            Assert.Equal(PieceType.Bishop, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal(UserMoveType.Move, movePiece.UserMoveType);
        }

        [Fact]
        public void UserMoveInputForBishopCaptureReturnsCapture()
        {
            var movePiece = new UserMove("Bxe5");
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((3, 4), movePiece.MoveIndex);
            Assert.Equal(PieceType.Bishop, movePiece.PieceType);
            Assert.Equal(UserMoveType.Capture, movePiece.UserMoveType);
        }

        [Fact]
        public void UserMoveInputForAmbiguousMoveContainsSourceFileValue()
        {
            var movePiece = new UserMove("Rdf8");
            Assert.Equal(PieceType.Rock, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((0, 5), movePiece.MoveIndex);
            Assert.Equal('d', movePiece.SourceFile);
            Assert.Equal(UserMoveType.Move, movePiece.UserMoveType);
        }

        [Fact]
        public void UserMoveInputForAmbigousMoveContainsSourceRankValue()
        {
            var movePiece = new UserMove("R1a3");
            Assert.Equal(PieceType.Rock, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((5, 0), movePiece.MoveIndex);
            Assert.Equal('1', movePiece.SourceRank);
            Assert.Equal(UserMoveType.Move, movePiece.UserMoveType);
        }

        [Fact]
        public void UserMoveInputForPawnPromotion()
        {
            var movePiece = new UserMove("e8=Q");
            Assert.Equal(PieceType.Pawn, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((0, 4), movePiece.MoveIndex);
            Assert.True(movePiece.IsPromotion);
        }

        [Fact]
        public void UserMoveInputForPieceWithAmbiguousDoubleMove()
        {
            var movePiece = new UserMove("Qh4e1");
            Assert.Equal(PieceType.Queen, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((7, 4), movePiece.MoveIndex);
            Assert.Equal(UserMoveType.Move, movePiece.UserMoveType);
        }

        [Fact]
        public void UserMoveInputForPieceWithAmbiguousDoubleCapture()
        {
            var movePiece = new UserMove("Qh4xe1");
            Assert.Equal('4', movePiece.SourceRank);
            Assert.Equal('h', movePiece.SourceFile);
            Assert.Equal(PieceType.Queen, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((7, 4), movePiece.MoveIndex);
            Assert.Equal(UserMoveType.Capture, movePiece.UserMoveType);
        }

        [Fact]
        public void UserMoveInputForSimpleCheckMove()
        {
            var movePiece = new UserMove("Nf6+");
            Assert.Equal(PieceType.Knight, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((2, 5), movePiece.MoveIndex);
            Assert.True(movePiece.IsCheck);
        }

        [Fact]
        public void UserMoveInputForComplexMoveWithFile()
        {
            var movePiece = new UserMove("Rdf8+");
            Assert.Equal(PieceType.Rock, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((0, 5), movePiece.MoveIndex);
            Assert.Equal('d', movePiece.SourceFile);
            Assert.True(movePiece.IsCheck);
        }

        [Fact]
        public void UserMoveInputForComplexMoveWithRankCheck()
        {
            var movePiece = new UserMove("R1a3+");
            Assert.Equal(PieceType.Rock, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((5, 0), movePiece.MoveIndex);
            Assert.Equal('1', movePiece.SourceRank);
            Assert.True(movePiece.IsCheck);
        }

        [Fact]
        public void UserMoveInputForCheckAndCapture()
        {
            var movePiece = new UserMove("Nxf6+");
            Assert.Equal(PieceType.Knight, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((2, 5), movePiece.MoveIndex);
            Assert.Equal(UserMoveType.Capture, movePiece.UserMoveType);
            Assert.True(movePiece.IsCheck);
        }

        [Fact]
        public void UserMoveInputForCheckMateSimpleMove()
        {
            var movePiece = new UserMove("Qh5#");
            Assert.Equal(PieceType.Queen, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((3, 7), movePiece.MoveIndex);
            Assert.True(movePiece.IsCheckMate);
        }

        [Fact]
        public void UserMoveInputForCheckMateComplexMoveWithFile()
        {
            var movePiece = new UserMove("R1a3#");
            Assert.Equal(PieceType.Rock, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((5, 0), movePiece.MoveIndex);
            Assert.Equal('1', movePiece.SourceRank);
            Assert.True(movePiece.IsCheckMate);
        }

        [Fact]
        public void UserMoveInputForCheckMateComplexMoveWithRank()
        {
            var movePiece = new UserMove("Rdf8#");
            Assert.Equal(PieceType.Rock, movePiece.PieceType);
            Assert.Equal(Player.White, movePiece.PlayerColor);
            Assert.Equal((0, 5), movePiece.MoveIndex);
            Assert.Equal('d', movePiece.SourceFile);
            Assert.True(movePiece.IsCheckMate);
        }
    }
}
