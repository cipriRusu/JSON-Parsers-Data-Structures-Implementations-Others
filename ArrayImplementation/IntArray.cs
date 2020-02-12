using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayImplementation
{
    public class IntArray
    {
        private const int initialSize = 4;
        private int[] contained;
        private int count = 0;

        public IntArray()
        { contained = new int[initialSize]; }

        public void Add(int input)
        {
            EnsureCapacity();

            contained[count] = input;
            count++;
        }

        public int Count()
        { return count; }

        public int Element(int index)
        {
            return count > index ? contained[index] : -1;
        }

        public void SetElement(int index, int newElement)
        {
            contained[index] = newElement;
        }

        public bool Contains(int expectedElement)
        {
            return IndexOf(expectedElement) != -1;
        }

        public int IndexOf(int value)
        {
            for (int i = 0; i < contained.Length; i++)
            {
                if (contained[i] == value && count > 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            EnsureCapacity();

            Array.Copy(contained, index, contained, index + 1, 
                contained.Length - index - 1);
            contained[index] = element;
            count++;
        }

        public void Clear()
        {
            count = 0;
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
            Array.Copy(contained, index + 1, contained, 
                index, contained.Length - index - 2);
            count--;
        }

        private void EnsureCapacity()
        {
            if (count == contained.Length)
            {
                Array.Resize(ref contained, count * 2);
            }
        }
    }
}