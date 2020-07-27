using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveType
    {
        private readonly string userInput;
        public IMove Move { get; private set; }
        public Player PlayerTurn { get; private set; }
        public MoveType(string userInput, Player playerTurn)
        {
            this.userInput = userInput;
            Move = MovementTypeDeterminator(userInput, playerTurn);
        }

        private IMove MovementTypeDeterminator(string input, Player playerTurn)
        {
            if (input.Contains('='))
            {
                return new PromotionUserMove(input[0..^2], playerTurn);
            }
            else if (input.EndsWith('+'))
            {
                return new CheckUserMove(input[0..^1], playerTurn);
            }
            else if (input.EndsWith('#'))
            {
                return new CheckMateUserMove(input[0..^1], playerTurn);
            }
            else if (input.EndsWith("e.p."))
            {
                return new EnPassantUserMove(input[0..^4], playerTurn);
            }
            else if (input.Contains("x"))
            {
                return new CaptureUserMove(input, playerTurn);
            }
            else
            {
                return new MoveUserMove(input, playerTurn);
            }

            throw new ArgumentException();
        }
    }
}
