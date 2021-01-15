using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Blood_Pressure_and_Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileReader fileReader = new FileReader();
        private BloodPressure pressure;
        private Weather weather = new Weather();
        public MainWindow()
        {
            InitializeComponent();
            //Presenter presenter = new Presenter(mainWindow, fileReader);
        }

        private void openPressureFile_Click(object sender, RoutedEventArgs e)
        {
            // Загружаем данные об артериальном давлении.
            // Затем поменять на OpenFileDialog.
            string workDirectory = Directory.GetCurrentDirectory();
            string textContent = fileReader.ReadFile(workDirectory + "\\Артериальное давление.txt");
            if (textContent != "")
            {
                MatchCollection pressureValues = GetValuesContent(@"\d+\/\d+", textContent);
                PressureValues.Text = string.Join("\n", pressureValues);
                List<double> upPressure = new List<double>(), lowPressure = new List<double>();
                //string[] value = new string[2];
                foreach (Match match in pressureValues)
                {
                    // Будет ли здесь ошибка?
                    string[] value = match.Value.Split("/");
                    upPressure.Add(double.Parse(value[0]));
                    lowPressure.Add(double.Parse(value[1]));
                }
                pressure = new BloodPressure(upPressure, lowPressure);
                meanPressure.Content = $"{pressure.GetArithmeticMeanOfUpPressure()} / " +
                    $"{pressure.GetArithmeticMeanOfDownPressure()}";
                dispersionAtmospheric.Content = $"{pressure.GetDispersionOfUpPressure()} / " +
                    $"{pressure.GetDispersionDownPressure()}";
                squareDeviationAtmospheric.Content = $"{pressure.GetMeanSquareDeviationOfUpPressure()} / " +
                    $"{pressure.GetMeanSquareDeviationDownPressure()}";
                // Вычисление минимальных и максимальных значений.
                double minUpPressureValue = pressure.GetMinUpPressure();
                double minDownPressureValue = pressure.GetMinDownPressure();
                double maxUpPressureValue = pressure.GetMaxUpPressure();
                double maxDownPressureValue = pressure.GetMaxDownPressure();
                minPressureAtmospheric.Content = $"{minUpPressureValue} / " +
                    $"{minDownPressureValue}";
                maxPressureAtmospheric.Content = $"{maxUpPressureValue} / " +
                    $"{maxDownPressureValue}";
                variationRangeAtmospheric.Content = $"{pressure.GetUpVariationRange()} / " +
                    $"{pressure.GetDownVariationRange()}";
                variationCoefficientAtmospheric.Content = $"{pressure.GetUpVariationCoefficient()} / " +
                    $"{pressure.GetDownVariationCoefficient()} (%)";

                // Делаем доступными построение графика давления и корреляционный анализ.
                showGraphic.IsEnabled = true;
                makeAnalysis.IsEnabled = true;
            }
        }

        private MatchCollection GetValuesContent(string pattern, string text)
            => Regex.Matches(text, pattern);

        private void showGraphic_Click(object sender, RoutedEventArgs e)
        {
            GraphWindow graphWindow = new GraphWindow();
            graphWindow.Show();
            graphWindow.GraphData.DrawGraphs("Графики артериального давления",
                pressure.SystolicPressure, pressure.DiastolicPressure);

            //graphWindow.GraphData.DrawGraphsXY(weather.TemperatureValues, weather.AtmospherePressure);
        }

        private void openTemperatureFile_Click(object sender, RoutedEventArgs e)
        {
            // Загружаем данные о темературе.
            string workDirectory = Directory.GetCurrentDirectory();
            string textContent = fileReader.ReadFile(workDirectory + "\\Температура.txt");
            if (textContent != "")
            {
                MatchCollection temperatureValues = GetValuesContent(@"\s-?\d+\r\n", textContent);
                double[] temperature = new double[temperatureValues.Count];
                int i = 0;
                foreach (Match match in temperatureValues)
                {
                    temperature[i++] = double.Parse(match.Value);
                }
                weather.TemperatureValues = temperature;
                meanPressure.Content = weather.GetArithmeticMean(temperature);
            }
        }

        private void openAtmosphericFile_Click(object sender, RoutedEventArgs e)
        {
            // Загружаем данные об атмосферном давлении.
            string workDirectory = Directory.GetCurrentDirectory();
            string textContent = fileReader.ReadFile(workDirectory + "\\Атмосферное давление.txt");
            if (textContent != "")
            {
                // Вынести в общую функцию для атмосферного давления и температуры.
                MatchCollection atmosphericValues = GetValuesContent(@"\s-?\d+\r\n", textContent);
                double[] atmosphere = new double[atmosphericValues.Count];
                int i = 0;
                foreach (Match match in atmosphericValues)
                {
                    atmosphere[i++] = double.Parse(match.Value);
                }
                weather.AtmospherePressure = atmosphere;
                meanPressure.Content = weather.GetArithmeticMean(atmosphere);
            }
        }

        private void makeAnalysis_Click(object sender, RoutedEventArgs e)
        {
            // Выполняем корреляционный анализ.
            CorrelationAnalysis correlation = new CorrelationAnalysis();
            correlation.X = pressure.SystolicPressure;
            correlation.Y = pressure.DiastolicPressure;
            correlationCoefficientAtmospheric.Content = correlation.GetCorrelationCoefficient();
        }
    }
}
