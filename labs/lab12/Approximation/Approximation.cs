﻿using System;
namespace Approximation
{
    class Approximation
    {
        public double[,] InputPoints;
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        private const float delta = 0.1f; // приращение аргумента
        public Approximation(double[,] matrix, double a = 0, double b = 0)
        {
            int inputCount = matrix.GetLength(0);
            InputPoints = new double[inputCount, 2];
            InputPoints = matrix;
            double sumYi = 0, sumXi = 0, sumLogXi = 0;
            for (int i = 0; i < inputCount; ++i)
            {
                sumXi += InputPoints[i, 0];
                sumXi += InputPoints[i, 0];
                sumYi += InputPoints[i, 1];
                sumLogXi += Math.Log(InputPoints[i, 0], 2);
            }
            C = (sumYi - (a + b) * sumXi) / sumLogXi;
            A = a;
            B = b;
        }

        public double[,] GetPoints(double x1, double x2)
        {
            int len = (int)(Math.Abs(x2 - x1) / delta);
            double [,] points = new double[len+1,2];
            for (int i = 0; i < len+1; ++i)
            {
                points[i, 0] = x1;
                points[i, 1] = A * x1 + B * x1 + C * Math.Log(x1, 2);
                x1 += delta;
            }
            return points;
        }
    }
}
