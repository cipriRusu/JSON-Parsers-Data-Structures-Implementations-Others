using ChessMoves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public class CastingValidator
    {
        private IBoard board;
        public CastingValidator(IBoard board) => this.board = board;

        public bool IsValid(Player player, bool IsKingSide)
        {
            var castlings = board
                .Where(x => x is ICastable)
                .Where(x => x.PlayerColour == player);

            var king = castlings.Where(x => x is IKing);
            var rock = castlings.Where(x => x is IRock).Select(x => (IRock)x);

            rock = IsKingSide ? 
                rock.Where(x => x.CastlingDirection == CastlingDirection.KingSide) : 
                rock.Where(x => x.CastlingDirection == CastlingDirection.QueenSide);

            var castlableRock = (ICastable)rock.Single();
            var castableKing = (ICastable)king.Single();

            castableKing.CastlingDirection = IsKingSide ? CastlingDirection.KingSide : CastlingDirection.QueenSide;

            return castlableRock.CanPerformCastling(board) && castableKing.CanPerformCastling(board);
        }
    }
}
