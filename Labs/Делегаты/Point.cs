using System.Collections;

namespace delegat
{
    class Point
    {
        protected int _x, _y;
        public event EventTest SetEvent;
        public Point()
        {
            _x = 0;
            _y = 0;
        }
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
        internal void SetValues(int firstInt, int nextInt)
        {
            _x = firstInt;
            _y = nextInt;
            if (SetEvent != null) SetEvent(this);
        }

        public override string ToString()
        {
            return $"{_x}, {_y}";
        }

        public static void AddPoint(Point a, Point b)
        {
            a._x += b._x;
            a._y += b._y;
        }

        public static void SubPoint(Point a, Point b)
        {
            a._x -= b._x;
            a._y -= b._y;
        }

        public void Calculate(Point p, CalcPoints del)
        {
            del(this, p);
        }
    }

    class Vector : IEnumerable
    {
        Point[] points;
        public Vector() :
            this(10)
        {

        }
        public Vector(int N)
        {
            points = new Point[N];
            // Иницализация нулями.
            for (int i = 0; i < N; ++i)
            {
                points[i] = new Point();
            }
        }
        public Vector(Point[] points)
        {
            this.points = new Point[points.Length];
            points.CopyTo(this.points, 0);
        }

        public void Calculate(Point p, VectorDelegate del)
        {
            foreach (Point t in points)
            {
                del(t, p);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Point p in points)
            {
                yield return p;
            }
        }
    }
}
