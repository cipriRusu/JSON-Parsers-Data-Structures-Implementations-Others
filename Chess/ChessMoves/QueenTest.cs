using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class QueenTest
    {
        [Fact]
        public void BlackQueenReturnsAllLegalMovesDownwardTable()
        {
            var queen = new Queen((0, 3), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>() {(0, 3), (0, 4) },
                new List<(int, int)>() {(0, 3), (0, 4), (0, 5) },
                new List<(int, int)>() {(0, 3), (0, 4), (0, 5), (0, 6) },
                new List<(int, int)>() {(0, 3), (0, 4), (0, 5), (0, 6), (0, 7) },

                new List<(int, int)>() {(0, 3), (1, 3) },
                new List<(int, int)>() {(0, 3), (1, 3), (2, 3) },
                new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3) },
                new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3), (4, 3) },
                new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3), (4, 3), (5, 3) },
                new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3) },
                new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3) },

                new List<(int, int)>() {(0, 3), (0, 2) },
                new List<(int, int)>() {(0, 3), (0, 2), (0, 1) },
                new List<(int, int)>() {(0, 3), (0, 2), (0, 1), (0, 0)},

                new List<(int, int)>() {(0, 3), (1, 2) },
                new List<(int, int)>() {(0, 3), (1, 2), (2, 1) },
                new List<(int, int)>() {(0, 3), (1, 2), (2, 1), (3, 0)},

                new List<(int, int)>(){(0, 3), (1, 4) },
                new List<(int, int)>(){(0, 3), (1, 4), (2, 5) },
                new List<(int, int)>(){(0, 3), (1, 4), (2, 5), (3, 6) },
                new List<(int, int)>(){(0, 3), (1, 4), (2, 5), (3, 6), (4, 7) },
            };

            var actual = queen.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteQueenReturnsAllLegalMovesUpwardTable()
        {
            var queen = new Queen((7, 3), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>() {(7, 3), (6, 3) },
                new List<(int, int)>() {(7, 3), (6, 3), (5, 3) },
                new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3) },
                new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3), (3, 3) },
                new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3), (3, 3), (2, 3) },
                new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3), (3, 3), (2, 3), (1, 3) },
                new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3), (3, 3), (2, 3), (1, 3), (0, 3)},

                new List<(int, int)>() {(7, 3), (7, 4) },
                new List<(int, int)>() {(7, 3), (7, 4), (7, 5) },
                new List<(int, int)>() {(7, 3), (7, 4), (7, 5), (7, 6) },
                new List<(int, int)>() {(7, 3), (7, 4), (7, 5), (7, 6), (7, 7)},

                new List<(int, int)>() {(7, 3), (7, 2) },
                new List<(int, int)>() {(7, 3), (7, 2), (7, 1) },
                new List<(int, int)>() {(7, 3), (7, 2), (7, 1), (7, 0)},

                new List<(int, int)>() {(7, 3), (6, 2) },
                new List<(int, int)>() {(7, 3), (6, 2), (5, 1) },
                new List<(int, int)>() {(7, 3), (6, 2), (5, 1), (4, 0)},

                new List<(int, int)>() {(7, 3), (6, 4) },
                new List<(int, int)>() {(7, 3), (6, 4), (5, 5) },
                new List<(int, int)>() {(7, 3), (6, 4), (5, 5), (4, 6) },
                new List<(int, int)>() {(7, 3), (6, 4), (5, 5), (4, 6), (3, 7)},
            };

            var actual = queen.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackQueenReturnsAllLegalMovesMiddleTable()
        {
            var queen = new Queen((3, 4), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>() {(3, 4), (2, 4) },
                new List<(int, int)>() {(3, 4), (2, 4), (1, 4) },
                new List<(int, int)>() {(3, 4), (2, 4), (1, 4), (0, 4) },

                new List<(int, int)>() {(3, 4), (3, 5) },
                new List<(int, int)>() {(3, 4), (3, 5), (3, 6) },
                new List<(int, int)>() {(3, 4), (3, 5), (3, 6), (3, 7) },


                new List<(int, int)>() {(3, 4), (4, 4) },
                new List<(int, int)>() {(3, 4), (4, 4), (5, 4) },
                new List<(int, int)>() {(3, 4), (4, 4), (5, 4), (6, 4) },
                new List<(int, int)>() {(3, 4), (4, 4), (5, 4), (6, 4), (7, 4) },


                new List<(int, int)>() {(3, 4), (3, 3) },
                new List<(int, int)>() {(3, 4), (3, 3), (3, 2) },
                new List<(int, int)>() {(3, 4), (3, 3), (3, 2), (3, 1) },
                new List<(int, int)>() {(3, 4), (3, 3), (3, 2), (3, 1), (3, 0) },

                new List<(int, int)>() {(3, 4), (2, 3) },
                new List<(int, int)>() {(3, 4), (2, 3), (1, 2) },
                new List<(int, int)>() {(3, 4), (2, 3), (1, 2), (0, 1) },

                new List<(int, int)>() {(3, 4), (2, 5) },
                new List<(int, int)>() {(3, 4), (2, 5), (1, 6) },
                new List<(int, int)>() {(3, 4), (2, 5), (1, 6), (0, 7) },


                new List<(int, int)>() {(3, 4), (4, 3) },
                new List<(int, int)>() {(3, 4), (4, 3), (5, 2) },
                new List<(int, int)>() {(3, 4), (4, 3), (5, 2), (6, 1) },
                new List<(int, int)>() {(3, 4), (4, 3), (5, 2), (6, 1), (7, 0) },

                new List<(int, int)>() {(3, 4), (4, 5) },
                new List<(int, int)>() {(3, 4), (4, 5), (5, 6) },
                new List<(int, int)>() {(3, 4), (4, 5), (5, 6), (6, 7), },

            };

            var actual = queen.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteQueenReturnsAllLegalMovesMiddleTable()
        {
            var queen = new Queen((5, 3), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>() {(5, 3), (4, 3) },
                new List<(int, int)>() {(5, 3), (4, 3), (3, 3) },
                new List<(int, int)>() {(5, 3), (4, 3), (3, 3), (2, 3) },
                new List<(int, int)>() {(5, 3), (4, 3), (3, 3), (2, 3), (1, 3) },
                new List<(int, int)>() {(5, 3), (4, 3), (3, 3), (2, 3), (1, 3), (0, 3)},

                new List<(int, int)>() {(5, 3), (5, 4) },
                new List<(int, int)>() {(5, 3), (5, 4), (5, 5) },
                new List<(int, int)>() {(5, 3), (5, 4), (5, 5), (5, 6) },
                new List<(int, int)>() {(5, 3), (5, 4), (5, 5), (5, 6), (5, 7)},

                new List<(int, int)>() {(5, 3), (6, 3) },
                new List<(int, int)>() {(5, 3), (6, 3), (7, 3)},

                new List<(int, int)>() {(5, 3), (5, 2) },
                new List<(int, int)>() {(5, 3), (5, 2), (5, 1) },
                new List<(int, int)>() {(5, 3), (5, 2), (5, 1), (5, 0)},

                new List<(int, int)>() {(5, 3), (4, 2) },
                new List<(int, int)>() {(5, 3), (4, 2), (3, 1) },
                new List<(int, int)>() {(5, 3), (4, 2), (3, 1), (2, 0)},

                new List<(int, int)>() {(5, 3), (4, 4) },
                new List<(int, int)>() {(5, 3), (4, 4), (3, 5) },
                new List<(int, int)>() {(5, 3), (4, 4), (3, 5), (2, 6) },
                new List<(int, int)>() {(5, 3), (4, 4), (3, 5), (2, 6), (1, 7)},

                new List<(int, int)>() {(5, 3), (6, 2) },
                new List<(int, int)>() {(5, 3), (6, 2), (7, 1)},

                new List<(int, int)>() {(5, 3), (6, 4) },
                new List<(int, int)>() {(5, 3), (6, 4), (7, 5)},
            };

            var actual = queen.GetLegalMoves();

            Assert.Equal(expected, actual);
        }
    }
}
