using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace ChessMoves
{
    internal class Pawn : Piece
    {
        public Pawn((int, int) inputIndex, Player playerColour) : 
            base(inputIndex, playerColour)
        { base.PieceType = PieceType.Pawn; }

        public Pawn(string chessBoardIndex, Player playerColour) : 
            base(chessBoardIndex, playerColour)
        {
            base.PieceType = PieceType.Pawn;
            base.CurrentPosition = base.customIndex.GetMatrixIndex(chessBoardIndex);
            base.PlayerColour = playerColour;
        }

        public override IEnumerable<IEnumerable<(int, int)>> GetLegalMoves()
        {
            const int BLACKSTARTPOSITION = 1;
            const int WHITESTARTPOSITION = 6;

            var paths = new List<(int, int)>();

            if (PlayerColour == Player.Black)
            {
                if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2))
                {
                    for (int i = CurrentPosition.Item1; i <= CurrentPosition.Item1 + 1; i++)
                    {
                        paths.Add((i, CurrentPosition.Item2));
                    }

                    if(CurrentPosition.Item1 == BLACKSTARTPOSITION)
                    {
                        paths.Add((paths.Last().Item1 + 1, paths.Last().Item2));
                    }
                }
            }
            else if (PlayerColour == Player.White)
            {
                if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2))
                {
                    for (int i = CurrentPosition.Item1; i >= CurrentPosition.Item1 - 1; i--)
                    {
                        paths.Add((i, CurrentPosition.Item2));
                    }

                    if (CurrentPosition.Item1 == WHITESTARTPOSITION)
                    {
                        paths.Add((paths.Last().Item1 - 1, paths.Last().Item2));
                    }
                }
            }

            return paths.Select((x, y) => paths.Take(y + 1)).Skip(1);
        }
    }
}