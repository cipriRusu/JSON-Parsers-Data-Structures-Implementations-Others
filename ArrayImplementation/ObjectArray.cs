using System;
using System.Collections;

namespace ArrayImplementation
{
    internal class ObjectArray : IEnumerable
    {
        private object[] _objects;
        private const int initialSize = 4;
        private object[] contained;

        public ObjectArray()
        {
            contained = new object[initialSize];
        }

        public ObjectArray(Object[] objectsArray)
        {
            _objects = new Object[objectsArray.Length];

            for(int i = 0; i < objectsArray.Length; i++)
            {
                _objects[i] = objectsArray[i];
            }
        }

        public int Count { get; private set; } = 0;

        public object this[int index]
        {
            get { return contained[index]; }
            set => contained[index] = value;
        }

        public void Add(object input)
        {
            EnsureCapacity();

            contained[Count] = input;
            Count++;
        }

        public bool Contains(object input)
        {
            return IndexOf(input) != -1;
        }

        public void Clear()
        {
            Count = 0;
        }

        public int IndexOf(object input)
        {
            for (int i = 0; i < contained.Length; i++)
            {
                if (object.Equals(contained[i], input))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, object input)
        {
            EnsureCapacity();
            if (index < Count)
            {
                Array.Copy(contained, index, contained, index + 1,
                    contained.Length - index - 1);

                contained[index] = input;
                Count++;
            }
        }

        public void Remove(object input)
        {
            var index = IndexOf(input);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < Count)
            {
                Array.Copy(contained, index + 1, contained,
                index, contained.Length - index - 1);

                Count--;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new ObjectEnumerator(_objects);
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