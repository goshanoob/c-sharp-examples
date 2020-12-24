using System;
using System.Collections.Generic;
using System.Text;

namespace Blood_Pressure_and_Weather
{
    internal class CorrelationAnalysis: Analysis
    {
        public double[] X { get; set; }
        public double[] Y { get; set; }

        public CorrelationAnalysis()
        {

        }
        public CorrelationAnalysis(double[] x, double[] y)
        {
            // Ожидаем ошибку.
            x.CopyTo(X, 0);
            y.CopyTo(Y, 0);
        }

        public double GetCorrelationCoefficient()
        {
            double sum = 0, squareSumX = 0, squareSumY = 0;
            double meanX  = GetArithmeticMean(X);
            double meanY  = GetArithmeticMean(Y);
            int lengthX = X.Length, lengthY = Y.Length;
            int selectionCount = lengthX > lengthY ? lengthY : lengthX;
            for (int i = 0; i < selectionCount; ++i)
            {
                double deviationX = X[i] - meanX;
                double deviationY = Y[i] - meanY;
                sum += deviationX * deviationY;

                squareSumX += deviationX * deviationX;
                squareSumY += deviationY * deviationY;
            }
            return sum / Math.Sqrt(squareSumX * squareSumY);
        }
    }
}
