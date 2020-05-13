using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Functional_LINQ.PythagorheicTriple
{
    public class PythaghoreicTripleTest
    {
        [Fact]
        public void PythaghoreicTripleReturnsEmptyForInvalidTriplet()
        {
            int first = 1;
            int second = 2;
            int third = 3;

            var triplet = new PythagorheicTriple();

            triplet.GeneratePythaghoreicTriple(first, second, third);

            Assert.Empty(triplet.PythagoreicTriples);
        }

        [Fact]
        public void PythagoreicTripleReturnsSingleTripletForValidValue()
        {
            int first = 2;
            int second = 4;
            int third = 6;

            var triplet = new PythagorheicTriple();

            triplet.GeneratePythaghoreicTriple(first, second, third);

            var expected = new int[][]
            {
                new int[]{2, 4, 6 },
            };

            Assert.Contains(expected, triplet.PythagoreicTriples);
        }
    }
}
