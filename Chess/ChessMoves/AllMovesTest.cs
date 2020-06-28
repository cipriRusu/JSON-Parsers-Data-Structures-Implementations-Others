using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class AllMovesTest
    {
        [Fact]
        public void GetAllMovesForSingleMoveSet()
        {
            var allmoves = new AllMoves(new string[] { "e4 e5" });
            var output = new List<UserMove>();

            var firstMove = new UserMove("e4");
            firstMove.PlayerColor = Player.White;
            firstMove.PieceType = PieceType.Pawn;
            firstMove.MoveIndex = (4, 4);

            var secondMove = new UserMove("e5");
            secondMove.PlayerColor = Player.Black;
            secondMove.PieceType = PieceType.Pawn;
            secondMove.MoveIndex = (3, 4);

            output.Add(firstMove);
            output.Add(secondMove);

            Assert.Equal(output, allmoves.Moves, new UserMoveComparer());
        }

        [Fact]
        public void GetAllMovesForMultipeMovesSet()
        {
            var allmoves = new AllMoves(new string[] { "e4 e5" , "Nf3 Nc6"});
            var output = new List<UserMove>();

            var firstMove = new UserMove("e4");
            firstMove.PlayerColor = Player.White;
            firstMove.PieceType = PieceType.Pawn;
            firstMove.MoveIndex = (4, 4);

            var secondMove = new UserMove("e5");
            secondMove.PlayerColor = Player.Black;
            secondMove.PieceType = PieceType.Pawn;
            secondMove.MoveIndex = (3, 4);

            var thirdMove = new UserMove("Nf3");
            thirdMove.PlayerColor = Player.White;
            thirdMove.PieceType = PieceType.Knight;
            thirdMove.MoveIndex = (2, 2);

            var fourthMove = new UserMove("Nc6");
            fourthMove.PlayerColor = Player.Black;
            fourthMove.PieceType = PieceType.Knight;
            thirdMove.MoveIndex = (5, 5);

            output.Add(firstMove);
            output.Add(secondMove);
            output.Add(thirdMove);
            output.Add(fourthMove);

            Assert.Equal(output, allmoves.Moves, new UserMoveComparer());
        }

        [Fact]
        public void GetAllMovesForComplexMoveSet()
        {
            var allmoves = new AllMoves(new string[] { "Nf3 f6" });
            var output = new List<UserMove>();

            var firstMove = new UserMove("Nf3");
            firstMove.PlayerColor = Player.White;
            firstMove.PieceType = PieceType.Knight;
            firstMove.MoveIndex = (5, 5);

            var secondMove = new UserMove("f6");
            secondMove.PlayerColor = Player.Black;
            secondMove.PieceType = PieceType.Pawn;
            secondMove.MoveIndex = (2, 5);

            output.Add(firstMove);
            output.Add(secondMove);

            Assert.Equal(output, allmoves.Moves, new UserMoveComparer());
        }

        [Fact]
        public void GetAllMovesForMultipleComplexMoveSet()
        {
            var allmoves = new AllMoves(new string[] { "Nxe5 fxe5", "Qh5+ Ke7" });
            var output = new List<UserMove>();

            var firstMove = new UserMove("Nxe5");
            firstMove.PlayerColor = Player.White;
            firstMove.PieceType = PieceType.Knight;
            firstMove.MoveIndex = (3, 4);

            var secondMove = new UserMove("fxe5");
            secondMove.PlayerColor = Player.Black;
            secondMove.PieceType = PieceType.Pawn;
            secondMove.MoveIndex = (3, 4);

            var thirdMove = new UserMove("Qh5+");
            thirdMove.PlayerColor = Player.White;
            thirdMove.PieceType = PieceType.Queen;
            thirdMove.MoveIndex = (3, 7);

            var fourthMove = new UserMove("Ke7");
            fourthMove.PlayerColor = Player.Black;
            fourthMove.PieceType = PieceType.King;
            fourthMove.MoveIndex = (1, 4);

            output.Add(firstMove);
            output.Add(secondMove);
            output.Add(thirdMove);
            output.Add(fourthMove);

            Assert.Equal(output, allmoves.Moves, new UserMoveComparer());
        }
    }
}
