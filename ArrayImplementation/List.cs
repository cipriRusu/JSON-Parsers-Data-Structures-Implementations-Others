﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayImplementation
{
    public class List<T> : IList<T>
    {
        private const int initialSize = 4;
        private T[] contained;

        public List()
        {
            contained = new T[initialSize];
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        public virtual T this[int index]
        {
            get => contained[index];
            set => contained[index] = value;
        }

        public virtual void Add(T input)
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

        public void CopyTo(T[] array, int arrayIndex)
        {
            int counter = 0;
            for (int i = arrayIndex; i < array.Length && counter < Count; i++)
            {
                array[i] = contained[counter];
                counter++;
            }
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

        public virtual void Insert(int index, T input)
        {
            EnsureCapacity();

            Array.Copy(contained, index, contained, index + 1,
               contained.Length - index - 1);

            contained[index] = input;
            Count++;
        }

        public bool Remove(T item)
        {
            int currentIndex = IndexOf(item);

            if (currentIndex == -1)
            {
                return false;
            }

            RemoveAt(currentIndex);
            return true;
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
                T value = contained[i];
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
        public static void Swap<T>(ref T i, ref T j)
        {
            T temp = i;
            i = j;
            j = temp;
        }
    }
}