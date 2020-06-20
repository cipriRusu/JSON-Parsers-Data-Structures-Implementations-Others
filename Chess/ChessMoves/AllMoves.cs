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

            var moves = input.Select(x => x)
                .Select(y => y.Split(' ')).Select(a => (
                new UserMove(a.First()) { PlayerColor = Player.White },
                new UserMove(a.Last()) { PlayerColor = Player.Black }));

            foreach (var item in moves)
            {
                output.Add(item.Item1);
                output.Add(item.Item2);
            }

            return output;
        }
    }
}
