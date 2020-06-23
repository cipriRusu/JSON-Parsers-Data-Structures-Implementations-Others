using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChessMoves
{
    public class ChessBoardTest
    {
        [Fact]
        public void ComputeTableReturnsValidBoardForSingleValidMoves()
        {
            var testBoard = new ChessBoard();

            var moves = new List<UserMove>();
            moves.Add(new UserMove("e4") { PlayerColor = Player.White });
            moves.Add(new UserMove("e5") { PlayerColor = Player.Black });

            testBoard.PerformMoves(moves);

            Assert.Null(testBoard.board[6, 4]);
            Assert.Null(testBoard.board[1, 4]);

            Assert.Equal(testBoard.board[4, 4],
                new Pawn("e4", Player.White)
                {
                    CurrentPosition = (4, 4),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());

            Assert.Equal(testBoard.board[3, 4],
                new Pawn("e5", Player.Black)
                {
                    CurrentPosition = (3, 4),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());
        }

        [Fact]
        public void ComputeTableReturnsValidBoardForMultipleValidUnambiguousMoves()
        {
            var testBoard = new ChessBoard();

            var moves = new List<UserMove>();
            moves.Add(new UserMove("e4") { PlayerColor = Player.White });
            moves.Add(new UserMove("e5") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Nf3") { PlayerColor = Player.White });
            moves.Add(new UserMove("Nc6") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Bb5") { PlayerColor = Player.White });
            moves.Add(new UserMove("a6") { PlayerColor = Player.Black });

            testBoard.PerformMoves(moves);

            Assert.Equal(testBoard.board[4, 4],
                new Pawn("e4", Player.White)
                {
                    CurrentPosition = (4, 4),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());

            Assert.Equal(testBoard.board[3, 4],
                new Pawn("e5", Player.Black)
                {
                    CurrentPosition = (3, 4),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());

            Assert.Equal(testBoard.board[5, 5],
                new Knight("f3", Player.White)
                {
                    CurrentPosition = (5, 5),
                    PieceType = PieceType.Knight,
                }, new PieceComparer());

            Assert.Equal(testBoard.board[2, 2],
                new Knight("c6", Player.Black)
                {
                    CurrentPosition = (2, 2),
                    PieceType = PieceType.Knight,
                }, new PieceComparer());

            Assert.Equal(testBoard.board[3, 1],
                new Bishop("b5", Player.White)
                {
                    CurrentPosition = (3, 1),
                    PieceType = PieceType.Bishop,
                }, new PieceComparer());

            Assert.Equal(testBoard.board[2, 0],
                new Bishop("a6", Player.Black)
                {
                    CurrentPosition = (2, 0),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());
        }
    }
}