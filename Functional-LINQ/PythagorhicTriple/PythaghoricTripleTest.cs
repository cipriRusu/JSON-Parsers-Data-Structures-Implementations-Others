using System;
using System.Collections.Generic;
using Xunit;

namespace Functional_LINQ.PythagorheicTriple
{
    public class PythaghoricTripleTest
    {
        [Fact]
        public void PythagorhicTriplesThrowsArgumentNullExceptionForNullInput()
        {
            var triples = new PythagorhicTriple();

            Assert.Throws<ArgumentNullException>(() => triples.GetTriple(null));
        }

        [Fact]
        public void PythagorhicTriplesReturnsNoValuesForNoPresentValuesInArray()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { };

            Assert.Equal(output, triples.GetTriple(new int[] { 1, 2, 3 }));
        }

        [Fact]
        public void PythagorhicTriplesReturnsOutputForSinglePythahoricArray()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { (5, 4, 3) };

            Assert.Equal(output, triples.GetTriple(new int[] { 5, 4, 3 }));
        }

        [Fact]
        public void PythagorhicTriplesReturnsOutputForPythagoricTripleFromMultipleValues()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { (5, 4, 3) };

            Assert.Equal(output, triples.GetTriple(new int[] { 1, 2, 3, 4, 5, 6 }));
        }

        [Fact]
        public void PythagorhicTriplesReturnsOutputForMultiplePythagoricTriplesOnly()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { (17, 15, 8), (5, 4, 3) };

            Assert.Equal(output, triples.GetTriple(new int[] { 3, 4, 5, 8, 15, 17 }));
        }

        [Fact]
        public void PyhagorhicTriplesReturnsOutputForMultipleTriplesAndOtherValues()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { (17, 15, 8), (15, 12, 9), (5, 4, 3) };

            Assert.Equal(output, triples.GetTriple(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 15, 17 }));
        }

        [Fact]
        public void PythagorhicTriplesReturnsOutputForLargeTriples()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { (73, 55, 48) };

            Assert.Equal(output, triples.GetTriple(new int[] { 48, 55, 73 }));
        }

        [Fact]
        public void PythagorhicTriplesReturnsOutputForMultiplesTriplesAndUnsortedValues()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { (73, 55, 48), (5, 4, 3) };

            Assert.Equal(output, triples.GetTriple(new int[] { 48, 1, 55, 3, 73, 9, 5, 2, 9, 1, 0, 4 }));
        }

        [Fact]
        public void PythagorhicTriplesReturnsOutputForMultiplesTriplesWithSingleDoubleAndUnsortedValues()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { (73, 55, 48), (5, 4, 3), (5, 4, 3) };

            Assert.Equal(output, triples.GetTriple(new int[] { 48, 1, 55, 3, 73, 9, 5, 5, 2, 9, 1, 0, 4 }));
        }

        [Fact]
        public void PythagorhicTriplesReturnsOutputForMultiplesTriplesMultipleDoublesLargeAndSmallValues()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { (65, 63, 16), (61, 60, 11), (61, 60, 11), (5, 4, 3), (5, 4, 3) };

            Assert.Equal(output, triples.GetTriple(new int[] { 11, 60, 60, 3, 4, 5, 16, 1, 2, 63, 5, 65, 61 }));
        }
    }
}