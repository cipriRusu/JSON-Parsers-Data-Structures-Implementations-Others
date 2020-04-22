using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ
{
    public static class LINQImplementation
    {
        public static bool All<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            AllExceptions(source, predicate);

            foreach (var element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            AnyExceptions(source, predicate);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            FirstExceptions(source, predicate);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException("Invalid Operation");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            SelectExceptions(source, selector);

            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            SelectManyExceptions(source, selector);

            foreach (var element in source)
            {
                foreach (var item in selector(element))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            WhereExceptions(source, predicate);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
    this IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            ToDictionaryExceptions(source, keySelector, elementSelector);

            var outputDictionary = new Dictionary<TKey, TElement>();

            foreach (var value in source)
            {
                outputDictionary.Add(keySelector(value), elementSelector(value));
            }

            return outputDictionary;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
    this IEnumerable<TFirst> first, IEnumerable<TSecond> second,
    Func<TFirst, TSecond, TResult> resultSelector)
        {
            ZipExceptions(first, second);

            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return resultSelector(firstEnumerator.Current, secondEnumerator.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
    this IEnumerable<TSource> source, TAccumulate seed,
    Func<TAccumulate, TSource, TAccumulate> func)
        {
            AggregateExceptions(source, seed, func);

            foreach (var element in source)
            {
                seed = func(seed, element);
            }

            return seed;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
    this IEnumerable<TOuter> outer, IEnumerable<TInner> inner,
    Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
    Func<TOuter, TInner, TResult> resultSelector)
        {
            JoinExceptions(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

            foreach (var element in outer)
            {
                foreach (var inside in inner)
                {
                    if (outerKeySelector(element).Equals(innerKeySelector(inside)))
                    {
                        yield return resultSelector(element, inside);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
    this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            DistinctExceptions(source);

            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(
    this IEnumerable<TSource> first, IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            UnionExceptions(first, second);

            var firstSet = new HashSet<TSource>(first, comparer);
            var secondSet = new HashSet<TSource>(second, comparer);

            return firstSet.Union(secondSet);
        }

        public static IEnumerable<TSource> Intersect<TSource>(
    this IEnumerable<TSource> first, IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            IntersectExceptions(first, second);

            var firstSet = new HashSet<TSource>(first, comparer);
            var secondSet = new HashSet<TSource>(second, comparer);

            return firstSet.Intersect(secondSet);
        }

        public static IEnumerable<TSource> Except<TSource>(
    this IEnumerable<TSource> first, IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            ExceptExceptions(first, second);

            var firstSet = new HashSet<TSource>(first, comparer);
            var secondSet = new HashSet<TSource>(second, comparer);

            return firstSet.Except(secondSet);
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
        IEqualityComparer<TKey> comparer)
        {
            GroupByExceptions(source, keySelector, elementSelector, resultSelector, comparer);

            var dictionary = new Dictionary<TKey, List<TElement>>(comparer);

            foreach (var element in source)
            {
                var key = keySelector(element);
                var value = elementSelector(element);

                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, new List<TElement>() { value });
                }
                else
                {
                    dictionary[key].Add(value);
                }
            }

            foreach (var element in dictionary.Keys)
            {
                yield return resultSelector(element, dictionary[element].ToList());
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            OrderByExceptions(source, keySelector);

            return new OrderedEnumerable<TSource>(source, new ProjectedComparer<TSource, TKey>(keySelector, comparer));
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            ThenByExceptions(source, keySelector);

            return source.CreateOrderedEnumerable(keySelector, comparer, true);
        }

        //Exception Methods
        private static void AllExceptions<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("Source or Predicate value equals null");
            }
        }

        private static void AnyExceptions<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("Source or Predicate value was null");
            }
        }

        private static void FirstExceptions<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("Source or Predicate value was null");
            }
        }

        private static void SelectExceptions<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("Source or Selector value equals null");
            }
        }

        private static void SelectManyExceptions<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("Source or selector is null");
            }
        }

        private static void WhereExceptions<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("Source or selector is null");
            }
        }

        private static void AggregateExceptions<TSource, TAccumulate>(IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null || seed == null || func == null)
            {
                throw new ArgumentNullException("Source, seed or Aggregate Function was null");
            }
        }

        private static void ToDictionaryExceptions<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            if (source == null || keySelector == null || elementSelector == null)
            {
                throw new ArgumentNullException("Source, Key Selector or Element selector values are null");
            }
        }

        private static void ZipExceptions<TFirst, TSecond>(IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("First or second collection was null");
            }
        }

        private static void JoinExceptions<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            if (outer == null || inner == null || outerKeySelector == null || innerKeySelector == null || resultSelector == null)
            {
                throw new ArgumentNullException("OuterCollection, InnerCollection, InnerKeySelector or ResultSelector was null");
            }
        }

        private static void DistinctExceptions<TSource>(IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source value is nulll");
            }
        }

        private static void UnionExceptions<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("First or second values are null");
            }
        }

        private static void IntersectExceptions<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("First or second values are null");
            }
        }

        private static void ExceptExceptions<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("First or second values are null");
            }
        }

        private static void GroupByExceptions<TSource, TKey, TElement, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null || keySelector == null || elementSelector == null || resultSelector == null || comparer == null)
            {
                throw new ArgumentNullException("Source or keySelector have null values");
            }
        }

        private static void OrderByExceptions<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null || keySelector == null)
            {
                throw new ArgumentNullException("Source or keySelector value is null");
            }
        }

        private static void ThenByExceptions<TSource, TKey>(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null || keySelector == null)
            {
                throw new ArgumentNullException("Source or keySelector value is null");
            }
        }
    }
}
