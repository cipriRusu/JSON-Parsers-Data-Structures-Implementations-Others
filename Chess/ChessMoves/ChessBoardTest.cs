using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChessMoves
{
    public class ChessBoardTest
    {
        [Fact]
        public void ChessBoardReturnsValidBoardForSingleValidMoves()
        {
            var testBoard = new ChessBoard();

            testBoard.PerformMoves(new string[] { "e4 e5" });

            Assert.Null(testBoard[(6, 4)]);
            Assert.Null(testBoard[(1, 4)]);

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

            testBoard.PerformMoves(new string[] { "e4 e5", "Nf3 Nc6", "Bb5 a6" });

            Assert.Equal(testBoard[(4, 4)],
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
                new Pawn("a6", Player.Black)
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

            testBoard.PerformMoves(new string[] { "Nc3 f5", "e4 fxe4" });

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

            testBoard.PerformMoves(new string[] { "Nc3 f5", "e4 fxe4", "Nxe4" });

            Assert.Equal(
                new Knight("e4", Player.White)
                {
                    CurrentPosition = (4, 4),
                    PieceType = PieceType.Knight
                },
                testBoard[4, 4], new PieceComparer());
        }

        [Fact]
        public void ChessBoardReturnsValidBoardForMultipleValidMovesAndCheckedEscapedKing()
        {
            var testBoard = new ChessBoard();

            testBoard.PerformMoves(new string[]
            { "Nc3 f5",
              "e4 fxe4",
              "Nxe4 Nf6",
              "Nxf6+ gxf6" });

            Assert.Equal(new Pawn("f6", Player.Black)
            {
                CurrentPosition = (2, 5),
                PieceType = PieceType.Pawn
            },

            testBoard[2, 5], new PieceComparer());

            Assert.False(testBoard.IsCheck);
        }

        [Fact]
        public void ChessBoardReturnsValidValueForFullGame()
        {
            var testBoard = new ChessBoard();

            testBoard.PerformMoves(new string[] { "Nc3 f5", "e4 fxe4", "Nxe4 Nf6", "Nxf6+ gxf6", "Qh5#" });

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
            new ChessBoard().PerformMoves(new string[] { "Nc3 f5", "e4 fxe4", "Nxe4 Nf6", "Nxf6+ c6" }));
        }

        [Fact]
        public void TurnToMovePropertyReturnsValidOutputForWhiteTurn()
        {
            var board = new ChessBoard();
            board.PerformMoves(new string[] { "Nc3 f5" });

            Assert.Equal(Player.White, board.TurnToMove);
        }

        [Fact]
        public void TurnToMovePropertyReturnsValidOutputForBlackTurn()
        {
            var board = new ChessBoard();
            board.PerformMoves(new string[] { "Nc3 f5", "e4" });

            Assert.Equal(Player.Black, board.TurnToMove);
        }

        [Fact]
        public void IsPieceReturnsTrueForValidPieceTypeAndColour()
        {
            var board = new ChessBoard();

            Assert.True(board.IsPiece(board[1, 0].CurrentPosition, PieceType.Pawn, Player.Black));
        }

        [Fact]
        public void IsPieceReturnsFalseForOtherPieceInPlace()
        {
            var board = new ChessBoard();

            Assert.False(board.IsPiece(board[1, 0].CurrentPosition, PieceType.Rock, Player.Black));
        }

        [Fact]
        public void IsPieceReturnsFalseForWrongPlayer()
        {
            var board = new ChessBoard();

            Assert.False(board.IsPiece(board[1, 0].CurrentPosition, PieceType.Pawn, Player.White));
        }

        [Fact]
        public void ChessBoardReturnsValidValuesForSmallCastlingBlackPlayer()
        {
            var testBoard = new ChessBoard();
            testBoard.PerformMoves(new string[]
            {"d4 Nf6","c4 g6","Nc3 Bg7","e4 d6","Nf3 0-0" });

            Assert.True(testBoard[0, 6].PieceType == PieceType.King);
            Assert.True(testBoard[0, 5].PieceType == PieceType.Rock);
        }

        [Fact]
        public void ChessBoardReturnsValidValuesForSmallCastlingWhitePlayer()
        {
            var testBoard = new ChessBoard();
            testBoard.PerformMoves(new string[]
            {"e4 e5","Nf3 Nc6","Bb5 a6","Ba4 Nf6","0-0 Be7"});

            Assert.True(testBoard[7, 6].PieceType == PieceType.King);
            Assert.True(testBoard[7, 5].PieceType == PieceType.Rock);
        }

        [Fact]
        public void ChessBoardReturnsValidValuesForBigCastlingWhitePlayer()
        {
            var testBoard = new ChessBoard();

            testBoard.PerformMoves(new string[]
            {"e4 g6", "d4 Bg7", "Nc3 d6", "Be3 c6", "Qd2 b5", "0-0-0 Nd7"});

            Assert.True(testBoard[7, 2].PieceType == PieceType.King);
            Assert.True(testBoard[7, 3].PieceType == PieceType.Rock);
        }

        [Fact]
        public void ChessBoardReturnsValidValuesForBigCastlingBlackPlayer()
        {
            var testBoard = new ChessBoard();

            testBoard.PerformMoves(new string[]
            {"d4 Nf6", "Bg5 c6", "e3 Qa5+", "Qd2 Qxg5", "h4 Qg6", "h5 Nxh5", "Nf3 d6",
             "Nh4 Qe6", "Bd3 g6", "Nc3 b6", "0-0-0 Ba6", "d5 Qd7", "dxc6 Qc8", "c7 Qxc7",
             "Bxa6 Nxa6", "Qd4 0-0-0"});

            Assert.True(testBoard[0, 2].PieceType == PieceType.King);
            Assert.True(testBoard[0, 3].PieceType == PieceType.Rock);
        }

        [Fact]
        public void ChessBoardReturnsValidValueForSecondFullGameWhitePlayerCheckMated()
        {
            var testBoard = new ChessBoard();

            testBoard.PerformMoves(new string[] { "f4 c5", "Nf3 e6", "e3 h6", "Na3 b6", "b3 Be7",
            "Ke2 Kf8", "g3 Bb7", "Bb2 Nf6", "h4 Ng4", "Qb1 Bf6", "Bh3 Bxb2",
            "Qxb2 Bxf3+", "Kxf3 Nxe3", "Kxe3 Kg8", "Rhf1 h5", "Nc4 Qe8", "Ne5 d5",
            "Ke2 Rh6","Kd1 a6", "Re1 Rf6", "Nf3 Rg6", "c4 d4", "Bg2 Qc6", "Rf1 Qc7",
            "Nh2 Ra7", "g4 Nc6", "Rf3 hxg4", "Rd3 Rf6", "Qa3 Nb4", "Rc1 Qxf4", "Ra1 Qxh2", "Rh3 Qg1+","Ke2 Rf2#"});

            Assert.True(testBoard.IsCheckMate);
        }

        [Fact]
        public void ChessBoardReturnsValidValueForThirdFullGameBlackPlayerCheckMated()
        {
            var testBoard = new ChessBoard();

            testBoard.PerformMoves(new string[]
            {
            "d3 e5", "Bd2 Bd6", "g4 Qh4", "e3 Bb4","d4 Bd6","d5 f5",
            "g5 Qg4","Nf3 b6","Na3 Ba6", "Bc3 c5", "Nb5 Be7","h3 Qa4",
            "Nc7+ Kd8", "Bxa6 Qxa6", "d6 Bxd6","Qxd6 b5", "Ne6+ Kc8", "Qc7#"});

            Assert.True(testBoard.IsCheckMate);
        }
    }
}