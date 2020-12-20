using System;
using System.Collections.Generic;

namespace Blood_Pressure_and_Weather
{
    // Метод GetArithmeticMeanOfUpPressure() возвращает значение средего арифметического наплюдаемых 
    // значений систолического ("верхнего") артериального давления, GetArithmeticMeanOfDownPressure() - 
    // возвращает аналогичное занчение диастолического ("нижнего") давления.
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
    }
}
