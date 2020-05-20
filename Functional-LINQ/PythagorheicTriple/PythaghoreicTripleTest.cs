using System;
using System.Collections.Generic;
using Xunit;

namespace Functional_LINQ.PythagorheicTriple
{
    public class PythaghoreicTripleTest
    {
        [Fact]
        public void PythagorheicTripleThrowsArgumentExceptionForNullInput()
        {
            PythagorheicTriple triple = new PythagorheicTriple();

            Assert.Throws<ArgumentNullException>(() => triple.ComputeTriples(null));
        }

        [Fact]
        public void PythagorheicTripleSkipsNegativeValuesInInput()
        {
            PythagorheicTriple triple = new PythagorheicTriple();
            int[] input = new int[] { 1, -2, -3, 3, 4, 5 };

            Dictionary<int, int[]> expected = new Dictionary<int, int[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new int[] { 4, 3 });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsNothingForNoPresentPythaghoreanValues()
        {
            PythagorheicTriple triple = new PythagorheicTriple();
            int[] input = new int[] { 1, 2, 3 };

            triple.ComputeTriples(input);

            Assert.Empty(triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForOnlySingleSmallPythaghoreanValue()
        {
            PythagorheicTriple triple = new PythagorheicTriple();
            int[] input = new int[] { 3, 4, 5 };
            Dictionary<int, int[]> expected = new Dictionary<int, int[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new int[] { 4, 3 });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForMultiplesValuesSingleSmallPythaghoreanValue()
        {
            PythagorheicTriple triple = new PythagorheicTriple();
            int[] input = new int[] { 1, 2, 3, 4, 5, 6 };
            Dictionary<int, int[]> expected = new Dictionary<int, int[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new int[] { 4, 3 });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForOnlyMultiplePythaghoreanValues()
        {
            PythagorheicTriple triple = new PythagorheicTriple();
            int[] input = new int[] { 3, 4, 5, 5, 12, 13 };
            Dictionary<int, int[]> expected = new Dictionary<int, int[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new int[] { 4, 3 });
            expected.Add(13, new int[] { 12, 5 });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForMultipleValuesAndMultiplePythaghoreanValues()
        {
            PythagorheicTriple triple = new PythagorheicTriple();
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            Dictionary<int, int[]> expected = new Dictionary<int, int[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new int[] { 4, 3 });
            expected.Add(10, new int[] { 8, 6 });
            expected.Add(13, new int[] { 12, 5 });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForLargeUnsortedInputAndLargeValues()
        {
            PythagorheicTriple triple = new PythagorheicTriple();
            int[] input = new int[] { 19, 119, 20, 21, 22, 23, 24, 27, 169, 25, 28, 120, 29, 40, 45, 50, 51, 26, 53 };
            Dictionary<int, int[]> expected = new Dictionary<int, int[]>();
            triple.ComputeTriples(input);
            expected.Add(29, new int[] { 21, 20 });
            expected.Add(53, new int[] { 45, 28 });
            expected.Add(51, new int[] { 45, 24 });
            expected.Add(169, new int[] { 120, 119 });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }
    }
}