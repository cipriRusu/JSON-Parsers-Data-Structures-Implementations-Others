using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayImplementation
{
    internal class SortedList<T> : List<T> where T : IComparable<T>
    {
        public override T this[int index]
        {
            set
            {
                if (CheckIndexAndValue(index - 1, index + 1, value))
                {
                    base[index] = value;
                }
            }
        }

        public override void Add(T input)
        {
            base.Add(input);

            for (int j = Count - 1; j > 0; j--)
            { 
                if (this[j].CompareTo(this[j - 1]) >= 0)
                {
                    return;
                }

                Swap(j - 1, j);
            }
        }

        public override void Insert(int index, T value)
        {
            if (CheckIndexAndValue(index - 1, index, value))
            {
                base.Insert(index, value);
            }
        }

        private void Swap(int i, int j)
        {
            var temp = base[j];
            base[j] = base[i];
            base[i] = temp;
        }

        private bool CheckIndexAndValue(int firstIndex, int secondIndex, T value)
        {
            return firstIndex >= -1 && firstIndex < Count &&
               secondIndex >= 0 && secondIndex <= Count &&
               (firstIndex < 0 || (this[firstIndex].CompareTo(value) <= 0)) &&
               (secondIndex == Count || (value.CompareTo(this[secondIndex]) <= 0));
        }
    }
}
