using System;
using System.Collections.Generic;
using System.Linq;

namespace Blood_Pressure_and_Weather
{
    // Класс BloodPressure описывает артериальное давление, зафиксированное при помощи тонометра.
    // Метод GetArithmeticMeanOfUpPressure() возвращает значение средего арифметического наплюдаемых 
    // значений систолического ("верхнего") артериального давления, GetArithmeticMeanOfDownPressure() - 
    // возвращает аналогичное занчение диастолического ("нижнего") давления.
    // Метод GetDispersionOfUpPressure() возвращает дисперсию значений "верхнего" давления,
    // GetDispersionOfDownPressure() - дисперсия значений "нижнего" давления.
    // GetMeanSquareDeviationOfUpPressure() - возвращает срднеквадратическое отклонение для "верхнего" давления,
    // GetMeanSquareDeviationOfDownPressure() - срднеквадратическое отклонение "нижнего" давления.
    internal class BloodPressure: Analysis
    {
        public double[] SystolicPressure { get; }
        public double[] DiastolicPressure { get; }
        public int PressureCount { get; }

        public BloodPressure(List<double> systolicPressure, List<double> diastolicPressure)
        {
            PressureCount = systolicPressure.Count;
            if (PressureCount != diastolicPressure.Count)
                throw new Exception("Количество измерений систолического и диастолического давлений не сопадают");
            SystolicPressure = new double[PressureCount];
            DiastolicPressure = new double[PressureCount];
            systolicPressure.CopyTo(SystolicPressure, 0);
            diastolicPressure.CopyTo(DiastolicPressure, 0);
        }

        public double GetArithmeticMeanOfUpPressure()
        {
            return GetArithmeticMean(SystolicPressure);
        }
        public double GetArithmeticMeanOfDownPressure()
        {
            return GetArithmeticMean(DiastolicPressure);
        }
        public double GetDispersionOfUpPressure()
        {
            return GetDispersion(SystolicPressure);
        }
        public double GetDispersionDownPressure()
        {
            return GetDispersion(DiastolicPressure);
        }
        public double GetMeanSquareDeviationOfUpPressure()
        {
            return GetMeanSquareDeviation(SystolicPressure);
        }
        public double GetMeanSquareDeviationDownPressure()
        {
            return GetMeanSquareDeviation(DiastolicPressure);
        }
        public double GetMinUpPressure()
        {
            return GetMinValue(SystolicPressure);
        }
        public double GetMinDownPressure()
        {
            return GetMinValue(DiastolicPressure);
        }
        public double GetMaxUpPressure()
        {
            return GetMaxValue(SystolicPressure);
        }
        public double GetMaxDownPressure()
        {
            return GetMaxValue(DiastolicPressure);
        }
        public double GetUpVariationRange()
        {
            return GetVariationRange(SystolicPressure);
        }
        public double GetDownVariationRange()
        {
            return GetVariationRange(DiastolicPressure);
        }
        public double GetUpVariationCoefficient()
        {
            return GetVariationCoefficient(SystolicPressure);
        }
        public double GetDownVariationCoefficient()
        {
            return GetVariationCoefficient(DiastolicPressure);
        }
    }
}
