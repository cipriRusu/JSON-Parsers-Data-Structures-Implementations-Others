﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CaptureUserMove : UserMove, IUserMove
    {
        public CaptureUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public void PerformMoveType(ChessBoard board) 
        {
            var current = board.GetAllPieces()
                .Where(x => x != null
                            && x.PlayerColour == PlayerColor
                            && x.PieceType == PieceType
                            && x.CanCapture(MoveIndex)
                            && new ConstraintValidator(x, this).IsValid);

            current.Single().PerformCapture(MoveIndex, board);
        }
    }
}
