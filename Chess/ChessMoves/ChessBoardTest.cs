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

            var moves = new List<UserMove>();
            moves.Add(new UserMove("e4") { PlayerColor = Player.White });
            moves.Add(new UserMove("e5") { PlayerColor = Player.Black });

            testBoard.GetMoves(moves);

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

            var moves = new List<UserMove>();
            moves.Add(new UserMove("e4") { PlayerColor = Player.White });
            moves.Add(new UserMove("e5") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Nf3") { PlayerColor = Player.White });
            moves.Add(new UserMove("Nc6") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Bb5") { PlayerColor = Player.White });
            moves.Add(new UserMove("a6") { PlayerColor = Player.Black });

            testBoard.GetMoves(moves);

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

            testBoard.GetMoves(moves);

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

            var moves = new List<UserMove>();
            moves.Add(new UserMove("Nc3") { PlayerColor = Player.White });
            moves.Add(new UserMove("f5") { PlayerColor = Player.Black });
            moves.Add(new UserMove("e4") { PlayerColor = Player.White });
            moves.Add(new UserMove("fxe4") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Nxe4") { PlayerColor = Player.White });

            testBoard.GetMoves(moves);

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

            var moves = new List<UserMove>();
            moves.Add(new UserMove("Nc3") { PlayerColor = Player.White });
            moves.Add(new UserMove("f5") { PlayerColor = Player.Black });
            moves.Add(new UserMove("e4") { PlayerColor = Player.White });
            moves.Add(new UserMove("fxe4") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Nxe4") { PlayerColor = Player.White });
            moves.Add(new UserMove("Nf6") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Nxf6+") { PlayerColor = Player.White });
            moves.Add(new UserMove("gxf6") { PlayerColor = Player.Black });

            testBoard.GetMoves(moves);

            Assert.Equal(new Pawn("f6", Player.Black)
            {
                CurrentPosition = (2, 5),
                PieceType = PieceType.Pawn
            },

            testBoard[2, 5], new PieceComparer());
        }

        [Fact]
        public void ChessBoardFailsForCheckedKingAndInvalidMove()
        {
            var moves = new List<UserMove>();
            moves.Add(new UserMove("Nc3") { PlayerColor = Player.White });
            moves.Add(new UserMove("f5") { PlayerColor = Player.Black });
            moves.Add(new UserMove("e4") { PlayerColor = Player.White });
            moves.Add(new UserMove("fxe4") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Nxe4") { PlayerColor = Player.White });
            moves.Add(new UserMove("Nf6") { PlayerColor = Player.Black });
            moves.Add(new UserMove("Nxf6+") { PlayerColor = Player.White });
            moves.Add(new UserMove("c6") { PlayerColor = Player.Black });

            Assert.Throws<ArgumentException>(()=> new ChessBoard().GetMoves(moves));
        }

        [Fact]
        public void ChessBoardFailsForFirstMoveFromBlackPlayer()
        {
            var moves = new List<UserMove>
            {
                new UserMove("Nc3") { PlayerColor = Player.Black },
                new UserMove("f5") { PlayerColor = Player.White }
            };

            Assert.Throws<ArgumentException>(() => new ChessBoard().GetMoves(moves));
        }

        [Fact]
        public void ChessBoardFailsForConsecutiveMovesForSamePlayer()
        {
            var moves = new List<UserMove>
            {
                new UserMove("Nc3") { PlayerColor = Player.White },
                new UserMove("f5") { PlayerColor = Player.White }
            };

            Assert.Throws<ArgumentException>(() => new ChessBoard().GetMoves(moves));
        }

        [Fact]
        public void TurnToMovePropertyReturnsValidOutputForWhiteTurn()
        {
            var moves = new List<UserMove>
            {
                new UserMove("Nc3") { PlayerColor = Player.White },
                new UserMove("f5") { PlayerColor = Player.Black }
            };

            var board = new ChessBoard();
            board.GetMoves(moves);

            Assert.Equal(Player.White, board.TurnToMove);
        }

        [Fact]
        public void TurnToMovePropertyReturnsValidOutputForBlackTurn()
        {
            var moves = new List<UserMove>
            {
                new UserMove("Nc3") { PlayerColor = Player.White },
                new UserMove("f5") { PlayerColor = Player.Black },
                new UserMove("e4") { PlayerColor = Player.White }
        };

            var board = new ChessBoard();
            board.GetMoves(moves);

            Assert.Equal(Player.Black, board.TurnToMove);
        }
    }
}