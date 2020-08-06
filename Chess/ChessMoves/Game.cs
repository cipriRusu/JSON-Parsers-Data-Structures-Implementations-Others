using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class Game
    {
        public bool IsCheckMate => boardState.IsCheckMate;
        public bool IsCheck => boardState.IsCheck;
        public Player PlayerTurn => boardState.TurnToMove;

        private readonly IBoardState boardState = new ChessBoard();
        public IChessPiece this[int i, int j] => boardState[i, j];

        public void Input(string input)
        {
            var moves = new MovementParser(input.Split(',')).AllMoves;

            foreach(var move in moves)
            {
                boardState.GetAndPerform(move);
                new PlayerTurn(boardState).NextPlayer();
            }
        }
    }
}
