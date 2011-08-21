using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace eXLauncher
{
    public class Array3<T> : IEnumerable<T>
    {
        public void Add(T item1, T item2, T item3)
        {
            if (contents == null)
                contents = new ArrayList();
            Vector3<T> vector = new Vector3<T>();
            vector.X = item1;
            vector.Y = item2;
            vector.Z = item3;
            contents.Add(vector);
        }

        public void Remove(T item)
        {
            int marked = -1;
            for (int i = 0; i < contents.Count; i++)
            {
                var vector = contents[i] as Vector3<T>;
                if (vector != null)
                {
                    if (object.Equals(vector.X, item))
                        marked = i;
                }
            }
            if (marked != -1)
                contents.RemoveAt(marked);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Iterator : IEnumerator<T>
        {
            public Iterator(Array3<T> array3)
            {
                Monitor.Enter(array.contents.SyncRoot);
                array = array3;
            }

            public void Reset()
            {
                current = -1;
            }

            public bool MoveNext()
            {
                ++current;
                if (current < array.contents.Count)
                    return true;
                else
                    return false;
            }

            public T Current
            {
                get
                {
                    return (T)array.contents[current];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return array.contents[current];
                }
            }

            public void Dispose()
            {
                Monitor.Exit(array.contents.SyncRoot);
            }
            private int current;
            private Array3<T> array;
        }

        private ArrayList contents;
    }
}
