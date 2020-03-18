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
            get
            {
                foreach (var element in this)
                {
                    if (element.Key.Equals(key))
                    {
                        return element.Value;
                    }
                }

                return default;
            }

            set
            {
                for (int i = 0; i < Count; i++)
                {
                    if (elements[i].key.Equals(key))
                    {
                        elements[i].value = value;
                    }
                }
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                var resCollection = new List<TKey>();

                foreach (var element in this)
                {
                    resCollection.Add(element.Key);
                }

                return resCollection;
            }
        }

        public ICollection<Tvalue> Values
        {
            get
            {
                var valuesCollection = new List<Tvalue>();

                foreach (var element in this)
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
            for (var i = 0; i < elements.Length; i++)
            {
                if (elements[i].key.Equals(item.Key) && elements[i].value.Equals(item.Value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            foreach (var element in this)
            {
                if (element.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, Tvalue>[] array, int arrayIndex)
        {
            for(int i = arrayIndex; i < Count; i++)
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
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, Tvalue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out Tvalue value)
        {
            value = default;

            for(int i = 0; i < Count; i++)
            {
                if(elements[i].key.Equals(key))
                {
                    value = elements[i].value;
                    return true;
                }
            }

            return false;
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
