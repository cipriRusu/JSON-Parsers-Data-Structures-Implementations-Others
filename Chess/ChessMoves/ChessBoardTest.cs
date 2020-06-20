using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChessMoves
{
    public class ChessBoardTest
    {   
        [Fact]
        public void Test1()
        {
            var test = new ChessBoard();
            test.ComputeTable();
        }
    }
}