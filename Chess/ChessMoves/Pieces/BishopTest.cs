using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class BishopTest
    {
        [Fact]
        public void WhiteBishopReturnsAllPossibleMoves()
        {
            var bishop = new Bishop((7, 2), Player.White);
            var expected = new List<List<(int, int)>>
            {
                new List<(int, int)>() {(7, 2), (6, 1) },
                new List<(int, int)>() {(7, 2), (6, 1), (5, 0) },

                new List<(int, int)>() {(7, 2), (6, 3) },
                new List<(int, int)>() {(7, 2), (6, 3), (5, 4) },
                new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5) },
                new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5), (3, 6) },
                new List<(int, int)>() {(7, 2), (6, 3), (5, 4), (4, 5), (3, 6), (2, 7) },
            };

            var actual = bishop.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteBishopReturnsAllPossibleMovesBoardInterior()
        {
            var bishop = new Bishop((4, 5), Player.White);
            var expected = new List<List<(int, int)>>()
            {
                new List<(int, int)>() {(4, 5), (3, 4) },
                new List<(int, int)>() {(4, 5), (3, 4), (2, 3) },
                new List<(int, int)>() {(4, 5), (3, 4), (2, 3), (1, 2)},
                new List<(int, int)>() {(4, 5), (3, 4), (2, 3), (1, 2), (0, 1)},

                new List<(int, int)>() {(4, 5), (3, 6) },
                new List<(int, int)>() {(4, 5), (3, 6), (2, 7)},

                new List<(int, int)>() {(4, 5), (5, 4) },
                new List<(int, int)>() {(4, 5), (5, 4), (6, 3) },
                new List<(int, int)>() {(4, 5), (5, 4), (6, 3), (7, 2) },


                new List<(int, int)>() {(4, 5), (5, 6) },
                new List<(int, int)>() {(4, 5), (5, 6), (6, 7) },
            };

            var actual = bishop.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackBishopReturnsAllPossibleMovesBoardInterior()
        {
            var bishop = new Bishop((2, 3), Player.Black);
            var expected = new List<List<(int, int)>>()
            {
                new List<(int, int)>(){(2, 3),(1, 2)},
                new List<(int, int)>(){(2, 3),(1, 2), (0, 1)},

                new List<(int, int)>() {(2, 3), (1, 4)},
                new List<(int, int)>() {(2, 3), (1, 4), (0, 5)},

                new List<(int, int)>() {(2, 3), (3, 2) },
                new List<(int, int)>() {(2, 3), (3, 2), (4, 1) },
                new List<(int, int)>() {(2, 3), (3, 2), (4, 1), (5, 0)},

                new List<(int, int)>() {(2, 3), (3, 4)},
                new List<(int, int)>() {(2, 3), (3, 4), (4, 5)},
                new List<(int, int)>() {(2, 3), (3, 4), (4, 5), (5, 6)},
                new List<(int, int)>() {(2, 3), (3, 4), (4, 5), (5, 6), (6, 7)},
            };

            var actual = bishop.GetLegalMoves();

            Assert.Equal(expected, actual);
        }
    }
}
