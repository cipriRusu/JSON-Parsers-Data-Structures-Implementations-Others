using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChessMoves
{
    public class FileInput
    {
        public string GetFileContent() => 
            new StreamReader(@"C:\Users\sysuser\Desktop\Reps\JMRepo\Chess\ChessMoves\Moves.txt").ReadToEnd().Replace("\r\n", "");
    }
}