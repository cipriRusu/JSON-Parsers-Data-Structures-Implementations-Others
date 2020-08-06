using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public class PlayerTurn
    {
        private Player CurrentTurn;
        public PlayerTurn(Player currentPlayer) => CurrentTurn = currentPlayer;
        public Player NextTurn => CurrentTurn == Player.White ? Player.Black : Player.White;
    }
}
