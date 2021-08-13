using Xunit;

namespace ChessMoves
{
    public class GameTest
    {
        [Fact]
        public void GameThrowsUserMoveExceptionForEmptyInput()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input(string.Empty));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForEmptyStringInput()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input(""));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForEmptyStringInInput()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input("e4 e5, , Nc3"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForInvalidTextInInput()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input("gibberish, as input"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForInvalidInputInGame()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input("Nc3 f5, AABC Nf3"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForValidInputAndInvalidMove()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input("e4 e5, exd4"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForValidAmbiguousMoveAndUnspecifiedFile()
        {
            Assert.Throws<PieceException>(() => new Game().Input("e4 Nh6, e5 Na6, e6 xe6"));
        }
        [Fact]
        public void GameThrowsUserMoveExceptionForValidAmbiguousMoveAndUnspecfiedRank()
        {
            Assert.Throws<PieceException>(() => new Game().Input("e4 h5, Nc3 a5, e5 Ra6, e6 Rh6, Nh3 Rxe6"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForValidMoveAndUnspecifiedPiece()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input("e4 e5, a3 h4"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForEnPassantCaptureOfInvalidPawn()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input("e4 d5, e5 dxe4e.p."));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForInvalidSmallCastlingMovedPiece()
        {
            Assert.Throws<UserMoveException>(() =>
               new Game().Input("Nh3 Na6, g3 d6, Bg2 Bxh3, Bxh3 Rb8, Kf1 Qd7, Ke1 Nc5, 0-0"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForInvalidSmallCastlingThroughCheck()
        {
            Assert.Throws<UserMoveException>(() =>
            new Game().Input("g3 e5, Nf3 d6, Bh3 Bxh3, 0-0"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForInvalidSmallCastlingUnclearPath()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input("g3 e5, Nh3 Na6, 0-0"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForInvalidLargeCastlingMovedPiece()
        {
            Assert.Throws<UserMoveException>(() =>
               new Game().Input("e4 e5, Na3 d6, Nh3 Bxh3, c3 Na6, Rg1 Qd7, Nc4 Rb8, Nxe5 Ra8, Rh1 0-0-0"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForInvalidLargeCastlingThroughCheck()
        {
            Assert.Throws<UserMoveException>(() =>
            new Game().Input("e4 e5, Na3 d6, Nh3 Bxh3, c3 Na6, Rg1 Qd7, Nb5 Qe6, Nxd6 0-0-0"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForInvalidLargeCastlingUnclearPath()
        {
            Assert.Throws<UserMoveException>(() => new Game().Input("e4 e5, Na3 d6, Nh3 Bxh3, c3 Na6,Rg1 Qd7,Nb5 Qe6,a4 Nb8, a5 0-0-0"));
        }

        [Fact]
        public void GameThrowsUserMoveExceptionForMoveAfterCheckMate()
        {
            Assert.Throws<UserMoveException>(() => new Game()
            .Input("g3 d5, Bh3 Bxh3, Nxh3 e5,Na3 Qd7, Ng1 Nf6, " +
            "h4 Bxa3, bxa3 c5, d3 Nc6, Bd2 0-0, Nf3 e4, " +
            "dxe4 dxe4, Nh2 Qh3, Nf3 Qxh1+, Ng1 Qxg1#, Rb1"));
        }

        [Fact]
        public void GameReturnsValidValuesForSimpleTwoMoveGame()
        {
            var game = new Game();
            game.Input("e4 e5, Nf3 Nc6, Bb5");

            Assert.Equal(Player.Black, game.TurnToMove);
            Assert.False(game.IsCheck);
            Assert.False(game.IsCheckMate);
        }

        [Fact]
        public void GameReturnsValidValuesForSingleMove()
        {
            var game = new Game();
            game.Input("e4");

            Assert.Equal(Player.Black, game.TurnToMove);
            Assert.False(game.IsCheck);
            Assert.False(game.IsCheckMate);
        }

        [Fact]
        public void GameReturnsValidValuesForTwoMoves()
        {
            var game = new Game();
            game.Input("e4 e5");

            Assert.Equal(Player.White, game.TurnToMove);
            Assert.False(game.IsCheck);
            Assert.False(game.IsCheckMate);
        }

        [Fact]
        public void GameReturnsValidValuesForMultipleUnambiguousMoves()
        {
            var game = new Game();
            game.Input("e4 e5, Nf3 Nc6, Bb5 a6");

            Assert.Equal(Player.White, game.TurnToMove);
            Assert.False(game.IsCheck);
            Assert.False(game.IsCheckMate);
        }

        [Fact]
        public void GameReturnsValidValueForMultipleMovesAndCaptures()
        {
            var game = new Game();
            game.Input("Nc3 f5, e4 fxe4, Nxe4");

            Assert.Equal(Player.White, game[(4, 4)].Player);
        }
        
        [Fact]
        public void GameReturnsCheckForCheckedKing()
        {
            var game = new Game();
            game.Input("Nc3 f5,e4 fxe4, Nxe4 Nf6, Nxf6+");

            Assert.True(game.IsCheck);
        }

        [Fact]
        public void GameReturnsValidValueForCheckedAndEscapedKing()
        {
            var game = new Game();
            game.Input("Nc3 f5,e4 fxe4, Nxe4 Nf6, Nxf6+ gxf6");

            Assert.False(game.IsCheck);
        }

        [Fact]
        public void GameReturnsValidValueForFullGame()
        {
            var game = new Game();
            game.Input("Nc3 f5, e4 fxe4, Nxe4 Nf6, Nxf6+ gxf6, Qh5#");

            Assert.True(game.IsCheckMate);
        }

        [Fact]
        public void GameFailsForCheckedKingAndInvalidMove()
        {
            Assert.Throws<UserMoveException>(() =>
            new Game().Input("Nc3 f5, e4 fxe4, Nxe4 Nf6, Nxf6+ c6"));
        }

        [Fact]
        public void GameFailsForCheckedMoveAndUncheckedKing()
        {
            Assert.Throws<UserMoveException>(() =>
            new Game().Input("Nc3 f5, e4 fxe4, Nxe4 Nf6, Nc3+"));
        }

        [Fact]
        public void GamePropertyReturnsValidOutputForWhiteTurn()
        {
            var game = new Game();
            game.Input("Nc3 f5");

            Assert.Equal(Player.White, game.TurnToMove);
        }

        [Fact]
        public void GamePropertyReturnsValidOutputForBlackTurn()
        {
            var game = new Game();
            game.Input("Nc3 f5, e4");

            Assert.Equal(Player.Black, game.TurnToMove);
        }

        [Fact]
        public void IsPieceReturnsTrueForValidPieceTypeAndColour()
        {
            var board = new Game();

            Assert.True(board[(1, 0)] is Pawn);
            Assert.True(board[(1, 0)].Player == Player.Black);
        }

        [Fact]
        public void IsPieceReturnsFalseForOtherPieceInPlace()
        {
            var board = new Game();

            Assert.False(board[(1, 0)] is Rock);
        }

        [Fact]
        public void IsPieceReturnsFalseForWrongPlayer()
        {
            var board = new Game();

            Assert.False(board[(1, 0)].Player == Player.White);
        }

        [Fact]
        public void GameReturnsValidValuesForSmallCastlingBlackPlayer()
        {
            var game = new Game();
            game.Input("d4 Nf6,c4 g6,Nc3 Bg7,e4 d6,Nf3 0-0");

            Assert.True(game[(0, 6)] is King);
            Assert.True(game[(0, 5)] is Rock);
            Assert.True(game.TurnToMove == Player.White);
        }

        [Fact]
        public void GameReturnsValidValuesForSmallCastlingWhitePlayer()
        {
            var game = new Game();
            game.Input("e4 e5,Nf3 Nc6,Bb5 a6,Ba4 Nf6,0-0 Be7");

            Assert.True(game[(7, 6)] is King);
            Assert.True(game[(7, 5)] is Rock);
            Assert.True(game.TurnToMove == Player.White);
        }

        [Fact]
        public void GameReturnsValidValuesForBigCastlingWhitePlayer()
        {
            var game = new Game();

            game.Input("e4 g6, d4 Bg7, Nc3 d6, Be3 c6, Qd2 b5, 0-0-0 Nd7");

            Assert.True(game[(7, 2)] is King);
            Assert.True(game[(7, 3)] is Rock);
        }

        [Fact]
        public void GameReturnsValidValuesForPawnPromotionBlackPlayer()
        {
            var game = new Game();

            game.Input("e4 Nf6, Nc3 d5, e5 d4, exf6 dxc3,d4 cxb2, fxg7 bxa1=Q");

            Assert.True(game[(7, 0)] is Queen);
        }

        [Fact]
        public void GameReturnsValidValuesForPawnPromotionWhitePlayer()
        {
            var game = new Game();

            game.Input( "e4 Nf6, Nc3 d5, e5 d4, exf6 dxc3, d4 cxb2, fxg7 bxa1=Q, gxh8=Q Qxa2");

            Assert.True(game[(0, 7)] is Queen);
        }

        [Fact]
        public void GameReturnsValidValuesForBigCastlingBlackPlayer()
        {
            var game = new Game();

            game.Input("d4 Nf6, Bg5 c6, e3 Qa5+, Qd2 Qxg5, h4 Qg6, h5 Nxh5, Nf3 d6, " +
                "Nh4 Qe6, Bd3 g6, Nc3 b6, 0-0-0 Ba6, d5 Qd7, dxc6 Qc8, c7 Qxc7, Bxa6 Nxa6, Qd4 0-0-0");

            Assert.True(game[(0, 2)] is King);
            Assert.True(game[(0, 3)] is Rock);
        }

        [Fact]
        public void ChessBoardReturnsValidValuesForWhiteEnPassantCapture()
        {
            var game = new Game();
            game.Input("d3 Nh6, d4 Na6, Na3 Ng4, d5 e5, dxe6e.p." );
            Assert.True(game[(2, 4)] is Pawn);
            Assert.True(game[(2, 4)].Player == Player.White);
            Assert.Null(game[(3, 4)]);
        }

        [Fact]
        public void ChessBoardReturnsValidValueForBlackEnPassantCapture()
        {
            var game = new Game();
            game.Input("Na3 e5, Nh3 e4, d4 exd3e.p.");
            Assert.True(game[(5, 3)] is Pawn);
            Assert.True(game[(5, 3)].Player == Player.Black);
            Assert.Null(game[(4, 3)]);
        }

        [Fact]
        public void ChessBoardReturnsValidValueForSecondFullGameWhitePlayerCheckMated()
        {
            var game = new Game();

            game.Input("f4 c5, Nf3 e6, e3 h6, Na3 b6, " +
                "b3 Be7, Ke2 Kf8, g3 Bb7, " +
                "Bb2 Nf6, h4 Ng4, Qb1 Bf6, " +
                "Bh3 Bxb2, Qxb2 Bxf3+, Kxf3 Nxe3, " +
                "Kxe3 Kg8, Rhf1 h5, Nc4 Qe8, Ne5 d5, " +
                "Ke2 Rh6, Kd1 a6, Re1 Rf6, Nf3 Rg6, " +
                "c4 d4, Bg2 Qc6, Rf1 Qc7, Nh2 Ra7, " +
                "g4 Nc6, Rf3 hxg4, Rd3 Rf6, Qa3 Nb4, " +
                "Rc1 Qxf4, Ra1 Qxh2, Rh3 Qg1+,Ke2 Rf2#");

            Assert.True(game.IsCheckMate);
        }

        [Fact]
        public void ChessBoardReturnsValidValueForThirdFullGameBlackPlayerCheckMated()
        {
            var game = new Game();

            game.Input("d3 e5, Bd2 Bd6, g4 Qh4, e3 Bb4," +
                "d4 Bd6,d5 f5, g5 Qg4," +
                "Nf3 b6,Na3 Ba6, Bc3 c5, Nb5 Be7," +
                "h3 Qa4, Nc7+ Kd8, Bxa6 Qxa6, d6 " +
                "Bxd6, Qxd6 b5, Ne6+ Kc8, Qc7#");

            Assert.True(game.IsCheckMate);
        }
    }
}
