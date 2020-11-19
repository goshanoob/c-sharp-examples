using System;

namespace lab12
{
    class Triangle
    {
        double[] _edges;
        public Triangle(double a, double b, double c)
        {
            _edges = new double[] { a, b, c };
        }

        public double CalcPerim()
        {
            return _edges[0] + _edges[1] + _edges[2];
        }

        public double CalcPlosh()
        {
            // По формуле Герона
            double halfPerim = CalcPerim() / 2; // полупериметр
            return Math.Sqrt(halfPerim*(halfPerim - _edges[0])*
                (halfPerim - _edges[1])*(halfPerim - _edges[2]));
        }
    }
}
