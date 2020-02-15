using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayImplementation
{
    internal class SortedIntArray : IntArray
    {
        public override void Add(int value)
        {
            base.Add(value);
            Sort();
        }

        public override void Insert(int index, int element)
        {
            base.Insert(index, element);
            Sort();
        }

        private void Sort()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                for (int j = 0; j < this.Count - i - 1; j++)
                {
                    if (this[j] > this[j + 1])
                    {
                        var temp = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = temp;
                    }
                }
            }
        }
    }
}