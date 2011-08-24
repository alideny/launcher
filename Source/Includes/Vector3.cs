using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eXLauncher
{
    public class Vector3<T>
    {
        public void Create(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }
    }
}
