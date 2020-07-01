using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Xunit;

namespace ChessMoves
{
    public class ChessBoardTest
    {
        [Fact]
        public void ChessBoardReturnsValidBoardForSingleValidMoves()
        {
            var testBoard = new ChessBoard();

            testBoard.Moves(new string[] { "e4 e5" });

            Assert.Null(testBoard[6, 4]);
            Assert.Null(testBoard[1, 4]);

            Assert.Equal(testBoard[4, 4],
                new Pawn("e4", Player.White)
                {
                    CurrentPosition = (4, 4),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());

            Assert.Equal(testBoard[3, 4],
                new Pawn("e5", Player.Black)
                {
                    CurrentPosition = (3, 4),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());
        }

        [Fact]
        public void ChessBoardReturnsValidBoardForMultipleValidUnambiguousMoves()
        {
            var testBoard = new ChessBoard();

            testBoard.Moves(new string[] { "e4 e5", "Nf3 Nc6", "Bb5 a6" });

            Assert.Equal(testBoard[4, 4],
                new Pawn("e4", Player.White)
                {
                    CurrentPosition = (4, 4),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());

            Assert.Equal(testBoard[3, 4],
                new Pawn("e5", Player.Black)
                {
                    CurrentPosition = (3, 4),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());

            Assert.Equal(testBoard[5, 5],
                new Knight("f3", Player.White)
                {
                    CurrentPosition = (5, 5),
                    PieceType = PieceType.Knight,
                }, new PieceComparer());

            Assert.Equal(testBoard[2, 2],
                new Knight("c6", Player.Black)
                {
                    CurrentPosition = (2, 2),
                    PieceType = PieceType.Knight,
                }, new PieceComparer());

            Assert.Equal(testBoard[3, 1],
                new Bishop("b5", Player.White)
                {
                    CurrentPosition = (3, 1),
                    PieceType = PieceType.Bishop,
                }, new PieceComparer());

            Assert.Equal(testBoard[2, 0],
                new Bishop("a6", Player.Black)
                {
                    CurrentPosition = (2, 0),
                    PieceType = PieceType.Pawn,
                }, new PieceComparer());
        }

        [Fact]
        public void ChessBoardReturnsValidBoardForMultipleValidAmbigousMovesAndSinglePawnCapture()
        {
            var testBoard = new ChessBoard();

            var moves = new List<UserMove>();
            moves.Add(new UserMove("Nc3") { PlayerColor = Player.White });
            moves.Add(new UserMove("f5") { PlayerColor = Player.Black });
            moves.Add(new UserMove("e4") { PlayerColor = Player.White });
            moves.Add(new UserMove("fxe4") { PlayerColor = Player.Black });

            testBoard.Moves(new string[] { "Nc3 f5", "e4 fxe4" });

            Assert.Equal(testBoard[4, 4],
                new Pawn("e4", Player.Black)
                {
                    CurrentPosition = (4, 4),
                    PieceType = PieceType.Pawn
                }, new PieceComparer());

            Assert.Equal(testBoard[5, 2],
                new Knight("c3", Player.White)
                {
                    CurrentPosition = (5, 2),
                    PieceType = PieceType.Knight
                }, new PieceComparer());
        }

        [Fact]
        public void ChessBoardReturnsValidBoardForMultipleValidAmbigousMovesAndMultipleCaptures()
        {
            var testBoard = new ChessBoard();

            testBoard.Moves(new string[] { "Nc3 f5", "e4 fxe4", "Nxe4" });

            Assert.Equal(
                new Knight("e4", Player.White)
                {
                    CurrentPosition = (4, 4),
                    PieceType = PieceType.Knight
                },
                testBoard[4, 4], new PieceComparer());
        }

        [Fact]
        public void ChessBoardReturnsValidBoardForMultipleValidMovesAndCheckedKing()
        {
            var testBoard = new ChessBoard();

            testBoard.Moves(new string[] { "Nc3 f5", "e4 fxe4", "Nxe4 Nf6", "Nxf6+ gxf6" });

            Assert.Equal(new Pawn("f6", Player.Black)
            {
                CurrentPosition = (2, 5),
                PieceType = PieceType.Pawn
            },

            testBoard[2, 5], new PieceComparer());

            Assert.True(testBoard.IsCheck);
        }

        [Fact]
        public void ChessBoardReturnsValidValueForFullGame()
        {
            var testBoard = new ChessBoard();

            testBoard.Moves(new string[] { "Nc3 f5", "e4 fxe4", "Nxe4 Nf6", "Nxf6+ gxf6", "Qh5#" });

            Assert.Equal(new Queen("h5", Player.White)
            {
                CurrentPosition = (3, 7),
                PieceType = PieceType.Queen
            },

            testBoard[3, 7], new PieceComparer());

            Assert.True(testBoard.IsCheckMate);
        }

        [Fact]
        public void ChessBoardFailsForCheckedKingAndInvalidMove()
        {
            Assert.Throws<ArgumentException>(() =>
            new ChessBoard().Moves(new string[] { "Nc3 f5", "e4 fxe4", "Nxe4 Nf6", "Nxf6+ c6" }));
        }

        [Fact]
        public void TurnToMovePropertyReturnsValidOutputForWhiteTurn()
        {
            var board = new ChessBoard();
            board.Moves(new string[] { "Nc3 f5" });

            Assert.Equal(Player.White, board.TurnToMove);
        }

        [Fact]
        public void TurnToMovePropertyReturnsValidOutputForBlackTurn()
        {
            var board = new ChessBoard();
            board.Moves(new string[] { "Nc3 f5", "e4" });

            Assert.Equal(Player.Black, board.TurnToMove);
        }

        [Fact]
        public void PerformMoveSwitchesPiecePosition()
        {
            var board = new ChessBoard();
            board.PerformMove((1, 0), (2, 0));

            Assert.Equal(new Pawn((2, 0), Player.Black), board[2, 0], new PieceComparer());
        }

        [Fact]
        public void IsCheckedReturnsFalseForUncheckedKingAtGameStart()
        {
            var board = new ChessBoard();

            Assert.False(board.IsChecked(Player.White));
        }
    }
}