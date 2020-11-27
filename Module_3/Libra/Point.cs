using System;

namespace Libra
{
    public abstract class Point<T> : IComparable<Point<T>> where T : IComparable<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public abstract T SquareDistance { get; }

        int IComparable<Point<T>>.CompareTo(Point<T> other)
        {
            return X.CompareTo(other.X) + Y.CompareTo(other.Y);
        }
    }
}
