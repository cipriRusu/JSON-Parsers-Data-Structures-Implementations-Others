using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class PawnTest
    {
        [Fact]
        public void BlackPawnReturnsCorrectLegalMoveDownwardTableFromStartIndex()
        {
            var pawn = new Pawn((1, 0), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>{(1, 0), (2, 0) },
                new List<(int, int)>{(1, 0), (2, 0), (3, 0) }
            };

            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackPawnReturnsCorrectLegalMoveFurther()
        {
            var pawn = new Pawn((4, 0), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>{(4, 0), (5, 0)}
            };
            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackPawnInsideBoardReturnsCorrectLegalMoveDownwardTableFromStartIndex()
        {
            var pawn = new Pawn((1, 5), Player.Black);

            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>{(1, 5), (2, 5) },
                new List<(int, int)>{(1, 5), (2, 5), (3, 5) }
            };

            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackPawnInsideBoardReturnsNoMovesAtEdgeOfBoard()
        {
            var pawn = new Pawn((7, 5), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>() { };
            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackPawnReturnsEmptyListForEndOfBoard()
        {
            var pawn = new Pawn((7, 0), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>() { };
            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhitePawnReturnsCorrectLegalMoveDownwardTableFromStartIndex()
        {
            var pawn = new Pawn((6, 0), Player.White);

            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>{(6, 0), (5, 0) },
                new List<(int, int)>{(6, 0), (5, 0), (4, 0) }
            };

            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhitePawnReturnsCorrectLegalMovementsFromStartIndexBoardInterior()
        {
            var pawn = new Pawn((6, 3), Player.White);

            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>{(6, 3), (5, 3) },
                new List<(int, int)>{(6, 3), (5, 3), (4, 3) }
            };


            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhitePawnInsideBoardReturnsCorrectLegalMoveFurther()
        {
            var pawn = new Pawn((5, 0), Player.White);

            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>{(5, 0), (4, 0) },
            };

            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhitePawnInsideBoardReturnsEmptyListForEndOfBoard()
        {
            var pawn = new Pawn((0, 5), Player.White);
            var expected = new List<IEnumerable<(int, int)>>() { };

            var actual = pawn.GetLegalMoves();

            Assert.Equal(expected, actual);
        }
    }
}
