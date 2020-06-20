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
        private Player playerTurn;

        public ChessBoard()
        {
            InitializeBoard();
        }

        public void ComputeTable()
        {
            var allMoves = new AllMoves(new UserInput().GetUserInput()).Moves;

            foreach(var move in allMoves)
            {
                Move(move);
            }

            DisplayBoard();
        }

        private void Move(UserMove userMove)
        {
            for (int i = 0; i <= CHESSBOARD_SIZE - 1; i++)
            {
                for (int j = 0; j <= CHESSBOARD_SIZE - 1; j++)
                {
                    if (board[i, j] != null &&
                       board[i, j].PlayerColour == userMove.PlayerColor &&
                       board[i, j].PieceType == userMove.PieceType &&
                       IdentifyValidPath(userMove, i, j).Count() > 0)
                    {
                        var path = IdentifyValidPath(userMove, i, j).SelectMany(x => x);

                        if(path.Skip(1).All(x => board[x.Item1, x.Item2] == null))
                        {
                            board[i, j].UpdatePosition(path.Last());
                            board[path.Last().Item1, path.Last().Item2] = board[i, j];
                            board[i, j] = null;
                        }
                    }
                }
            }
        }

        private IEnumerable<IEnumerable<(int, int)>> IdentifyValidPath(UserMove userMove, int i, int j) => 
            board[i, j].GetLegalMoves().Where(x => x.Last() == userMove.MoveIndex);

        private void InitializeBoard()
        {
            InitializeWhite();
            InitializeBlack();
            InitializePawns();
        }

        private void InitializePawns()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                board[1, i] = new Pawn((1, i), Player.Black) { };
                board[6, i] = new Pawn((6, i), Player.White) { };
            }
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
            Console.WriteLine();
            Console.Write($"Player to move: {playerTurn}");
            Console.ReadLine();
        }
    }
}