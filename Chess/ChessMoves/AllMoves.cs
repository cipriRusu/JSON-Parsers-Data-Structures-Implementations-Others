using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class AllMoves
    {
        private string[] userInput;
        public AllMoves(string[] userInput) => this.userInput = userInput;
        public List<UserMove> Moves => ConvertMoves(userInput);
        private List<UserMove> ConvertMoves(string[] input)
        {
            var output = new List<UserMove>();

            foreach (var move in input.Select(x => x.Split(' ')))
            {
                switch (move.Count())
                {
                    case 1:
                        output.Add(new UserMove(move.First()) { PlayerColor = Player.White });
                        break;
                    case 2:
                        output.Add(new UserMove(move.First()) { PlayerColor = Player.White });
                        output.Add(new UserMove(move.Last()) { PlayerColor = Player.Black });
                        break;
                    default:
                        throw new ArgumentException("Input not properly formated");
                }
            }

            return output;
        }
    }
}
