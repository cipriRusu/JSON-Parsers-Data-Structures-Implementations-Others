using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional_LINQ.PythaghoreicTriple
{
    internal class PythagoreicTriple
    {
        public PythagoreicTriple() => PythagoreicTriples = Enumerable.Empty<int[][]>();

        public IEnumerable<int[][]> PythagoreicTriples { get; private set; }
        public void GeneratePythaghoreicTriple(int first, int second, int third)
        {

        }
    }
}
