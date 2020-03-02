using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayImplementation
{
    public class List<T> : IEnumerable<T>
    {
        private const int initialSize = 4;
        private T[] contained;

        public List()
        {
            contained = new T[initialSize];
        }

        public int Count { get; private set; } = 0;

        public T this[int index]
        {
            get => contained[index];
            set => contained[index] = value;
        }

        public void Add(T input)
        {
            EnsureCapacity();

            contained[Count] = input;
            Count++;
        }

        public bool Contains(T input)
        {
            return IndexOf(input) != -1;
        }

        public void Clear()
        {
            Count = 0;
        }

        public int IndexOf(T input)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(contained[i], input))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T input)
        {
            EnsureCapacity();
            if (index >= Count) { return; }

            Array.Copy(contained, index, contained, index + 1,
                contained.Length - index - 1);

            contained[index] = input;
            Count++;
        }

        public void Remove(T input)
        {
            int index = IndexOf(input);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= Count) { return; }

            Array.Copy(contained, index + 1, contained,
            index, contained.Length - index - 1);

            Count--;
        }

        private void EnsureCapacity()
        {
            if (Count == contained.Length)
            {
                Array.Resize(ref contained, Count * 2);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                var value = contained[i];
                if (i < Count)
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}