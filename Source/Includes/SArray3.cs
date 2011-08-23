using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eXLauncher.Includes
{
    public class SArray3 : IEnumerable
    {
        private ArrayList contents;

        public SArray3()
        {
            contents = new ArrayList();
        }

        public void Add(String item1, String item2, String item3)
        {
            Vector3<String> vector = new Vector3<String>();
            vector.Create(item1, item2, item3);
            contents.Add(vector);
        }
        public void Remove(String value)
        {
            Vector3<String> marked = null;
            foreach (Vector3<String> vector in contents)
            {
                if (vector.X.Equals(value))
                    marked = vector;
            }

            if (marked != null)
                contents.Remove(marked);
        }

        public int Count
        {
            get
            {
                return contents.Count;
            }
        }

        public bool ContainsX(String item)
        {
            foreach (Vector3<String> vector in contents)
            {
                if (vector.X.Equals(item))
                    return true;
            }
            return false;
        }

        public Vector3<String> this[String value]
        {
            get
            {
                foreach (Vector3<String> vector in contents)
                {
                    if (vector.X.Equals(value))
                        return vector;
                }
                return null;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new Iterator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Iterator : IEnumerator
        {
            public Iterator(SArray3 _array)
            {
                array = _array;
                Monitor.Enter(array.contents.SyncRoot);
            }
            public void Reset()
            {
                current = -1;
            }

            public Vector3<String> Current
            {
                get
                {
                    return (Vector3<String>)array.contents[current];
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    return array.contents[current];
                }
            }

            public bool MoveNext()
            {
                ++current;
                if (current < array.contents.Count)
                    return true;
                else
                    return false;
            }

            public void Dispose()
            {
                Monitor.Exit(array.contents.SyncRoot);
            }

            private SArray3 array;
            private int current = -1;
        }
    }
}
