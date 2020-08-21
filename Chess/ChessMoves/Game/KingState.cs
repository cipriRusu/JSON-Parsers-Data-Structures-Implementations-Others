using ChessMoves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ChessGame.Game
{
    public class KingState
    {
        private IBoard board;
        public KingState(IBoard board) => this.board = board;

        public bool Checked(IUserMove move)
        {
            var king = (IKing)board.Where(x => x is IKing && x.PlayerColour != move.PlayerColor).Single();

            return king.IsChecked(board);
        }

        public bool CheckMated(IUserMove move)
        {
            var king = (IKing)board.Where(x => x is IKing && x.PlayerColour != move.PlayerColor).Single();
            
            return king.IsCheckMate(board);
        }
    }
}
