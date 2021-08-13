using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChessMoves
{
    public class FileInput
    {
        public string GetFileContent() => 
            new StreamReader(@"C:\Users\sysuser\Desktop\JSON-Parsers-Data-Structures-Implementations-Others\Chess\DisplayChessBoard\Moves.txt").ReadToEnd().Replace("\r\n", "");
    }
}