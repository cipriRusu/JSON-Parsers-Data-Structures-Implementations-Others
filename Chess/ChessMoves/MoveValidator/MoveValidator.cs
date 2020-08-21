﻿using ChessMoves;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.MoveValidator
{
    public class MoveValidator
    {
        private IPiece[,] board;
        private IUserMove move;

        public MoveValidator(IPiece[,] board, IUserMove move)
        {
            this.board = board;
            this.move = move;
        }

        internal bool ValidatePath(IPath path)
        {
            var test = path.Path.Skip(1).SkipLast(1);

            if (move is MoveUserMove)
                return path.Path.Skip(1).All(x => board[x.Item1, x.Item2] == null);
            else if (move is CaptureUserMove)
                return path.Path.Skip(1).SkipLast(1).All(x => board[x.Item1, x.Item2] == null);
            else return false;
        }
    }
}