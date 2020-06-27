using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class PawnAggregateTest
    {
        [Fact]
        public void ReturnAllPawnCapturesForUnmovedPawns()
        {
            var pieceBoard = new Piece[8, 8];

            pieceBoard[7, 0] = new Rock("a1", Player.White);
            pieceBoard[7, 1] = new Knight("b1", Player.White);
            pieceBoard[7, 2] = new Bishop("c1", Player.White);
            pieceBoard[7, 3] = new Queen("d1", Player.White);
            pieceBoard[7, 4] = new King("e1", Player.White);
            pieceBoard[7, 5] = new Bishop("f1", Player.White);
            pieceBoard[7, 6] = new Knight("g1", Player.White);
            pieceBoard[7, 7] = new Rock("h1", Player.White);

            pieceBoard[6, 0] = new Pawn("a2", Player.White);
            pieceBoard[6, 1] = new Pawn("b2", Player.White);
            pieceBoard[6, 2] = new Pawn("c2", Player.White);
            pieceBoard[6, 3] = new Pawn("d2", Player.White);
            pieceBoard[6, 4] = new Pawn("e2", Player.White);
            pieceBoard[6, 5] = new Pawn("f2", Player.White);
            pieceBoard[6, 6] = new Pawn("g2", Player.White);
            pieceBoard[6, 7] = new Pawn("h2", Player.White);

            var expected = new List<(int, int)>()
            { (5, 1), (5, 2), (5, 0), (5, 3), (5, 1), (5, 4), (5, 2),
              (5, 5), (5, 3), (5, 6), (5, 4), (5, 7), (5, 5), (5, 6)
            };

            Assert.Equal(expected, new PawnAggregate(pieceBoard, Player.White).Attacks);
        }

        [Fact]
        public void ReturnAllPawnCapturesAfterSeveralMoves()
        {
            var pieceBoard = new Piece[8, 8];

            pieceBoard[7, 0] = new Rock("a1", Player.White);
            pieceBoard[7, 1] = new Knight("b1", Player.White);
            pieceBoard[7, 2] = new Bishop("c1", Player.White);
            pieceBoard[7, 3] = new Queen("d1", Player.White);
            pieceBoard[7, 4] = new King("e1", Player.White);
            pieceBoard[7, 5] = new Bishop("f1", Player.White);
            pieceBoard[7, 6] = new Knight("g1", Player.White);
            pieceBoard[7, 7] = new Rock("h1", Player.White);

            pieceBoard[6, 1] = new Pawn("b2", Player.White);
            pieceBoard[6, 2] = new Pawn("c2", Player.White);
            pieceBoard[6, 3] = new Pawn("d2", Player.White);
            pieceBoard[6, 4] = new Pawn("e2", Player.White);
            pieceBoard[6, 6] = new Pawn("g2", Player.White);
            pieceBoard[6, 7] = new Pawn("h2", Player.White);

            pieceBoard[6, 5] = new Pawn("g3", Player.White);
            pieceBoard[6, 0] = new Pawn("a4", Player.White);

            var expected = new List<(int, int)>()
            { (3, 1), (5, 2), (5, 0), (5, 3), (5, 1), (5, 4), (5, 2),
              (5, 5), (5, 3), (4, 7), (4, 5), (5, 7), (5, 5), (5, 6)
            };

            Assert.Equal(expected, new PawnAggregate(pieceBoard, Player.White).Attacks);
        }
    }
}
