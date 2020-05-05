using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Functional_LINQ.SubarraySums
{
    internal class SubarraysSum
    {
        public List<IEnumerable<int>> SubArrays { get; private set; }
        private int[] _inputArray;
        private int _targetResult;

        internal void GenerateArrays(int[] inputArray, int inputResult)
        {
            _inputArray = inputArray ?? throw new ArgumentNullException("Input array was null");
            _targetResult = inputResult;

            SubArrays =
                _inputArray.Select((x, y) => 
                _inputArray.Skip(y).Select((a, b) =>
                _inputArray.Skip(y).Take(b + 1))).SelectMany(x => x).
                 Where(x => x.Sum() <= _targetResult).ToList();
        }
    }
}