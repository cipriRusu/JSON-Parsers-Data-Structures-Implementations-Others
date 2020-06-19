using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChessMoves
{
    public class UserInputMoves
    {
        public string[] GetUserMoves()
        {
            return new StreamReader(@"C:\Users\sysuser\Desktop\Reps\Chess\ChessMoves\Moves.txt")
                .ReadToEnd().Split("\r\n");
        }
    }
}