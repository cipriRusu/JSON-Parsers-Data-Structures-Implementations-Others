﻿using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ChessMoves
{
    public abstract class UserMove
    {
        public PieceType PieceType { get; private set; }
        public (int, int) MoveIndex { get; private set; }
        public string NotationIndex { get; private set; }
        public char SourceFile { get; private set; }
        public char SourceRank { get; private set; }
        public Player PlayerColor { get; private set; }
        public bool IsCheck { get; private set; }
        public bool IsCheckMate { get; private set; }

        public UserMove(string input, Player playerTurn)
        {
            if(input.EndsWith('+'))
            {
                input = input[0..^1];
                IsCheck = true;
            }
            else if(input.EndsWith('#'))
            {
                input = input[0..^1];
                IsCheckMate = true;
            }

            NotationIndex = input;
            PlayerColor = playerTurn;
            UserMoveInputExceptions(input);
            GetPieceType(input);
            GetSource(string.Concat(input.TakeLast(2)));
            GetOrigin(input[0..^2]);
        }

        private void GetSource(string source)
        {
            if (source.All(x => IsRank(x) || IsFile(x)))
            {
                MoveIndex = new Index().GetMatrixIndex(source);
            }
        }

        private void GetOrigin(IEnumerable<char> origin)
        {
            foreach (var element in origin)
            {
                if (IsRank(element)) { SourceRank = element; }
                if (IsFile(element)) { SourceFile = element; }
            }
        }
        private bool IsRank(char c) => "12345678".Contains(c);
        private bool IsFile(char c) => "abcdefgh".Contains(c);
        private void GetPieceType(string input)
        {
            switch (input.First())
            {
                case 'K':
                    PieceType = PieceType.King;
                    break;
                case 'Q':
                    PieceType = PieceType.Queen;
                    break;
                case 'R':
                    PieceType = PieceType.Rock;
                    break;
                case 'B':
                    PieceType = PieceType.Bishop;
                    break;
                case 'N':
                    PieceType = PieceType.Knight;
                    break;
                default:
                    PieceType = PieceType.Pawn;
                    break;
            }
        }
        private static void UserMoveInputExceptions(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new UserMoveException("Current user input is empty!");
            }
        }

        internal void CheckVerification(ChessBoard board)
        {
            if(new CurrentPlayerStatus(PlayerColor, board).IsChecked)
            {
                throw new UserMoveException(this, "Move invalid");
            }
            if (IsCheck && !new CurrentPlayerStatus(Piece.Opponent(PlayerColor), board).IsChecked)
            {
                throw new UserMoveException(this, "Check move invalid");
            }
        }
    }
}
