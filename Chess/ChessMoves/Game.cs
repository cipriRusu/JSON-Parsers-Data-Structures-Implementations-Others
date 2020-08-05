using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class Game
    {
        private IBoardState boardState;
        public Game(IBoardState currentState)
        {
            InitializeBlack(currentState);
            InitializeWhite(currentState);

            boardState = currentState;
        }

        private void InitializeBlack(IBoardState currentState)
        {
            currentState[0, 0] = new Rock("a8", Player.Black);
            currentState[0, 1] = new Knight("b8", Player.Black);
            currentState[0, 2] = new Bishop("c8", Player.Black);
            currentState[0, 3] = new Queen("d8", Player.Black);
            currentState[0, 4] = new King("e8", Player.Black);
            currentState[0, 5] = new Bishop("f8", Player.Black);
            currentState[0, 6] = new Knight("g8", Player.Black);
            currentState[0, 7] = new Rock("h8", Player.Black);

            currentState[1, 0] = new Pawn("a7", Player.Black);
            currentState[1, 1] = new Pawn("b7", Player.Black);
            currentState[1, 2] = new Pawn("c7", Player.Black);
            currentState[1, 3] = new Pawn("d7", Player.Black);
            currentState[1, 4] = new Pawn("e7", Player.Black);
            currentState[1, 5] = new Pawn("f7", Player.Black);
            currentState[1, 6] = new Pawn("g7", Player.Black);
            currentState[1, 7] = new Pawn("h7", Player.Black);
        }

        private void InitializeWhite(IBoardState currentState)
        {
            currentState[7, 0] = new Rock("a1", Player.White);
            currentState[7, 1] = new Knight("b1", Player.White);
            currentState[7, 2] = new Bishop("c1", Player.White);
            currentState[7, 3] = new Queen("d1", Player.White);
            currentState[7, 4] = new King("e1", Player.White);
            currentState[7, 5] = new Bishop("f1", Player.White);
            currentState[7, 6] = new Knight("g1", Player.White);
            currentState[7, 7] = new Rock("h1", Player.White);

            currentState[6, 0] = new Pawn("a2", Player.White);
            currentState[6, 1] = new Pawn("b2", Player.White);
            currentState[6, 2] = new Pawn("c2", Player.White);
            currentState[6, 3] = new Pawn("d2", Player.White);
            currentState[6, 4] = new Pawn("e2", Player.White);
            currentState[6, 5] = new Pawn("f2", Player.White);
            currentState[6, 6] = new Pawn("g2", Player.White);
            currentState[6, 7] = new Pawn("h2", Player.White);
        }
    }
}
