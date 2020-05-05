using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional_LINQ.SubarraySums
{
    public class SubarraySumTest
    {
        [Fact]
        public void SubArrayThrowsArgumentNullExceptionForNullInputArray()
        {
            var subArray = new SubarraysSum();

            Assert.Throws<ArgumentNullException>(() => 
            subArray.GenerateArrays(null, 3));
        }

        [Fact]
        public void SubArrayReturnsValidOutputForInput()
        {
            var subArray = new SubarraysSum();
            var inputArray = new int[] { 1, 2, 3 };
            var inputResult = 3;

            var res = new List<IEnumerable<int>>
            {
                new int[]{1},
                new int[]{1, 2},
                new int[]{2},
                new int[]{3},
            };

            subArray.GenerateArrays(inputArray, inputResult);

            Assert.Equal(res, subArray.SubArrays);
        }

        [Fact]
        public void SubArrayReturnsValidOutputForLargeTarget()
        {
            var subArray = new SubarraysSum();
            var inputArray = new int[] { 1, 2, 3 };
            var inputResult = 7;

            var res = new List<IEnumerable<int>>
            {
                new int[] {1},
                new int[] {1, 2},
                new int[] {1, 2, 3},
                new int[] {2},
                new int[] {2, 3},
                new int[] {3},
            };

            subArray.GenerateArrays(inputArray, inputResult);

            Assert.Equal(res, subArray.SubArrays);
        }

        [Fact]
        public void SubArrayReturnsValidOutputForLongerInputRandomValues()
        {
            var subArray = new SubarraysSum();
            var inputArray = new int[] { 0, 1, 9, 4, 2, 7, 3, 5 };
            var inputResult = 9;

            var res = new List<IEnumerable<int>>
            {
                new int[]{0},
                new int[]{0, 1},
                new int[]{1},
                new int[]{9},
                new int[]{4},
                new int[]{4, 2},
                new int[]{2},
                new int[]{2, 7},
                new int[]{7},
                new int[]{3},
                new int[]{3, 5},
                new int[]{5},
            };

            subArray.GenerateArrays(inputArray, inputResult);

            Assert.Equal(res, subArray.SubArrays);
        }
    }
}
