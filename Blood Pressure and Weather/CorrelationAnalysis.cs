using System;
using System.Collections.Generic;
using System.Text;

namespace Blood_Pressure_and_Weather
{
    internal class CorrelationAnalysis
    {
        public List<double> X { get; set; }
        public List<double> Y { get; set; }

        public CorrelationAnalysis()
        {
            X = new List<double>();
            Y = new List<double>();
        }

        public double GetCorrelationCoefficient()
        {
            double sum = 0, squareSumX = 0, squareSumY = 0;
            double meanX  = GetArithmeticMean(X);
            double meanY  = GetArithmeticMean(Y);
            for (int i = 0; i < X.Count; ++i)
            {
                double deviationX = X[i] - meanX;
                double deviationY = Y[i] - meanY;
                sum += deviationX * deviationY;

                squareSumX += deviationX * deviationX;
                squareSumY += deviationY * deviationY;
            }
            return sum / Math.Sqrt(squareSumX * squareSumY);
        }

        private double GetArithmeticMean(List<double> a)
        {
            double sum = 0;
            foreach (byte value in a)
            {
                sum += value;
            }
            return sum / a.Count;
        }
    }
}
