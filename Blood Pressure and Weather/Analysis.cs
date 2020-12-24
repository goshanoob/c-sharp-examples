using System;
using System.Collections.Generic;
using System.Linq;

namespace Blood_Pressure_and_Weather
{
    // Абстактный класс Analysis для выполнения статистического анализа над выборками данных.
    // Метод GetArithmeticMean() возвращает средее арифметическое наблюдаемых значений;
    // Метод GetDispersion() возвращает дисперсию выборки;
    // GetMeanSquareDeviation() возвращает срднеквадратическое отклонение.
    // Методы GetMinValue() и GetMinValue() возвращают наименьшее и наибольшее значения выборки.
    // GetVariationRange() - определяет размах вариации.
    // GetVariationCoefficient() - коэффициент вариации.
    internal abstract class Analysis
    {
        public double GetArithmeticMean(double[] selection)
        {
            double sum = 0;
            foreach (double value in selection)
            {
                sum += value;
            }
            return sum / selection.Length;
        }
        public double GetDispersion(double[] selection)
        {
            double sum = 0;
            double arithmeticMean = GetArithmeticMean(selection);
            foreach (double value in selection)
            {
                sum += Math.Pow(value - arithmeticMean, 2);
            }
            return sum / selection.Length;
        }
        public double GetMeanSquareDeviation(double[] selection)
        {
            return Math.Sqrt(GetDispersion(selection));
        }
        public double GetMinValue(double[] selection)
        {
            return selection.Min();
        }
        public double GetMaxValue(double[] selection)
        {
            return selection.Max();
        }
        public double GetVariationRange(double[] selection)
        {
            return GetMaxValue(selection) - GetMinValue(selection);
        }
        public double GetVariationCoefficient(double[] selection)
        {
            return GetMeanSquareDeviation(selection) / GetArithmeticMean(selection) * 100;
        }
    }
}
