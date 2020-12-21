using OxyPlot;
using OxyPlot.Series;
using System.Collections.Generic;

namespace Blood_Pressure_and_Weather
{
    class Graph
    {
        public PlotModel CurveGraph { get; set; }
        public Graph()
        {
            /* FileReader fileReader = new FileReader();
             string workDirectory = Directory.GetCurrentDirectory();
             string textContent = fileReader.ReadFile(workDirectory + "\\Артериальное давление.txt");
             if (textContent != "")
             {
                 var pressures = Regex.Matches(textContent, @"\d+\/\d+");
                 List<byte> upPressure = new List<byte>(), lowPressure = new List<byte>();
                 string[] value = new string[2];
                 foreach (Match match in pressures)
                 {
                     value = match.Value.Split("/");
                     upPressure.Add(byte.Parse(value[0]));
                     lowPressure.Add(byte.Parse(value[1]));
                 }

                 grath = new PlotModel { Title = "График артериального давления" };
                 LineSeries series = new LineSeries { Title = "Систолическое", MarkerType = MarkerType.Square };
                 LineSeries series2 = new LineSeries { Title = "Диастолическое", MarkerType = MarkerType.Square };
                 int x = 0, k = 0;
                 foreach (byte val  in upPressure)
                 {
                     series.Points.Add(new DataPoint(x, val));
                     series2.Points.Add(new DataPoint(x, lowPressure[k++]));
                     x += 10;
                 }
                 grath.Series.Add(series);
                 grath.Series.Add(series2);

                 grath.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
             }
            */

            /*

            Title = "Example 2";
            Points = new List<DataPoint>
                              {
                                  new DataPoint(0, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };*/

            CurveGraph = new PlotModel { Title = "График артериального давления" };
            CurveGraph.Series.Add(GetData());
            FunctionSeries GetData()
            {
                FunctionSeries serie = new FunctionSeries();
                int x = 0;
                DataPoint point;
                //foreach (var value in pressure.SystolicPressure)
                for(int i = 0; i < 10; i++)
                {
                    point = new DataPoint(x, i);
                    serie.Points.Add(point);
                    x += 20;
                }
                return serie;
            }
        }
    }
}