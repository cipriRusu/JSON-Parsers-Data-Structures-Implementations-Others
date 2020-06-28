﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class KingCheckTest
    {
        [Fact]
        public void KingCheckMateReturnsTrueForValidBlackKingInCheckMate()
        {
            var board = new Piece[8, 8];
            board[0, 0] = new King((0, 0), Player.White);
            board[0, 7] = new Rock((0, 7), Player.Black);
            board[7, 0] = new Rock((7, 0), Player.Black);
            board[7, 7] = new Bishop((7, 7), Player.Black);

            Assert.True(new KingCheck(board, Player.White).IsCheckMate);
        }

        [Fact]
        public void KingCheckMateReturnsFalseForBlackKingWithOneSafeMove()
        {
            var board = new Piece[8, 8];
            board[7, 0] = new King((7, 0), Player.White);
            board[0, 7] = new Rock((0, 7), Player.Black);
            board[7, 7] = new Bishop((7, 7), Player.Black);

            Assert.False(new KingCheck(board, Player.White).IsCheckMate);
        }

        [Fact]
        public void KingCheckReturnsTrueForValidBlackKingInCheck()
        {
            var board = new Piece[8, 8];
            board[0, 0] = new King((0, 0), Player.White);
            board[0, 7] = new Rock((0, 7), Player.Black);
            board[7, 7] = new Bishop((7, 7), Player.Black);

            Assert.True(new KingCheck(board, Player.White).IsCheck);
        }

        [Fact]
        public void KingCheckReturnsFalseForValidBlackKingSafe()
        {
            var board = new Piece[8, 8];
            board[7, 7] = new King((7, 7), Player.White);
            board[0, 0] = new Rock((0, 0), Player.Black);

            Assert.False(new KingCheck(board, Player.White).IsCheck);
        }

        [Fact]
        public void KingCheckReturnsTrueForUnBlockedDiagonal()
        {
            var board = new Piece[8, 8];
            board[1, 5] = new King((1, 5), Player.Black);
            board[4, 2] = new Bishop((4, 2), Player.White);

            Assert.True(new KingCheck(board, Player.Black).IsCheck);
        }

        [Fact]
        public void KingCheckReturnsFalseForBlockedDiagonal()
        {
            var board = new Piece[8, 8];
            board[1, 5] = new King((1, 5), Player.Black);
            board[4, 2] = new Bishop((4, 2), Player.White);
            board[3, 3] = new Pawn((3, 3), Player.Black);

            Assert.False(new KingCheck(board, Player.Black).IsCheck);
        }
    }
}
