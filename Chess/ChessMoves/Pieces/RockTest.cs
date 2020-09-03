using ChessGame.Paths;
using ChessMoves.Paths;
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
            var actual = new Rock("a8", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)> {(0, 0), (0, 1) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (0, 1), (0, 2) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)}, (0, 0)),

                new MovePath(new List<(int, int)> {(0, 0), (1, 0) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (1, 0), (2, 0) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0) }, (0, 0)),
                new MovePath(new List<(int, int)> {(0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, (0, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void BlackRockReturnsAllPossibleMovesFurtherDownBoard()
        {
            var actual = new Rock("c5", Player.Black).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>() {(3, 2), (2, 2) }, (3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (2, 2), (1, 2) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (2, 2), (1, 2), (0, 2)},(3, 2)),

                new MovePath(new List<(int, int)>() {(3, 2), (3, 3) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (3, 3), (3, 4) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5), (3, 6) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7)},(3, 2)),

                new MovePath(new List<(int, int)>() {(3, 2), (4, 2) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (4, 2), (5, 2) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (4, 2), (5, 2), (6, 2) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (4, 2), (5, 2), (6, 2), (7, 2)},(3, 2)),

                new MovePath(new List<(int, int)>() {(3, 2), (3, 1) },(3, 2)),
                new MovePath(new List<(int, int)>() {(3, 2), (3, 1), (3, 0)},(3, 2))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhiteRockReturnsAllPossibleMovesFromStart()
        {
            var actual = new Rock("a1", Player.White).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>() {(7, 0), (6, 0) }, (7, 0)),
                new MovePath(new List<(int, int)>() {(7, 0), (6, 0), (5, 0) }, (7, 0)),
                new MovePath(new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0) }, (7, 0)),
                new MovePath(new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0), (3, 0) }, (7, 0)),
                new MovePath(new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0), (3, 0), (2, 0) }, (7, 0)),
                new MovePath(new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0), (3, 0), (2, 0), (1, 0) }, (7, 0)),
                new MovePath(new List<(int, int)>() {(7, 0), (6, 0), (5, 0), (4, 0), (3, 0), (2, 0), (1, 0), (0, 0) }, (7, 0)),

                new MovePath(new List<(int, int)>() { (7, 0), (7, 1) }, (7, 0)),
                new MovePath(new List<(int, int)>() { (7, 0), (7, 1), (7, 2) }, (7, 0)),
                new MovePath(new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3) }, (7, 0)),
                new MovePath(new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3), (7, 4) }, (7, 0)),
                new MovePath(new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3), (7, 4), (7, 5) }, (7, 0)),
                new MovePath(new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3), (7, 4), (7, 5), (7, 6) }, (7, 0)),
                new MovePath(new List<(int, int)>() { (7, 0), (7, 1), (7, 2), (7, 3), (7, 4), (7, 5), (7, 6), (7, 7) }, (7, 0))
            };

            Assert.Equal(expected, actual, new PathComparer());
        }

        [Fact]
        public void WhiteRockReturnsAllPossibleMovesFurtherUpBoard()
        {
            var actual = new Rock("c3", Player.White).Moves;

            var expected = new List<IPath>()
            {
                new MovePath(new List<(int, int)>() {(5, 2), (4, 2) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (4, 2), (3, 2) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (4, 2), (3, 2), (2, 2) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (4, 2), (3, 2), (2, 2), (1, 2) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (4, 2), (3, 2), (2, 2), (1, 2), (0, 2) }, (5, 2)),

                new MovePath(new List<(int, int)>() {(5, 2), (5, 3) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (5, 3), (5, 4) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (5, 3), (5, 4), (5, 5) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (5, 3), (5, 4), (5, 5), (5, 6) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (5, 7) }, (5, 2)),

                new MovePath(new List<(int, int)>() {(5, 2), (6, 2) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (6, 2), (7, 2) }, (5, 2)),

                new MovePath(new List<(int, int)>() {(5, 2), (5, 1) }, (5, 2)),
                new MovePath(new List<(int, int)>() {(5, 2), (5, 1), (5, 0) }, (5, 2))

            };

            Assert.Equal(expected, actual, new PathComparer());
        }
    }
}