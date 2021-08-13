using ChessMoves;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisplayChessBoard
{
    public class Display
    {
        private Game game;
        public Display(Game gameInput) => game = gameInput;

        public void DisplayStateInConsole()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (game[(i, j)] != null)
                    {
                        switch (game[(i, j)])
                        {
                            case Rock _:
                                if (game[(i, j)].Player == Player.White)
                                {
                                    Console.Write(" RkW ");
                                }
                                else
                                {
                                    Console.Write(" RkB ");
                                }
                                break;
                            case Knight _:
                                if (game[(i, j)].Player == Player.White)
                                {
                                    Console.Write(" KnW ");
                                }
                                else
                                {
                                    Console.Write(" KnB ");
                                }
                                break;
                            case Bishop _:
                                if (game[(i, j)].Player == Player.White)
                                {
                                    Console.Write(" BiW ");
                                }
                                else
                                {
                                    Console.Write(" BiB ");
                                }
                                break;
                            case King _:
                                if (game[(i, j)].Player == Player.White)
                                {
                                    Console.Write(" KgW ");
                                }
                                else
                                {
                                    Console.Write(" KgB ");
                                }
                                break;
                            case Queen _:
                                if (game[(i, j)].Player == Player.White)
                                {
                                    Console.Write(" QuW ");
                                }
                                else
                                {
                                    Console.Write(" QuB ");
                                }
                                break;
                            case Pawn _:
                                if (game[(i, j)].Player == Player.White)
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

            if (game.IsCheckMate == true)
            {
                Console.WriteLine($"{game.TurnToMove} King in CheckMate");
            }
            else if (game.IsCheck == true)
            {
                Console.WriteLine($"{game.TurnToMove} King in Check");
            }
            else
            {
                Console.WriteLine($"Turn to move : {game.TurnToMove}");
            }
        }
    }
}
