using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChessMoves
{
    public class UserInput
    {
        public string[] GetUserInput()
        {
            return new StreamReader(@"C:\Users\sysuser\Desktop\Reps\Chess\ChessMoves\Moves.txt")
                .ReadToEnd().Split("\r\n");
        }
    }
}