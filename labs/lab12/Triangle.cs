using System;

namespace lab12
{
    class Triangle
    {
        double[] edges;
        public Triangle(double a, double b, double c)
        {
            edges = new double[] { a, b, c };
        }

        public double CalcPerim()
        {
            return edges[0] + edges[1] + edges[2];
        }

        public double CalcPlosh()
        {
            // По формуле Герона
            double halfPerim = CalcPerim() / 2;
            return Math.Sqrt(halfPerim*(halfPerim - edges[0])*
                (halfPerim - edges[1])*(halfPerim - edges[2]));
        }
    }
}
