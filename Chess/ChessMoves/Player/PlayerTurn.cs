using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PlayerTurn
    {
        private IBoardState BoardState;
        public PlayerTurn(IBoardState boardState) => BoardState = boardState;
        internal void NextPlayer() => BoardState.TurnToMove = BoardState.TurnToMove == Player.White ? Player.Black : Player.White;
    }
}
