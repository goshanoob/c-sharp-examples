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
    class BloodPressure
    {
        public byte[] SystolicPressure { get; }
        public byte[] DiastolicPressure { get; }
        public int PressureCount { get; }

        public BloodPressure(List<byte> systolicPressure, List<byte> diastolicPressure)
        {
            PressureCount = systolicPressure.Count;
            SystolicPressure = new byte[PressureCount];
            DiastolicPressure = new byte[PressureCount];
            int k = 0;
            foreach (byte pressure in systolicPressure)
            {
                SystolicPressure[k] = pressure;
                DiastolicPressure[k] = diastolicPressure[k++];
            }
        }

        public float GetArithmeticMeanOfUpPressure()
        {
            return GetArithmeticMean(SystolicPressure);
        }
        public float GetArithmeticMeanOfDownPressure()
        {
            return GetArithmeticMean(DiastolicPressure);
        }
        public float GetDispersionOfUpPressure()
        {
            return GetDispersion(SystolicPressure);
        }
        public float GetDispersionDownPressure()
        {
            return GetDispersion(DiastolicPressure);
        }
        public float GetMeanSquareDeviationOfUpPressure()
        {
            return GetMeanSquareDeviation(SystolicPressure);
        }
        public float GetMeanSquareDeviationDownPressure()
        {
            return GetMeanSquareDeviation(DiastolicPressure);
        }
        public byte GetMinUpPressure()
        {
            return GetMinPressure(SystolicPressure);
        }
        public byte GetMinDownPressure()
        {
            return GetMinPressure(DiastolicPressure);
        }
        public byte GetMaxUpPressure()
        {
            return GetMaxPressure(SystolicPressure);
        }
        public byte GetMaxDownPressure()
        {
            return GetMaxPressure(DiastolicPressure);
        }
        public byte GetUpVariationRange()
        {
            return GetVariationRange(SystolicPressure);
        }
        public byte GetDownVariationRange()
        {
            return GetVariationRange(DiastolicPressure);
        }
        public float GetUpVariationCoefficient()
        {
            return GetVariationCoefficient(SystolicPressure);
        }
        public float GetDownVariationCoefficient()
        {
            return GetVariationCoefficient(DiastolicPressure);
        }

        private float GetArithmeticMean(byte[] pressure)
        {
            long sum = 0;
            foreach (byte value in pressure)
            {
                sum += value;
            }
            return 1.0f * sum / PressureCount;
        }

        private float GetDispersion(byte[] pressure)
        {
            float sum = 0;
            float arithmeticMean = GetArithmeticMean(pressure);
            foreach (byte value in pressure)
            {
                sum += (float)Math.Pow((value - arithmeticMean), 2);
            }
            return sum / PressureCount;
        }
        private float GetMeanSquareDeviation(byte[] pressure)
        {
            return (float)Math.Sqrt(GetDispersion(pressure));
        }
        private byte GetMinPressure(byte[] pressure)
        {
            return pressure.Min();
        }
        private byte GetMaxPressure(byte[] pressure)
        {
            return pressure.Max();
        }
        private byte GetVariationRange(byte[] pressure)
        {
            return (byte)(GetMaxPressure(pressure) - GetMinPressure(pressure));
        }
        private float GetVariationCoefficient(byte[] pressure)
        {
            return GetMeanSquareDeviation(pressure) / GetArithmeticMean(pressure) * 100;
        }
    }
}
