using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class RockTest
    {
        [Fact]
        public void BlackRockReturnsAllPossibleMovesFromStart()
        {
            var rock = new Rock((0, 0), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)> {(0, 0), (0, 1) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6) },
                new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},

                new List<(int, int)> {(0, 0), (1, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0) },
                new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)},
            };

            var actual = rock.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackRockReturnsAllPossibleMovesFurtherDownBoard()
        {
            var rock = new Rock((3, 2), Player.Black);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>() {(3, 2), (2, 2) },
                new List<(int, int)>() {(3, 2), (2, 2), (1, 2) },
                new List<(int, int)>() {(3, 2), (2, 2), (1, 2), (0, 2)},

                new List<(int, int)>() {(3, 2), (3, 3) },
                new List<(int, int)>() {(3, 2), (3, 3), (3, 4) },
                new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5) },
                new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5), (3, 6) },
                new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7)},

                new List<(int, int)>() {(3, 2), (4, 2) },
                new List<(int, int)>() {(3, 2), (4, 2), (5, 2) },
                new List<(int, int)>() {(3, 2), (4, 2), (5, 2), (6, 2) },
                new List<(int, int)>() {(3, 2), (4, 2), (5, 2), (6, 2), (7, 2)},

                new List<(int, int)>() {(3, 2), (3, 1) },
                new List<(int, int)>() {(3, 2), (3, 1), (3, 0)},
            };

            var actual = rock.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteRockReturnsAllPossibleMovesFromStart()
        {
            var rock = new Rock((7, 0), Player.White);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>() {(7, 0), (6, 0) },
                new List<(int, int)>() {(7, 0), (6, 0), (5, 0) },
                new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0) },
                new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0), (3, 0) },
                new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0), (3, 0), (2, 0) },
                new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0), (3, 0), (2, 0), (1, 0) },
                new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0), (3, 0), (2, 0), (1, 0), (0, 0) },

                new List<(int, int)>() { (7, 0), (7, 1) },
                new List<(int, int)>() { (7, 0), (7, 1), (7, 2) },
                new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3) },
                new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3), (7, 4) },
                new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3), (7, 4), (7, 5) },
                new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3), (7, 4), (7, 5), (7, 6) },
                new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3), (7, 4), (7, 5), (7, 6), (7, 7) },
            };

            var actual = rock.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhiteRockReturnsAllPossibleMovesFurtherUpBoard()
        {
            var rock = new Rock((5, 2), Player.White);
            var expected = new List<IEnumerable<(int, int)>>()
            {
                new List<(int, int)>() {(5, 2), (4, 2) },
                new List<(int, int)>() {(5, 2), (4, 2), (3, 2) },
                new List<(int, int)>() {(5, 2), (4, 2), (3, 2), (2, 2) },
                new List<(int, int)>() {(5, 2), (4, 2), (3, 2), (2, 2), (1, 2) },
                new List<(int, int)>() {(5, 2), (4, 2), (3, 2), (2, 2), (1, 2), (0, 2) },

                new List<(int, int)>() {(5, 2), (5, 3) },
                new List<(int, int)>() {(5, 2), (5, 3), (5, 4) },
                new List<(int, int)>() {(5, 2), (5, 3), (5, 4), (5, 5) },
                new List<(int, int)>() {(5, 2), (5, 3), (5, 4), (5, 5), (5, 6) },
                new List<(int, int)>() {(5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (5, 7) },

                new List<(int, int)>() {(5, 2), (6, 2) },
                new List<(int, int)>() {(5, 2), (6, 2), (7, 2) },

                new List<(int, int)>() {(5, 2), (5, 1) },
                new List<(int, int)>() {(5, 2), (5, 1), (5, 0) },

            };

            var actual = rock.Moves();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void test1()
        {
            var t1 = new Rock("a8", Player.Black);
        }
    }
}
