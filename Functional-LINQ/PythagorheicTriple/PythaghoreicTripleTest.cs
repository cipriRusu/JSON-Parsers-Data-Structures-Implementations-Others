using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using System.Net.Http.Headers;

namespace Functional_LINQ.PythagorheicTriple
{
    public class PythaghoreicTripleTest
    {
        [Fact]
        public void PythagorheicTripleThrowsArgumentExceptionForZeroValue()
        {
            int first = 0;
            int second = 1;
            int third = 4;

            Assert.Throws<ArgumentException>(() =>
            new PythagorheicTriple().GeneratePythaghoreicTriple(first, second, third));
        }

        [Fact]
        public void PythaghoreicTripleReturnsEmptyForInvalidTriplet()
        {
            int first = 1;
            int second = 2;
            int third = 3;

            var triplet = new PythagorheicTriple();

            triplet.GeneratePythaghoreicTriple(first, second, third);

            Assert.Empty(triplet.PytagorheicTriples);
        }

        [Fact]
        public void PythagorheicTripleReturnsMultipleValuesForValidInput()
        {
            int first = 3;
            int second = 4;
            int third = 5;

            var triplet = new PythagorheicTriple();

            IEnumerable<int[]> expected = new List<int[]>
            {
                new int[]{3, 4, 5},
                new int[]{4, 3, 5},
            };

            triplet.GeneratePythaghoreicTriple(first, second, third);

            Assert.Equal(expected, triplet.PytagorheicTriples);
        }

        [Fact]
        public void PythagorheicTripleReturnsMultipleValuesForValidInputLargerValues()
        {
            int first = 12;
            int second = 35;
            int third = 37;

            var triplet = new PythagorheicTriple();

            IEnumerable<int[]> expected = new List<int[]>
            {
                new int[]{12, 35, 37},
                new int[]{35, 12, 37}
            };

            triplet.GeneratePythaghoreicTriple(first, second, third);

            Assert.Equal(expected, triplet.PytagorheicTriples);
        }

        [Fact]
        public void PythagorheicTripleReturnsMultipleValuesForValidInputVeryLargeValues()
        {
            int first = 225;
            int second = 272;
            int third = 353;

            var triplet = new PythagorheicTriple();

            IEnumerable<int[]> expected = new List<int[]>
            {
                new int[]{ 225, 272, 353},
                new int[]{ 272, 225, 353 }
            };

            triplet.GeneratePythaghoreicTriple(first, second, third);

            Assert.Equal(expected, triplet.PytagorheicTriples);
        }
    }
}
