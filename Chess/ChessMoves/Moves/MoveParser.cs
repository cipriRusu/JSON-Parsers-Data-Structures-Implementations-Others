using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class MoveParser
    {
        public IEnumerable<string> InputToParse { get; private set; }
        public IEnumerable<IUserMove> AllMoves => GetMoveType(InputToParse);
        public MoveParser(IEnumerable<string> input) => InputToParse = input;

        private IEnumerable<IUserMove> GetMoveType(IEnumerable<string> input)
        {
            foreach (var move in input.Select(x => x.Trim(' ').Split(' ')))
            {
                switch (move.Length)
                {
                    case 1:
                        yield return new MoveType(move.Single(), Player.White).Move;
                        break;
                    case 2:
                        yield return new MoveType(move.First(), Player.White).Move;
                        yield return new MoveType(move.Last(), Player.Black).Move;
                        break;
                }
            }
        }
    }
}
