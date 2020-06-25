using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ChessMoves
{
    public class ChessBoard
    {
        private const int CHESSBOARD_SIZE = 8;
        private Piece[,] board = new Piece[CHESSBOARD_SIZE, CHESSBOARD_SIZE];
        public Piece this[int i, int j] => board[i, j];

        public ChessBoard()
        {
            InitializeBoard();
        }

        public void GetMoves(List<UserMove> moves)
        {
            foreach (var move in moves)
            {
                Move(move);
            }

            DisplayBoard();
        }

        private void Move(UserMove move)
        {
            for (int i = 0; i <= CHESSBOARD_SIZE - 1; i++)
            {
                for (int j = 0; j <= CHESSBOARD_SIZE - 1; j++)
                {
                    if (PieceRequrements(move, i, j))
                    {
                        if (RankConstraint(move, i, j))
                        {
                            board = board[i, j].Move(move, board);
                        }
                        else if (FileConstraint(move, i, j))
                        {
                            board = board[i, j].Move(move, board);
                        }
                        else if (FileAndRankConstraint(move, i, j))
                        {
                            board = board[i, j].Move(move, board);
                        }
                        else if (move.SourceFile == '\0' && move.SourceRank == '\0')
                        {
                            board = board[i, j].Move(move, board);
                        }
                    }
                }
            }
        }

        private bool FileConstraint(UserMove move, int i, int j) =>
            move.SourceFile != '\0' && move.SourceRank == '\0' && move.SourceFile == board[i, j].File;

        private bool RankConstraint(UserMove move, int i, int j) =>
            move.SourceRank != '\0' && move.SourceFile == '\0' && move.SourceRank == board[i, j].Rank;

        private bool FileAndRankConstraint(UserMove move, int i, int j) =>
            move.SourceRank != '\0' &&
            move.SourceFile != '\0' &&
            move.SourceRank == board[i, j].Rank &&
            move.SourceFile == board[i, j].File;

        private bool PieceRequrements(UserMove move, int i, int j)
        {
            return
                board[i, j] != null &&
                board[i, j].PlayerColour == move.PlayerColor &&
                board[i, j].PieceType == move.PieceType;
        }

        private void InitializeBoard()
        {
            InitializeWhite();
            InitializeBlack();
        }

        private void InitializeBlack()
        {
            board[0, 0] = new Rock("a8", Player.Black);
            board[0, 1] = new Knight("b8", Player.Black);
            board[0, 2] = new Bishop("c8", Player.Black);
            board[0, 3] = new Queen("d8", Player.Black);
            board[0, 4] = new King("e8", Player.Black);
            board[0, 5] = new Bishop("f8", Player.Black);
            board[0, 6] = new Knight("g8", Player.Black);
            board[0, 7] = new Rock("h8", Player.Black);

            board[1, 0] = new Pawn("a7", Player.Black);
            board[1, 1] = new Pawn("b7", Player.Black);
            board[1, 2] = new Pawn("c7", Player.Black);
            board[1, 3] = new Pawn("d7", Player.Black);
            board[1, 4] = new Pawn("e7", Player.Black);
            board[1, 5] = new Pawn("f7", Player.Black);
            board[1, 6] = new Pawn("g7", Player.Black);
            board[1, 7] = new Pawn("h7", Player.Black);
        }

        private void InitializeWhite()
        {
            board[7, 0] = new Rock("a1", Player.White);
            board[7, 1] = new Knight("b1", Player.White);
            board[7, 2] = new Bishop("c1", Player.White);
            board[7, 3] = new Queen("d1", Player.White);
            board[7, 4] = new King("e1", Player.White);
            board[7, 5] = new Bishop("f1", Player.White);
            board[7, 6] = new Knight("g1", Player.White);
            board[7, 7] = new Rock("h1", Player.White);

            board[6, 0] = new Pawn("a2", Player.White);
            board[6, 1] = new Pawn("b2", Player.White);
            board[6, 2] = new Pawn("c2", Player.White);
            board[6, 3] = new Pawn("d2", Player.White);
            board[6, 4] = new Pawn("e2", Player.White);
            board[6, 5] = new Pawn("f2", Player.White);
            board[6, 6] = new Pawn("g2", Player.White);
            board[6, 7] = new Pawn("h2", Player.White);
        }

        private void DisplayBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != null)
                    {
                        switch (board[i, j])
                        {
                            case Rock _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Debug.Write(" RkW ");
                                }
                                else
                                {
                                    Debug.Write(" RkB ");
                                }
                                break;
                            case Knight _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Debug.Write(" KnW ");
                                }
                                else
                                {
                                    Debug.Write(" KnB ");
                                }
                                break;
                            case Bishop _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Debug.Write(" BiW ");
                                }
                                else
                                {
                                    Debug.Write(" BiB ");
                                }
                                break;
                            case King _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Debug.Write(" KgW ");
                                }
                                else
                                {
                                    Debug.Write(" KgB ");
                                }
                                break;
                            case Queen _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Debug.Write(" QuW ");
                                }
                                else
                                {
                                    Debug.Write(" QuB ");
                                }
                                break;
                            case Pawn _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Debug.Write(" PwW ");
                                }
                                else
                                {
                                    Debug.Write(" PwB ");
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (i % 2 != 0 && j % 2 != 0 || (i % 2 == 0 && j % 2 == 0))
                        {
                            Debug.Write(" [ ] ");
                        }
                        else
                        {
                            Debug.Write(" | | ");
                        }
                    }
                }

                Debug.Write('\n');
            }
        }
    }
}