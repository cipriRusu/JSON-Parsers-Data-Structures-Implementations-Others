using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class KingTest
    {
        [Fact]
        public void BlackKingReturnsAllLegalMovesStartPosition()
        {
            var king = new King((0, 4), Player.Black);
            var expected = new List<List<(int, int)>>()
            {
                new List<(int, int)>{(0, 5)},
                new List<(int, int)>{(0, 3)},
                new List<(int, int)>{(1, 3)},
                new List<(int, int)>{(1, 4)},
                new List<(int, int)>{(1, 5)},
            };

            var actual = king.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteKingReturnsAllLegalMovesStartPosition()
        {
            var king = new King((7, 4), Player.White);
            var expected = new List<List<(int, int)>>()
            {
                new List<(int, int)>{(7, 5)},
                new List<(int, int)>{(6, 5)},
                new List<(int, int)>{(6, 4)},
                new List<(int, int)>{(6, 3)},
                new List<(int, int)>{(7, 3)},
            };

            var actual = king.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackKingReturnsAllLegalMovesDownwardTable()
        {
            var king = new King((2, 3), Player.Black);
            var expected = new List<List<(int, int)>>()
            {
                new List<(int, int)>{(2, 4)},
                new List<(int, int)>{(1, 4)},
                new List<(int, int)>{(1, 3)},
                new List<(int, int)>{(1, 2)},
                new List<(int, int)>{(2, 2)},
                new List<(int, int)>{(3, 2)},
                new List<(int, int)>{(3, 3)},
                new List<(int, int)>{(3, 4)},
            };

            var actual = king.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteKingReturnsAllLegalMovesUpwardTable()
        {
            var king = new King((5, 6), Player.White);
            var expected = new List<List<(int, int)>>()
            {
                new List<(int, int)>{(5, 7)},
                new List<(int, int)>{(4, 7)},
                new List<(int, int)>{(4, 6)},
                new List<(int, int)>{(4, 5)},
                new List<(int, int)>{(5, 5)},
                new List<(int, int)>{(6, 5)},
                new List<(int, int)>{(6, 6)},
                new List<(int, int)>{(6, 7)},
            };

            var actual = king.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KingReturnsCheckFromKnightPiece()
        {
            var testBoard = new Piece[8, 8];

            testBoard[0, 3] = new King((0, 3), Player.White);
            testBoard[2, 2] = new Knight((2, 2), Player.Black);

            Assert.True(testBoard[0, 3].IsChecked(testBoard));
        }
        
        [Fact]
        public void KingDoesNotReturnCheckFromOtherFoePieceInKnightPlace()
        {
            var testBoard = new Piece[8, 8];

            testBoard[0, 3] = new King((0, 3), Player.White);
            testBoard[2, 2] = new Bishop((2, 2), Player.Black);

            Assert.False(testBoard[0, 3].IsChecked(testBoard));
        }

        [Fact]
        public void KingDoesNotReturnCheckFromFriendlyKnight()
        {
            var testBoard = new Piece[8, 8];

            testBoard[0, 3] = new King((0, 3), Player.White);
            testBoard[2, 2] = new Knight((2, 2), Player.White);

            Assert.False(testBoard[0, 3].IsChecked(testBoard));
        }

        [Fact]
        public void KingReturnsCheckFromLinearPiece()
        {
            var testBoard = new Piece[8, 8];

            testBoard[0, 0] = new King((0, 0), Player.White);
            testBoard[0, 5] = new Rock((0, 5), Player.Black);

            Assert.True(testBoard[0, 0].IsChecked(testBoard));
        }

        [Fact]
        public void KingDoesNotReturnCheckForBlockedFoePiece()
        {
            var testBoard = new Piece[8, 8];

            testBoard[0, 0] = new King((0, 0), Player.White);
            testBoard[0, 5] = new Bishop((0, 5), Player.White);
            testBoard[0, 7] = new Rock((0, 7), Player.Black);

            Assert.False(testBoard[0, 0].IsChecked(testBoard));
        }

        [Fact]
        public void KingReturnsCheckFromLinearPieceColumnAttack()
        {
            var testBoard = new Piece[8, 8];

            testBoard[0, 0] = new King((0, 0), Player.White);
            testBoard[7, 0] = new Rock((0, 7), Player.Black);

            Assert.True(testBoard[0, 0].IsChecked(testBoard));
        }

        [Fact]
        public void KingDoesNotReturnCheckForBlockedFoePieceColumnAttack()
        {
            var testBoard = new Piece[8, 8];

            testBoard[0, 0] = new King((0, 0), Player.White);
            testBoard[4, 0] = new Bishop((4, 0), Player.Black);
            testBoard[7, 0] = new Rock((7, 0), Player.Black);

            Assert.False(testBoard[0, 0].IsChecked(testBoard));
        }
    }
}
