using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ChessMoves
{
    public class ChessBoard
    {
        private const int CHESSBOARD_SIZE = 8;
        private Piece[,] board = new Piece[CHESSBOARD_SIZE, CHESSBOARD_SIZE];

        public ChessBoard()
        {
            InitializeBoard();
        }

        public void ComputeTable()
        {
            DisplayBoard();
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
            board[0, 3] = new King("d8", Player.Black);
            board[0, 4] = new Queen("e8", Player.Black);
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
            board[1, 7] = new Pawn("g7", Player.Black);
        }

        private void InitializeWhite()
        {
            board[7, 0] = new Rock("a1", Player.White);
            board[7, 1] = new Knight("b1", Player.White);
            board[7, 2] = new Bishop("c1", Player.White);
            board[7, 3] = new King("d1", Player.White);
            board[7, 4] = new Queen("e1", Player.White);
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
                                    Console.Write(" RkW ");
                                }
                                else
                                {
                                    Console.Write(" RkB ");
                                }
                                break;
                            case Knight _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Console.Write(" KnW ");
                                }
                                else
                                {
                                    Console.Write(" KnB ");
                                }
                                break;
                            case Bishop _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Console.Write(" BiW ");
                                }
                                else
                                {
                                    Console.Write(" BiB ");
                                }
                                break;
                            case King _:
                                if(board[i, j].PlayerColour == Player.White)
                                {
                                    Console.Write(" KgW ");
                                }
                                else
                                {
                                    Console.Write(" KgB ");
                                }
                                break;
                            case Queen _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Console.Write(" QuW ");
                                }
                                else
                                {
                                    Console.Write(" QuB ");
                                }
                                break;
                            case Pawn _:
                                if (board[i, j].PlayerColour == Player.White)
                                {
                                    Console.Write(" PwW ");
                                }
                                else
                                {
                                    Console.Write(" PwB ");
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (i % 2 != 0 && j % 2 != 0 || (i % 2 == 0 && j % 2 == 0))
                        {
                            Console.Write(" [ ] ");
                        }
                        else
                        {
                            Console.Write(" | | ");
                        }
                    }
                }

                Console.Write('\n');
            }

            Console.ReadLine();
        }
    }
}