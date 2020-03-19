using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    public class Dictionary<TKey, Tvalue> : IDictionary<TKey, Tvalue>
    {
        private readonly int[] buckets;

        private readonly Element[] elements;

        private readonly int initialLength;

        private int freeIndex = -1;

        public Dictionary(int length = 0)
        {
            initialLength = length;
            buckets = new int[length];
            Array.Fill(buckets, -1);
            elements = new Element[length];
            Count = 0;
        }

        public Tvalue this[TKey key]
        {
            get => elements[GetIndex(key, out int prev)].value;

            set => elements[GetIndex(key, out int prev)].value = value;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keysCollection = new List<TKey>();

                foreach (KeyValuePair<TKey, Tvalue> element in this)
                {
                    keysCollection.Add(element.Key);
                }

                return keysCollection;
            }
        }

        public ICollection<Tvalue> Values
        {
            get
            {
                List<Tvalue> valuesCollection = new List<Tvalue>();

                foreach (KeyValuePair<TKey, Tvalue> element in this)
                {
                    valuesCollection.Add(element.Value);
                }

                return valuesCollection;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(TKey key, Tvalue value)
        {
            int sourceBucketIndex = SourceBucketIndex(key);
            int sourceElementIndex = Count;

            elements[sourceElementIndex].key = key;
            elements[sourceElementIndex].value = value;
            elements[sourceElementIndex].Next = buckets[sourceBucketIndex];
            buckets[sourceBucketIndex] = sourceElementIndex;
            Count++;
        }

        public void Add(KeyValuePair<TKey, Tvalue> item) => Add(item.Key, item.Value);

        public void Clear()
        {
            Array.Fill(buckets, -1);
            Array.Clear(elements, 0, Count);
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, Tvalue> item)
        {
            return TryGetValue(item.Key, out Tvalue value);
        }

        public bool ContainsKey(TKey key)
        {
            return GetIndex(key, out int prev) != -1;
        }

        public void CopyTo(KeyValuePair<TKey, Tvalue>[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < Count; i++)
            {
                array[i] = new KeyValuePair<TKey, Tvalue>(elements[i].key, elements[i].value);
            }
        }

        public IEnumerator<KeyValuePair<TKey, Tvalue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = buckets[i]; j != -1; j = elements[j].Next)
                {
                    yield return new KeyValuePair<TKey, Tvalue>(elements[j].key, elements[j].value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            //Check if Key is present
            if (!TryGetValue(key, out Tvalue value)) return false;

            var bucketIndex = SourceBucketIndex(key);

            //Check if key is first in bucket
            if (GetIndex(key, out int previousIndex) != -1 && previousIndex == -1)
            {
                elements[buckets[bucketIndex]] = new Element();
                buckets[bucketIndex]--;
                Count--;
            }

            return true;
        }

        public bool Remove(KeyValuePair<TKey, Tvalue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out Tvalue value)
        {
            value = default;

            if (GetIndex(key, out int previous) != -1)
            {
                value = elements[GetIndex(key, out int prev)].value;
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetIndex(TKey key, out int previousIndex)
        {
            previousIndex = -1;

            for (int i = buckets[SourceBucketIndex(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].key.Equals(key))
                {
                    return i;
                }

                previousIndex = i;
            }

            return -1;
        }

        private int GetPreviousIndex(TKey key)
        {
            var previousIndex = -1;

            for (int i = buckets[SourceBucketIndex(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].key.Equals(key))
                {
                    return previousIndex;
                }

                previousIndex = i;
            }

            return previousIndex;
        }

        private int SourceBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % initialLength);
        }

        private struct Element
        {
            public TKey key { get; set; }
            public int Next { get; set; }
            public Tvalue value { get; set; }
        }
    }
}
