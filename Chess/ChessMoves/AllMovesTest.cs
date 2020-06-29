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

        [Fact]
        public void GetAllMovesReturnsEnPassantMove()
        {
            var allmoves = new AllMoves(new string[] { "exd6e.p." });

            var output = new List<UserMove>()
            {
                new UserMove("exd6e.p.")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (2, 3)
                }
            };

            Assert.Equal(output, allmoves.Moves, new UserMoveComparer());
        }

        [Fact]
        public void GetAllMovesForFullGame()
        {
            var allmoves =
                new AllMoves(new string[] {
                    "e4 e5",
                    "Nf3 f6",
                    "Nxe5 fxe5",
                    "Qh5+ Ke7",
                    "Qxe5+ Kf7",
                    "Bc4+ d5",
                    "Bxd5+ Kg6",
                    "h4 h5",
                    "Bxb7 Bxb7",
                    "Qf5+ Kh6",
                    "d4+ g5",
                    "Qf7 Qe7",
                    "hxg5+ Qxg5",
                    "Rxh5#"
                });

            var output = new List<UserMove>()
            {
                new UserMove("e4")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (4, 4)
                },
                new UserMove("e5")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (3, 4)
                },
                new UserMove("Nf3")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Knight,
                    MoveIndex = (5, 5)
                },
                new UserMove("f6")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (2, 5)
                },
                new UserMove("Nxe5")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Knight,
                    MoveIndex = (3, 4)
                },
                new UserMove("fxe5")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (3, 4)
                },
                new UserMove("Qh5+")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Queen,
                    MoveIndex = (3, 7)
                },
                new UserMove("Ke7")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.King,
                    MoveIndex = (1, 4)
                },
                new UserMove("Qxe5+")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Queen,
                    MoveIndex = (3, 4)
                },
                new UserMove("Kf7")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.King,
                    MoveIndex = (1, 5)
                },
                new UserMove("Bc4+")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Bishop,
                    MoveIndex = (4, 2)
                },
                new UserMove("d5")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (3, 3)
                },
                new UserMove("Bxd5+")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Bishop,
                    MoveIndex = (3, 3)
                },
                new UserMove("Kg6")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.King,
                    MoveIndex = (2, 6)
                },
                new UserMove("h4")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (4, 7)
                },
                new UserMove("h5")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (3, 7)
                },
                new UserMove("Bxb7")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Bishop,
                    MoveIndex = (1, 1)
                },
                new UserMove("Bxb7")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Bishop,
                    MoveIndex = (1, 1)
                },
                new UserMove("Qf5+")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Queen,
                    MoveIndex = (3, 5)
                },
                new UserMove("Kh6")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.King,
                    MoveIndex = (2, 7)
                },
                new UserMove("d4+")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (4, 3)
                },
                new UserMove("g5")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (3, 6)
                },
                new UserMove("Qf7")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Queen,
                    MoveIndex = (1, 5)
                },
                new UserMove("Qe7")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Queen,
                    MoveIndex = (1, 4)
                },
                new UserMove("hxg5+")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Pawn,
                    MoveIndex = (3, 6)
                },
                new UserMove("Qxg5")
                {
                    PlayerColor = Player.Black,
                    PieceType = PieceType.Queen,
                    MoveIndex = (3, 6)
                },
                new UserMove("Rxh5#")
                {
                    PlayerColor = Player.White,
                    PieceType = PieceType.Rock,
                    MoveIndex = (3, 7)
                }
            };

            Assert.Equal(output, allmoves.Moves, new UserMoveComparer());
        }
    }
}
