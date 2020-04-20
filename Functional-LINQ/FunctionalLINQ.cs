using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ
{
    public static class FunctionalLINQ
    {
        public static bool All<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
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
            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
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
            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(
    this IEnumerable<TSource> first, IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            var firstSet = new HashSet<TSource>(first, comparer);
            var secondSet = new HashSet<TSource>(second, comparer);

            return firstSet.Union(secondSet);
        }

        public static IEnumerable<TSource> Intersect<TSource>(
    this IEnumerable<TSource> first, IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            var firstSet = new HashSet<TSource>(first, comparer);
            var secondSet = new HashSet<TSource>(second, comparer);

            return firstSet.Intersect(secondSet);
        }

        public static IEnumerable<TSource> Except<TSource>(
    this IEnumerable<TSource> first, IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
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
            return new OrderedEnumerable<TSource>(source, new ProjectedComparer<TSource, TKey>(keySelector, comparer));
        }
    }
}
