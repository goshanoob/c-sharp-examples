using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace delegat
{
    class Point
    {
        protected int x, y;

        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        internal void SetValues(int firstInt, int nextInt)
        {
            x = firstInt;
            y = nextInt;
        }

        public override string ToString()
        {
            return $"{x}, {y}";
        }

        public static void AddPoint(Point a, Point b)
        {
            a.x += b.x;
            a.y += b.y;
        }

        public static void SubPoint(Point a, Point b)
        {
            a.x -= b.x;
            a.y -= b.y;
        }

        public void Calculate(Point p, CalcPoints del)
        {
            del(this, p);
        }
    }

    class Vector : IEnumerable
    {
        Point[] points;
        public Vector():
            this(10)
        {
           
        }
        public Vector(int N)
        {
            points = new Point[N];
            // иницализация нулями
            for(int i = 0; i < N; ++i)
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
            foreach(Point t in points)
            {
                del(t, p);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach(Point p in points)
            {
                yield return p;
            }
            
        }
    }
}
