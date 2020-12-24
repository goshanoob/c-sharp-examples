using System;
using System.Collections.Generic;
using System.Text;

namespace Blood_Pressure_and_Weather
{
    internal class Weather: CorrelationAnalysis
    {
        public double[] TemperatureValues { get; set; }
        public double[] AtmospherePressure { get; set; }
        public Weather()
        {

        }
    }
}
