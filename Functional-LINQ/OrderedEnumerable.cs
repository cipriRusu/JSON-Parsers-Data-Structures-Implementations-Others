using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ
{
    public class OrderedEnumerable<TElement> : IOrderedEnumerable<TElement>
    {
        IEnumerable<TElement> source;
        IComparer<TElement> currentComparer;

        public OrderedEnumerable(IEnumerable<TElement> source, IComparer<TElement> comparer)
        {
            this.source = source;
            this.currentComparer = comparer;
        }

        public IOrderedEnumerable<TElement>
            CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, 
            IComparer<TKey> comparer, bool descending)
        {
            IComparer<TElement> secondComparer = new ProjectedComparer<TElement, TKey>(keySelector, comparer);

            return new OrderedEnumerable<TElement>(source, new CombinedComparer<TElement>(currentComparer, secondComparer));
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            var buffer = source.ToList();

            for(int i = 0; i < buffer.Count - 1; i++)
            {
                for(int j = 0; j < buffer.Count - i - 1; j++)
                {
                    if(currentComparer.Compare(buffer[j], buffer[j + 1]) > 0)
                    {
                        (buffer[j + 1], buffer[j]) = (buffer[j], buffer[j + 1]);
                    }
                }
            }

            foreach(var element in buffer)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
