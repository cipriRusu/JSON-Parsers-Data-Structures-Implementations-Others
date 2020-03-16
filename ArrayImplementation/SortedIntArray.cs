using System;

namespace DataStructures
{
    internal class SortedIntArray : IntArray
    {
        public override int this[int index]
        {
            set
            {
                if (CheckIndexAndValue(index - 1, index + 1, value))
                {
                    base[index] = value;
                }
            }
        }

        public override void Add(int value)
        {
            base.Add(value);

            for (int j = Count - 1; j > 0; j--)
            {
                if (this[j] >= this[j - 1])
                {
                    return;
                }

                Swap(j - 1, j);
            }
        }

        public override void Insert(int index, int value)
        {
            if (CheckIndexAndValue(index - 1, index, value))
            {
                base.Insert(index, value);
            }
        }

        private bool CheckIndexAndValue(int firstIndex, int secondIndex, int value)
        {
            return firstIndex >= -1 && firstIndex < Count &&
                secondIndex >= 0 && secondIndex <= Count &&
                (firstIndex < 0 || this[firstIndex] <= value) &&
                (secondIndex == Count || value <= this[secondIndex]);
        }

        private void Swap(int i, int j)
        {
            var temp = base[j];
            base[j] = base[i];
            base[i] = temp;
        }
    }
}
