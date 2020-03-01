using System.Collections;

namespace ArrayImplementation
{
    public class ObjectEnumerator : IEnumerator
    {
        private ObjectArray objectArray;

        int position = -1;

        public ObjectEnumerator(ObjectArray objectarray)
        {
            objectArray = objectarray;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            position++;
            return (position < objectArray.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return objectArray[position]; }
        }
    }
}
