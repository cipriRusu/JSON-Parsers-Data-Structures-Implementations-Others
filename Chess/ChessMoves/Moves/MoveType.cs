using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveType
    {
        public IUserMove Move { get; }

        public MoveType(string userInput, Player playerTurn) => Move = MovementTypeDeterminator(userInput, playerTurn);

        private static IUserMove MovementTypeDeterminator(string input, Player playerTurn)
        {
            if (input.Equals("0-0"))
                return new KingCastlingUserMove(input, playerTurn);
            else if (input.Equals("0-0-0"))
                return new QueenCastlingUserMove(input, playerTurn);
            else if (input.EndsWith("+"))
                return new KingCheckUserMove(input[0..^1], playerTurn);
            else if (input.EndsWith("#"))
                return new KingCheckMateUserMove(input[0..^1], playerTurn);
            else if (input.Contains('='))
                return new PromotionUserMove(input[0..^2], playerTurn);
            else if (input.EndsWith("e.p."))
                return new EnPassantUserMove(input[0..^4], playerTurn);
            else if (input.Contains("x"))
                return new CaptureUserMove(input, playerTurn);
            else
                return new StandardUserMove(input, playerTurn);
        }
    }
}
