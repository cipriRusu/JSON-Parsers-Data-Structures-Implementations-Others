using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class ReadOnlyList<T> : IList<T>
    {
        private readonly List<T> list = new List<T>();

        public ReadOnlyList(List<T> input) => list = input;

        public T this[int index] => list[index];

        T IList<T>.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => list.Count;

        public bool IsReadOnly => true;

        public void Add(T input)    
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(T input)
        {
            return list.Contains(input);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}