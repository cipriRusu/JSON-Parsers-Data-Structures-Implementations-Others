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

            var output = new (int a, int b, int c)[] {};

            Assert.Equal(output, triples.GetTriple(new int[] { 1, 2, 3 }));
        }

        [Fact]
        public void PythagorhicTriplesReturnsOutputForSinglePythahoricArray()
        {
            var triples = new PythagorhicTriple();

            var output = new (int a, int b, int c)[] { };

            Assert.Equal(output, triples.GetTriple(new int[] { 3, 4, 5 }));
        }
    }
}