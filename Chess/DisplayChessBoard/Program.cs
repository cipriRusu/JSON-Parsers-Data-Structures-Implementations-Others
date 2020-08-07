using ChessMoves;
using System;
using System.Collections.Generic;

namespace DisplayChessBoard
{
    class Program
    {
        public static void Main()
        {
            var currentGame = new Game();
            var fileContent = new FileInput().GetFileContent();
            currentGame.Input(fileContent);
            new Display(currentGame).DisplayStateInConsole();
        }
    }
}
