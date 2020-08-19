using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PlayerTurn
    {
        private IGame Game;
        public PlayerTurn(IGame game) => Game = game;
        internal void SwitchToNextPlayer() => Game.TurnToMove = Game.TurnToMove == Player.White ? Player.Black : Player.White;
    }
}
