﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    internal class Rock : Piece
    {
        public Rock((int, int) currentPosition, Player playerColour) : base(currentPosition, playerColour)
        { base.PieceType = PieceType.Rock; }

        public Rock(string chessBoardIndex, Player playerColour) : base(chessBoardIndex, playerColour)
        {
            PieceType = PieceType.Rock;
            CurrentPosition = customIndex.GetMatrixIndex(chessBoardIndex);
            PlayerColour = playerColour;
        }

        public override IEnumerable<IEnumerable<(int, int)>> GetLegalMoves() => RowsAndColumns();
    }
}