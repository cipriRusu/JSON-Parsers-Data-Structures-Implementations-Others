﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayImplementation
{
    public class IntArray
    {
        private const int initialSize = 4;
        private int[] contained;

        public IntArray()
        {
            contained = new int[initialSize];
        }

        public int Count { get; private set; } = 0;

        public int this[int index]
        {
            get { return index < Count ? contained[index] : -1; }
            set => contained[index] = value;
        }

        public virtual void Add(int input)
        {
            EnsureCapacity();

            contained[Count] = input;
            Count++;
        }

        public virtual bool Contains(int expectedElement)
        {
            return IndexOf(expectedElement) != -1;
        }

        public int IndexOf(int value)
        {
            for (int i = 0; i < contained.Length; i++)
            {
                if (contained[i] == value && Count > 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, int element)
        {
            EnsureCapacity();

            Array.Copy(contained, index, contained, index + 1,
                contained.Length - index - 1);
            contained[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
        {
            var index = IndexOf(element);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (Count > initialSize)
            {
                Array.Copy(contained, index + 1, contained,
                index, contained.Length - index - 2);
            }
            else
            {
                Array.Copy(contained, index + 1, contained, index,
                    contained.Length - index - 1);
            }

            Count--;
        }

        private void EnsureCapacity()
        {
            if (Count == contained.Length)
            {
                Array.Resize(ref contained, Count * 2);
            }
        }
    }
}