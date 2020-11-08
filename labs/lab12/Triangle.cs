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
            double h = 0.44 * edges[0] * edges[1]; // вычисление высота (либо считать угол по теор. кос.)
            return 0.5 * edges[2] * h;
        }
    }
}
