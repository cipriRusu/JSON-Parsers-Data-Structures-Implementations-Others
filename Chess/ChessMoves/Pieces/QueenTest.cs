using ChessGame.Paths;
using ChessMoves.Paths;
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
            var actual = new Queen("d8", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>() {(0, 3), (0, 4) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (0, 4), (0, 5) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (0, 4), (0, 5), (0, 6) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (0, 4), (0, 5), (0, 6), (0, 7) }, (0, 3)),

                new MovePath(new List<(int, int)>() {(0, 3), (1, 3) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (1, 3), (2, 3) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3) },(0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3), (4, 3) },(0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3), (4, 3), (5, 3) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3) }, (0, 3)),

                new MovePath(new List<(int, int)>() {(0, 3), (0, 2) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (0, 2), (0, 1) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (0, 2), (0, 1), (0, 0)}, (0, 3)),

                new MovePath(new List<(int, int)>() {(0, 3), (1, 2) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (1, 2), (2, 1) }, (0, 3)),
                new MovePath(new List<(int, int)>() {(0, 3), (1, 2), (2, 1), (3, 0)}, (0, 3)),

                new MovePath(new List<(int, int)>(){(0, 3), (1, 4) }, (0, 3)),
                new MovePath(new List<(int, int)>(){(0, 3), (1, 4), (2, 5) }, (0, 3)),
                new MovePath(new List<(int, int)>(){(0, 3), (1, 4), (2, 5), (3, 6) }, (0, 3)),
                new MovePath(new List<(int, int)>(){(0, 3), (1, 4), (2, 5), (3, 6), (4, 7) }, (0, 3)),
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhiteQueenReturnsAllLegalMovesUpwardTable()
        {
            var actual = new Queen("d1", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>() {(7, 3), (6, 3) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 3), (5, 3) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3), (3, 3) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3), (3, 3), (2, 3) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3), (3, 3), (2, 3), (1, 3) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 3), (5, 3), (4, 3), (3, 3), (2, 3), (1, 3), (0, 3)}, (7, 3)),

                new MovePath(new List<(int, int)>() {(7, 3), (7, 4) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (7, 4), (7, 5) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (7, 4), (7, 5), (7, 6) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (7, 4), (7, 5), (7, 6), (7, 7)}, (7, 3)),

                new MovePath(new List<(int, int)>() {(7, 3), (7, 2) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (7, 2), (7, 1) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (7, 2), (7, 1), (7, 0)}, (7, 3)),

                new MovePath(new List<(int, int)>() {(7, 3), (6, 2) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 2), (5, 1) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 2), (5, 1), (4, 0)}, (7, 3)),

                new MovePath(new List<(int, int)>() {(7, 3), (6, 4) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 4), (5, 5) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 4), (5, 5), (4, 6) }, (7, 3)),
                new MovePath(new List<(int, int)>() {(7, 3), (6, 4), (5, 5), (4, 6), (3, 7)}, (7, 3)),
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackQueenReturnsAllLegalMovesMiddleTable()
        {
            var actual = new Queen("e5", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>() {(3, 4), (2, 4) }, (3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (2, 4), (1, 4) }, (3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (2, 4), (1, 4), (0, 4) }, (3, 4)),

                new MovePath(new List<(int, int)>() {(3, 4), (3, 5) }, (3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (3, 5), (3, 6) }, (3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (3, 5), (3, 6), (3, 7) }, (3, 4)),


                new MovePath(new List<(int, int)>() {(3, 4), (4, 4) }, (3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (4, 4), (5, 4) }, (3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (4, 4), (5, 4), (6, 4) }, (3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (4, 4), (5, 4), (6, 4), (7, 4) }, (3, 4)),


                new MovePath(new List<(int, int)>() {(3, 4), (3, 3) }, (3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (3, 3), (3, 2) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (3, 3), (3, 2), (3, 1) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (3, 3), (3, 2), (3, 1), (3, 0) },(3, 4)),

                new MovePath(new List<(int, int)>() {(3, 4), (2, 3) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (2, 3), (1, 2) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (2, 3), (1, 2), (0, 1) },(3, 4)),

                new MovePath(new List<(int, int)>() {(3, 4), (2, 5) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (2, 5), (1, 6) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (2, 5), (1, 6), (0, 7) },(3, 4)),


                new MovePath(new List<(int, int)>() {(3, 4), (4, 3) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (4, 3), (5, 2) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (4, 3), (5, 2), (6, 1) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (4, 3), (5, 2), (6, 1), (7, 0) },(3, 4)),

                new MovePath(new List<(int, int)>() {(3, 4), (4, 5) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (4, 5), (5, 6) },(3, 4)),
                new MovePath(new List<(int, int)>() {(3, 4), (4, 5), (5, 6), (6, 7), },(3, 4)),

            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhiteQueenReturnsAllLegalMovesMiddleTable()
        {
            var actual = new Queen("d3", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>() {(5, 3), (4, 3) }, (5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 3), (3, 3) }, (5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 3), (3, 3), (2, 3) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 3), (3, 3), (2, 3), (1, 3) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 3), (3, 3), (2, 3), (1, 3), (0, 3)},(5, 3)),

                new MovePath(new List<(int, int)>() {(5, 3), (5, 4) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (5, 4), (5, 5) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (5, 4), (5, 5), (5, 6) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (5, 4), (5, 5), (5, 6), (5, 7)},(5, 3)),

                new MovePath(new List<(int, int)>() {(5, 3), (6, 3) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (6, 3), (7, 3)},(5, 3)),

                new MovePath(new List<(int, int)>() {(5, 3), (5, 2) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (5, 2), (5, 1) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (5, 2), (5, 1), (5, 0)},(5, 3)),

                new MovePath(new List<(int, int)>() {(5, 3), (4, 2) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 2), (3, 1) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 2), (3, 1), (2, 0)},(5, 3)),

                new MovePath(new List<(int, int)>() {(5, 3), (4, 4) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 4), (3, 5) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 4), (3, 5), (2, 6) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (4, 4), (3, 5), (2, 6), (1, 7)},(5, 3)),

                new MovePath(new List<(int, int)>() {(5, 3), (6, 2) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (6, 2), (7, 1)},(5, 3)),

                new MovePath(new List<(int, int)>() {(5, 3), (6, 4) },(5, 3)),
                new MovePath(new List<(int, int)>() {(5, 3), (6, 4), (7, 5)},(5, 3)),
            };

            Assert.Equal(expected, actual, new PathComparer());
        }
    }
}
