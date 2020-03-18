using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataStructures
{
    public class Dictionary<TKey, Tvalue> : IDictionary<TKey, Tvalue>
    {
        private int[] buckets;

        private Element[] elements;

        private int length;

        public Dictionary(int length = 0)
        {
            this.length = length;
            buckets = new int[length];
            Array.Fill(buckets, -1);
            elements = new Element[length];
            Count = 0;
        }

        public Tvalue this[TKey key]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<Tvalue> Values => throw new NotImplementedException();

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(TKey key, Tvalue value)
        {
            var sourceBucketIndex = Math.Abs(key.GetHashCode() % length);
            var sourceElementIndex = Count;

            elements[sourceElementIndex].key = key;
            elements[sourceElementIndex].value = value;
            elements[sourceElementIndex].Next = buckets[sourceBucketIndex];
            buckets[sourceBucketIndex] = sourceElementIndex;
            Count++;
        }

        public void Add(KeyValuePair<TKey, Tvalue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Fill(buckets, -1);
            Array.Clear(elements, 0, Count);
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, Tvalue> item)
        {
            for(var i = 0; i < elements.Length; i++)
            {
                if(elements[i].key.Equals(item.Key) && elements[i].value.Equals(item.Value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, Tvalue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, Tvalue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                for(int j = buckets[i]; j != -1; j = elements[j].Next)
                {
                    yield return new KeyValuePair<TKey, Tvalue>(elements[j].key, elements[j].value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, Tvalue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out Tvalue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct Element
        {
            public TKey key { get; set; }
            public int Next { get; set; }
            public Tvalue value { get; set; }
        }
    }
}
