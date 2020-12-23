using System;
using System.Collections.Generic;
using System.Text;

namespace Blood_Pressure_and_Weather
{
    internal class Temperature
    {
        public byte[] TemperatureValues { get; private set; }
        public int TemperatureCount { get; private set; }
        public Temperature(List<byte> temperature)
        {
            TemperatureValues = new byte[temperature.Count];
            temperature.CopyTo(TemperatureValues, 0);
        }
    }
}
