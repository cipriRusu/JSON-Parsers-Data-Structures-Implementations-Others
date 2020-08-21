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
        public bool FlagInCheck { get; set; }
        public bool FlagInCheckMate { get; set; }
        private IBoard Board { get; set; }
        public KingState(IBoard board) => this.Board = board;

        public bool Checked(IUserMove move)
        {
            var king = GetKing(Opponent(move.PlayerColor));

            if (!FlagInCheck && king.IsChecked(Board)) return true;

            else if (!FlagInCheck && !king.IsChecked(Board)) throw new UserMoveException(move, "Invalid check move");

            else if (FlagInCheck && GetKing(move.PlayerColor).IsChecked(Board))
                throw new UserMoveException(move, $"Current move keeps {move.PlayerColor} King in Check");

            else return false;
        }

        public bool CheckMated(IUserMove move)
        {
            var king = GetKing(Opponent(move.PlayerColor));

            return !FlagInCheckMate && king.IsCheckMate(Board) ? true : throw new UserMoveException(move, "King is CheckMated!");
        }

        private IKing GetKing(Player player) => (IKing)Board.Where(x => x is IKing && x.PlayerColour == player).Single();

        private Player Opponent(Player player) => player == Player.White ? Player.Black : Player.White;
    }
}
