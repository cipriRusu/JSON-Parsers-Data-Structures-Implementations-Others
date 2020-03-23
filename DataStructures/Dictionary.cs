using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    public class Dictionary<TKey, Tvalue> : IDictionary<TKey, Tvalue>
    {
        private readonly int[] buckets;

        private Element[] elements;

        private readonly int initialLength;

        private int freeIndex = -1;

        public Dictionary(int length = 1)
        {
            initialLength = length;
            buckets = new int[length];
            Array.Fill(buckets, -1);
            elements = new Element[length];
            Count = 0;
        }

        public Tvalue this[TKey key]
        {
            get
            {
                var Index = GetIndex(key);
                if (Index >= 0 && Index <= Count)
                {
                    return elements[Index].Value;
                }
                else
                {
                    throw new ArgumentException("Key not valid");
                }
            }

            set
            {
                var Index = GetIndex(key);
                if (Index >= 0 && Index <= Count)
                {
                    elements[GetIndex(key)].Value = value;
                }
                else
                {
                    throw new ArgumentException("Key not valid");
                }
            }
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
            NullKeyException(key);

            if (ContainsKey(key))
            {
                throw new ArgumentException("An element with a same key already exists");
            }

            EnsureMaxCap();

            int bucketIndex = SourceBucketIndex(key);
            int elementIndex;

            if (freeIndex != -1)
            {
                int nextFreeIndex = elements[freeIndex].Next;
                elementIndex = freeIndex;
                freeIndex = nextFreeIndex;
            }
            else
            {
                elementIndex = Count;
            }

            elements[elementIndex].Key = key;
            elements[elementIndex].Value = value;
            elements[elementIndex].Next = buckets[bucketIndex];
            buckets[bucketIndex] = elementIndex;

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
            return TryGetValue(item.Key, out _);
        }

        public bool ContainsKey(TKey key)
        {
            NullKeyException(key);

            return GetIndex(key) != -1;
        }

        public void CopyTo(KeyValuePair<TKey, Tvalue>[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < Count; i++)
            {
                array[i] = new KeyValuePair<TKey, Tvalue>(elements[i].Key, elements[i].Value);
            }
        }

        public bool ContainsValue(Tvalue value)
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = buckets[i]; j != -1; j = elements[j].Next)
                {
                    if (elements[j].Value.Equals(value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public IEnumerator<KeyValuePair<TKey, Tvalue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = buckets[i]; j != -1; j = elements[j].Next)
                {
                    yield return new KeyValuePair<TKey, Tvalue>(elements[j].Key, elements[j].Value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            NullKeyException(key);

            int bucket = SourceBucketIndex(key);
            int index = GetIndex(key, out int previousIndex);

            if (index == -1) { return false; }

            if (previousIndex != -1)
            {
                elements[previousIndex].Next = elements[index].Next;
            }
            else
            {
                buckets[bucket] = elements[index].Next;
            }

            elements[index].Next = freeIndex;
            freeIndex = index;
            Count--;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, Tvalue> item)
        {
            if (TryGetValue(item.Key, out Tvalue resValue) && item.Value.Equals(resValue))
            {
                return Remove(item.Key);
            }

            return false;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out Tvalue value)
        {
            NullKeyException(key);
            int index = GetIndex(key);

            value = default;
            if (index != -1)
            {
                value = elements[index].Value;
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static void NullKeyException(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key value is null");
            }
        }

        private void EnsureMaxCap()
        {
            if (Count == elements.Length)
            {
                Array.Resize(ref elements, Count * 2);
            }
        }

        private int GetIndex(TKey key, out int previousIndex)
        {
            previousIndex = -1;

            for (int i = buckets[SourceBucketIndex(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    return i;
                }

                previousIndex = i;
            }

            return -1;
        }

        private int GetIndex(TKey key)
        {
            for (int i = buckets[SourceBucketIndex(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        private int SourceBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % initialLength);
        }

        private struct Element
        {
            public TKey Key { get; set; }
            public int Next { get; set; }
            public Tvalue Value { get; set; }
        }
    }
}
