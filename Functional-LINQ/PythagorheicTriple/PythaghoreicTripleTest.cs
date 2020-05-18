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
            var triple = new PythagorheicTriple();

            Assert.Throws<ArgumentNullException>(() => triple.ComputeTriples(null));
        }

        [Fact]
        public void PythagorheicTripleThrowsArgumentExceptionForSingleNegativeValue()
        {
            var triple = new PythagorheicTriple();
            var input = new int[] { 1, -2, 3 };

            Assert.Throws<ArgumentException>(() => triple.ComputeTriples(input));
        }

        [Fact]
        public void OutputReturnsNothingForNoPresentPythaghoreanValues()
        {
            var triple = new PythagorheicTriple();
            var input = new int[] { 1, 2, 3 };

            triple.ComputeTriples(input);

            Assert.Empty(triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForOnlySingleSmallPythaghoreanValue()
        {
            var triple = new PythagorheicTriple();
            var input = new int[] { 3, 4, 5 };
            var expected = new Dictionary<int, IEnumerable<int>[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new IEnumerable<int>[] { new[] { 3, 4 }, new[] { 4, 3 } });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForMultiplesValuesSingleSmallPythaghoreanValue()
        {
            var triple = new PythagorheicTriple();
            var input = new int[] { 1, 2, 3, 4, 5, 6 };
            var expected = new Dictionary<int, IEnumerable<int>[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new IEnumerable<int>[] { new[] { 3, 4 }, new[] { 4, 3 } });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForOnlyMultiplePythaghoreanValues()
        {
            var triple = new PythagorheicTriple();
            var input = new int[] { 3, 4, 5, 5, 12, 13 };
            var expected = new Dictionary<int, IEnumerable<int>[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new IEnumerable<int>[] { new[] { 3, 4 }, new[] { 4, 3 } });
            expected.Add(13, new IEnumerable<int>[] { new[] { 5, 12 }, new[] { 12, 5 } });

            Assert.Equal(expected, triple.PytagorheicTriples);
        }

        [Fact]
        public void OutputReturnsValidValuesForMultipleValuesAndMultiplePythaghoreanValues()
        {
            var triple = new PythagorheicTriple();
            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            var expected = new Dictionary<int, IEnumerable<int>[]>();
            triple.ComputeTriples(input);
            expected.Add(5, new IEnumerable<int>[] { new[] { 3, 4 }, new[] { 4, 3 } });
            expected.Add(13, new IEnumerable<int>[] { new[] { 5, 12 }, new[] { 12, 5 } });
        }

        [Fact]
        public void OutputReturnsValidValuesForLargeUnsortedInputAndLargeValues()
        {
            var triple = new PythagorheicTriple();
            var input = new int[] { 19, 119, 20, 21, 22, 23, 24, 27, 169, 25, 28, 120, 29, 40, 45, 50, 51, 26, 53 };
            var expected = new Dictionary<int, IEnumerable<int>[]>();
            triple.ComputeTriples(input);
            expected.Add(29, new IEnumerable<int>[] { new[] { 20, 21 }, new[] { 21, 20 } });
            expected.Add(53, new IEnumerable<int>[] { new[] { 28, 45 }, new[] { 45, 28 } });
            expected.Add(169, new IEnumerable<int>[] { new[] { 119, 120 }, new[] { 120, 119 } });
        }
    }
}