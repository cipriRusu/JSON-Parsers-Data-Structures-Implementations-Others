using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Functional_LINQ
{
    public partial class FunctionalLINQTest
    {
        [Fact]
        public void AllMethodReturnsTrueForAllElementsValidForPredicate()
        {
            var collection = new int[] { 1, 3, 4, 9, 7, 2 };
            Assert.True(FunctionalLINQ.All(collection, x => x < 10));
        }

        [Fact]
        public void AllMethodReturnsFalseForSingleElementNotValidInPredicate()
        {
            var collection = new int[] { 1, 3, 4, 9, 7, 12 };
            Assert.False(FunctionalLINQ.All(collection, x => x < 10));
        }

        [Fact]
        public void AddMethodThrowsArgumentNullExceptionForNullSource()
        {
            string[] collection = null;
            Assert.Throws<ArgumentNullException>(() => collection.All(x => x.Contains("something")));
        }

        [Fact]
        public void AddMethodThrowsArgumentNullExceptionForNullPredicate()
        {
            string[] collection = { "aa", "bb" };
            Assert.Throws<ArgumentNullException>(() => collection.All(null));
        }

        [Fact]
        public void AnyMethodReturnTrueForSingleElementValidForPredicate()
        {
            var collection = new int[] { 2, 1, 9, 4, 7 };
            Assert.True(FunctionalLINQ.Any(collection, x => x == 9));
        }

        [Fact]
        public void AnyMethodReturnFalseForNoElementValidForPredicate()
        {
            var collection = new int[] { 2, 1, 0, 9, 4 };
            Assert.False(FunctionalLINQ.Any(collection, x => x == 12));
        }

        [Fact]
        public void AnyMethordThrowsArgumentNullExceptionForNullSource()
        {
            string[] collection = null;
            Assert.Throws<ArgumentNullException>(() => collection.Any(x => x == "something"));
        }

        [Fact]
        public void AnyMethordThrowsArgumentNullExceptionForNullPredicate()
        {
            string[] collection = new string[] { "aa", "bb", "cc" };
            Assert.Throws<ArgumentNullException>(() => collection.Any(null));
        }

        [Fact]
        public void FirstReturnsTrueForFirstElementThatSatisfiesCondition()
        {
            var collection = new int[] { 2, 1, 0, 5, 3, 8 };
            Assert.Equal(5, FunctionalLINQ.First(collection, x => x == 5));
        }

        [Fact]
        public void FirstThrowsInvalidOperationExceptionForAbsentValue()
        {
            var collection = new int[] { 2, 1, 0, 4, 9 };
            Assert.Throws<InvalidOperationException>(() => FunctionalLINQ.First(collection, x => x == 3));
        }

        [Fact]
        public void FirstThrowsArgumentNullExceptionForNullSource()
        {
            string[] collection = null;
            Assert.Throws<ArgumentNullException>(() => collection.First(x => x == "something"));
        }

        [Fact]
        public void FirstThrowsArgumentNullExcpetionForNullPredicate()
        {
            string[] collection = new string[] { "aa", "bb", "cc" };
            Assert.Throws<ArgumentNullException>(() => collection.First(null));
        }

        [Fact]
        public void SelectReturnValidOutputForInputedParameters()
        {
            var collection = new int[] { 2, 1, 0, 9, 4 };
            var expected = new int[] { 4, 2, 0, 18, 8 };
            Assert.Equal(expected, FunctionalLINQ.Select(collection, x => x * 2));
        }

        [Fact]
        public void SelectThrowsArgumentNullExceptionForNullSource()
        {
            string[] collection = null;
            var current = collection.Select(x => x == "something").GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => current.MoveNext());
        }

        [Fact]
        public void SelectThrowsArgumentNullExceptionForNullPredicate()
        {
            string[] collection = new string[] { "aa" };
            var current = collection.Select<string, string>(null).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => current.MoveNext());
        }

        [Fact]
        public void SelectManyReturnsValidOutputForInputedParameters()
        {
            var collection = new int[][] { new int[] { 1, 3 }, new int[] { 4 }, new int[] { 7, 8, 9 } };
            var expected = new int[] { 1, 3, 4, 7, 8, 9 };
            Assert.Equal(expected, FunctionalLINQ.SelectMany(collection, x => x));
        }
        
        [Fact]
        public void SelectManyThrowsArgumentNullExceptionForNullSource()
        {
            string[] collection = null;
            var current = collection.SelectMany(x => x).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => current.MoveNext());
        }

        [Fact]
        public void SelectManyThrowsArgumentNullExceptionForNullPredicate()
        {
            string[] collection = new string[] { "a", "b", "c" };
            var current = collection.SelectMany<string, string>(null).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => current.MoveNext());

        }

        [Fact]
        public void WhereReturnsValidOutputForInputedParameters()
        {
            var collection = new int[] { 1, 3, 0, 9, 4, 7 };
            var expected = new int[] { 9, 7 };
            Assert.Equal(expected, FunctionalLINQ.Where(collection, x => x > 5));
        }

        [Fact]
        public void WhereThrowsArgumentNullExceptionForNullSource()
        {
            string[] collection = null;
            var current = collection.Where(x => x == "something").GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => current.MoveNext());
        }

        [Fact]
        public void WhereThrowsArgumentNullExceptionForNullPredicate()
        {
            string[] collection = new string[] { "a", "b" };
            var current = collection.Where(null).GetEnumerator();
            Assert.Throws<ArgumentNullException>(() => current.MoveNext());
        }

        [Fact]
        public void ToDictionaryReturnsValidOuputForInputedParameters()
        {
            var collection = new int[] { 0, 1, 2, 3, 4, 5 };
            var expected = new Dictionary<int, string>();

            expected.Add(0, "test");
            expected.Add(1, "test");
            expected.Add(2, "test");
            expected.Add(3, "test");
            expected.Add(4, "test");
            expected.Add(5, "test");

            Assert.Equal(expected, FunctionalLINQ.ToDictionary(collection, x => x, x => "test"));
        }

        [Fact]
        public void ToDictionaryThrowsArgumentNullExceptionForNullSource()
        {
            string[] firstCollection = null;
            Assert.Throws<ArgumentNullException>(()=> firstCollection.ToDictionary(x => x, x => x).GetEnumerator());
        }

        [Fact]
        public void ToDictionaryThrowsArgumentNullExceptionForNullFirstPredicate()
        {
            string[] firstCollection = new string[] { "a", "b", "c" };
            Assert.Throws<ArgumentNullException>(()=> firstCollection.ToDictionary<string, string, string>(null, x => x).
            GetEnumerator().MoveNext());
        }

        [Fact]
        public void ToDictionaryThrowsArgumentNullExceptionForNullSecondPredicate()
        {
            string[] firstCollection = new string[] { "a", "b", "c" };
            Assert.Throws<ArgumentNullException>(() => firstCollection.ToDictionary<string, string, string>(x => x, null).
            GetEnumerator().MoveNext());
        }

        [Fact]
        public void ZipReturnsValidOutputForInputParameters()
        {
            var firstCollection = new int[] { 0, 1, 8, 9, 4 };
            var secondCollection = new string[] { "zero", "one", "eight", "nine", "four" };

            var expected = new string[]
            {
                "0 - zero",
                "1 - one",
                "8 - eight",
                "9 - nine",
                "4 - four"
            };

            Assert.Equal(expected, FunctionalLINQ.Zip(firstCollection, secondCollection,
            (firstCollection, secondCollection) => firstCollection + " - " + secondCollection));
        }

        [Fact]
        public void ZipReturnValidOuputForInputParametersTupledOuput()
        {
            var firstCollection = new int[] { 0, 1, 4 };
            var secondCollection = new string[] { "zero", "one", "four" };
            var expected = new (int, string)[]
            {
                (0, "zero"),
                (1, "one"),
                (4, "four")
            };

            Assert.Equal(expected, FunctionalLINQ.Zip(firstCollection, secondCollection,
            (firstCollection, secondCollection) => (firstCollection, secondCollection)));
        }

        [Fact]
        public void ZipReturnValidOuputForFirstShorterCollection()
        {

            var firstCollection = new int[] { 1, 2, 3 };
            var secondCollection = new string[] { "first", "second", "third", "fourth", "fifth" };

            var expected = new string[]
            {
                "1 - first",
                "2 - second",
                "3 - third"
            };

            Assert.Equal(expected, FunctionalLINQ.Zip(firstCollection, secondCollection,
            (firstCollection, secondCollection) => firstCollection + " - " + secondCollection));
        }

        [Fact]
        public void ZipReturnValidOuputForSecondShorterCollection()
        {

            var firstCollection = new int[] { 1, 2, 3, 4, 5 };
            var secondCollection = new string[] { "first", "second", "third" };

            var expected = new string[]
            {
                "1 - first",
                "2 - second",
                "3 - third"
            };

            Assert.Equal(expected, FunctionalLINQ.Zip(firstCollection, secondCollection,
            (firstCollection, secondCollection) => firstCollection + " - " + secondCollection));
        }

        [Fact]
        public void AggregateReturnsValidOutputForValidInput()
        {
            var collection = new int[] { 1, 2, 3, 4, 5 };

            int expected = 15;

            Assert.Equal(expected,
            FunctionalLINQ.Aggregate(collection, 0, (x, y) => x + y));
        }

        [Fact]
        public void JoinReturnsValidOuputForValidInput()
        {
            var first = new int[] { 1, 2, 3 };
            var sec = new int[] { 2, 3, 4 };

            var expected = new int[] { 2, 3 };

            Assert.Equal(expected,
            FunctionalLINQ.Join(first, sec, first => first, sec => sec, (first, sec) => first));
        }

        [Fact]
        public void DistinctReturnsValidOuputForValidInput()
        {
            var collection = new int[] { 1, 2, 1, 7, 9, 1, 3 };
            var expected = new int[] { 1, 2, 7, 9, 3 };

            var result = collection.Distinct(new EqualityComparer<int>());

            Assert.Equal(expected, result);
        }

        [Fact]
        public void UnionReturnsValidOutputForValidInput()
        {
            var firstCollection = new int[] { 2, 1, 9, 0 };
            var secCollecton = new int[] { 2, 4, 3, 9, 1 };
            IEnumerable expected = new int[] { 2, 1, 9, 0, 4, 3 };

            IEnumerable result = firstCollection.Union(secCollecton, new EqualityComparer<int>());

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IntersectReturnsValidOutputForValidInput()
        {
            var firstCollection = new int[] { 1, 2, 0, 4 };
            var secCollection = new int[] { 3, 2, 0, 9 };

            IEnumerable expected = new int[] { 2, 0 };

            IEnumerable result = firstCollection.Intersect(secCollection, new EqualityComparer<int>());

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ExceptReturnsValidOutputForValidInput()
        {
            var firstCollection = new int[] { 1, 2, 0, 4 };
            var secCollection = new int[] { 3, 2, 0, 9 };

            IEnumerable expected = new int[] { 1, 4 };
            IEnumerable result = firstCollection.Except(secCollection, new EqualityComparer<int>());

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GroupByReturnsValidOutputForValidInput()
        {
            var current = new Dictionary<string, int>();

            current.Add("first", 1);
            current.Add("second", 2);
            current.Add("third", 1);
            current.Add("fourth", 2);

            var actual = current.GroupBy(x => x.Value, y => y.Key,
                (key, value) => new Dictionary<int, List<string>>()
                {
                    [key] = new List<string>(value)
                },
                new EqualityComparer<int>());

            var actualData = DataExtractionHelper.GroupByExtractData(actual);

            var expected = new Dictionary<int, List<string>>()
            {
                [1] = new List<string>() { "first", "third" },
                [2] = new List<string>() { "second", "fourth" }
            };

            Assert.Equal(expected, actualData);
        }

        [Fact]
        public void OrderByReturnsValidOuutputForValidInput()
        {
            var current = new Dictionary<string, int>();
            current.Add("Ana", 20);
            current.Add("Mihai", 10);
            current.Add("Barbu", 30);
            current.Add("Zicu", 15);

            var actual = current.OrderBy(x => x.Value, new IntegerComparer());

            var actualData = DataExtractionHelper.OrderByExtractData(actual);

            var expected = new Dictionary<string, int>()
            {
                ["Mihai"] = 10,
                ["Zicu"] = 15,
                ["Ana"] = 20,
                ["Barbu"] = 30,
            };

            Assert.Equal(expected, actualData);
        }

        [Fact]
        public void ThenByReturnsValidOutputForValidInput()
        {
            var current = new string[] { "bob", "coco", "ana", "gicu", "zalmoxis" };

            var actual = current.OrderBy(x => x.Length, new IntegerComparer()).ThenBy(x => x, StringComparer.OrdinalIgnoreCase);

            var actualData = DataExtractionHelper.ThenByExtractData(actual);

            var expected = new string[]
            {
                "ana",
                "bob",
                "coco",
                "gicu",
                "zalmoxis"
            };

            Assert.Equal(expected, actualData);
        }
    }
}
