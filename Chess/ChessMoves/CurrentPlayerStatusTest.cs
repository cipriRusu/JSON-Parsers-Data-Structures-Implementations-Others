using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessMoves
{
    public class CurrentPlayerStatusTest
    {
        [Fact]
        public void CurrentPlayerStatusReturnsFalseCheckForStartOfGameWhitePlayer()
        {
            var status = new CurrentPlayerStatus(Player.White, new ChessBoard());
            Assert.False(status.IsChecked);
        }

        [Fact]
        public void CurrentPlayerStatusReturnsFalseCheckForStartOfGameBlackPlayer()
        {
            var status = new CurrentPlayerStatus(Player.Black, new ChessBoard());
            Assert.False(status.IsChecked);
        }

        [Fact]
        public void CurrentPlayerStatusReturnsTrueCheckForWhitePlayer()
        {
            var board = new ChessBoard();

            board.UserMoves(new string[] {"Nc3 f5", "e4 fxe4", "Nxe4 Nf6", "Nxf6+"});

            var status = new CurrentPlayerStatus(Player.Black, board);

            Assert.True(status.IsChecked);
        }

        [Fact]
        public void CurrentPlayerStatusReturnsFalseForOpponentChecked()
        {
            var board = new ChessBoard();

            board.UserMoves(new string[] { "Nc3 f5", "e4 fxe4", "Nxe4 Nf6", "Nxf6+" });

            var status = new CurrentPlayerStatus(Player.White, board);

            Assert.False(status.IsChecked);
        }

        [Fact]
        public void CurrentPlayerStatusReturnsTrueCheckForBlackPlayer()
        {
            var board = new ChessBoard();

            board.UserMoves(new string[] { "d4 Nf6", "Bg5 c6", "e3 Qa5+" });

            var status = new CurrentPlayerStatus(Player.White, board);

            Assert.True(status.IsChecked);
        }

        [Fact]
        public void CurrentPlayerStatusReturnsFalseForOpponentCheckBlackPlayer()
        {
            var board = new ChessBoard();

            board.UserMoves(new string[] { "d4 Nf6", "Bg5 c6", "e3 Qa5+" });

            var status = new CurrentPlayerStatus(Player.Black, board);

            Assert.False(status.IsChecked);
        }
    }
}
