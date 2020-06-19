using System;
using System.Collections.Generic;
using System.Linq;

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
            var moves = new UserInputMoves().GetUserMoves();
            var computeMoves = new ConvertUserMoves().ConvertMoves(moves);

            foreach (var move in computeMoves)
            {
                Move(move);
                playerTurn = move.PlayerColor;
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
            var rock = new CustomIndex().GetMatrixIndex("a8");
            board[rock.Item1, rock.Item2] = new Rock((rock.Item1, rock.Item2), Player.Black) { };
            var knight = new CustomIndex().GetMatrixIndex("b8");
            board[knight.Item1, knight.Item2] = new Knight((knight.Item1, knight.Item2), Player.Black) { };
            var bishop = new CustomIndex().GetMatrixIndex("c8");
            board[bishop.Item1, bishop.Item2] = new Bishop((bishop.Item1, bishop.Item2), Player.Black) { };
            var king = new CustomIndex().GetMatrixIndex("d8");
            board[king.Item1, king.Item2] = new King((king.Item1, king.Item2), Player.Black) { };
            var queen = new CustomIndex().GetMatrixIndex("e8");
            board[queen.Item1, queen.Item2] = new Queen((queen.Item1, queen.Item2), Player.Black) { };
            var secondBishop = new CustomIndex().GetMatrixIndex("f8");
            board[secondBishop.Item1, secondBishop.Item2] = new Bishop((secondBishop.Item1, secondBishop.Item2), Player.Black) { };
            var secondKnight = new CustomIndex().GetMatrixIndex("g8");
            board[secondKnight.Item1, secondKnight.Item2] = new Knight((secondKnight.Item1, secondKnight.Item2), Player.Black) { };
            var secondRock = new CustomIndex().GetMatrixIndex("h8");
            board[secondRock.Item1, secondRock.Item2] = new Rock((secondRock.Item1, secondRock.Item2), Player.Black) { };
        }

        private void InitializeWhite()
        {
            var rock = new CustomIndex().GetMatrixIndex("a1");
            board[rock.Item1, rock.Item2] = new Rock((rock.Item1, rock.Item2), Player.White) { };
            var knight = new CustomIndex().GetMatrixIndex("b1");
            board[knight.Item1, knight.Item2] = new Knight((knight.Item1, knight.Item2), Player.White) { };
            var bishop = new CustomIndex().GetMatrixIndex("c1");
            board[bishop.Item1, bishop.Item2] = new Bishop((bishop.Item1, bishop.Item2), Player.White) { };
            var king = new CustomIndex().GetMatrixIndex("d1");
            board[king.Item1, king.Item2] = new King((king.Item1, king.Item2), Player.White) { };
            var queen = new CustomIndex().GetMatrixIndex("e1");
            board[queen.Item1, queen.Item2] = new Queen((queen.Item1, queen.Item2), Player.White) { };
            var secondBishop = new CustomIndex().GetMatrixIndex("f1");
            board[secondBishop.Item1, secondBishop.Item2] = new Bishop((secondBishop.Item1, secondBishop.Item2), Player.White) { };
            var secondKnight = new CustomIndex().GetMatrixIndex("g1");
            board[secondKnight.Item1, secondKnight.Item2] = new Knight((secondKnight.Item1, secondKnight.Item2), Player.White) { };
            var secondRock = new CustomIndex().GetMatrixIndex("h1");
            board[secondRock.Item1, secondRock.Item2] = new Rock((secondRock.Item1, secondRock.Item2), Player.White) { };
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