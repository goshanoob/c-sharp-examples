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
        private List<double> temperature;
        private List<double> atmospheric;
        public MainWindow()
        {
            InitializeComponent();
            //Presenter presenter = new Presenter(mainWindow, fileReader);
        }

        private void openPressureFile_Click(object sender, RoutedEventArgs e)
        {
            // Загружаем данные об артериальном давлении.
            string workDirectory = Directory.GetCurrentDirectory();
            string textContent = fileReader.ReadFile(workDirectory + "\\Артериальное давление.txt");
            if (textContent != "")
            {
                var pressures = Regex.Matches(textContent, @"\d+\/\d+");
                PressureValues.Text = string.Join("\n", pressures);
                List<byte> upPressure = new List<byte>(), lowPressure = new List<byte>();
                string[] value = new string[2];
                foreach (Match match in pressures)
                {
                    value = match.Value.Split("/");
                    upPressure.Add(byte.Parse(value[0]));
                    lowPressure.Add(byte.Parse(value[1]));
                }
                pressure = new BloodPressure(upPressure, lowPressure);
                meanPressure.Content = $"{pressure.GetArithmeticMeanOfUpPressure()} / " +
                    $"{pressure.GetArithmeticMeanOfDownPressure()}";
                dispersion.Content = $"{pressure.GetDispersionOfUpPressure()} / " +
                    $"{pressure.GetDispersionDownPressure()}";
                squareDeviation.Content = $"{pressure.GetMeanSquareDeviationOfUpPressure()} / " +
                    $"{pressure.GetMeanSquareDeviationDownPressure()}";
                // Вычисление минимальных и максимальных значений.
                byte minUpPressureValue = pressure.GetMinUpPressure();
                byte minDownPressureValue = pressure.GetMinDownPressure();
                byte maxUpPressureValue = pressure.GetMaxUpPressure();
                byte maxDownPressureValue = pressure.GetMaxDownPressure();
                minPressure.Content = $"{minUpPressureValue} / " +
                    $"{minDownPressureValue}";
                maxPressure.Content = $"{maxUpPressureValue} / " +
                    $"{maxDownPressureValue}";
                variationRange.Content = $"{pressure.GetUpVariationRange()} / " +
                    $"{pressure.GetDownVariationRange()}";
                variationCoefficient.Content = $"{pressure.GetUpVariationCoefficient()} / " +
                    $"{pressure.GetDownVariationCoefficient()} (%)";

                // Делаем доступным построение графика давления.
                showGraphic.IsEnabled = true;
            }
        }

        private void showGraphic_Click(object sender, RoutedEventArgs e)
        {
            GraphWindow graphWindow = new GraphWindow();
            graphWindow.Show();
            graphWindow.GraphData.Points = pressure.SystolicPressure.Select(i => (double)i).ToList();
            graphWindow.GraphData.RefreshGraph();

            graphWindow.GraphData.DrawGraphs("Графики артериального давления",
                pressure.SystolicPressure.Select(i => (double)i).ToArray(),
                pressure.DiastolicPressure.Select(i => (double)i).ToArray());
        }

        private void openTemperatureFile_Click(object sender, RoutedEventArgs e)
        {
            // Загружаем данные о темературе.
            string workDirectory = Directory.GetCurrentDirectory();
            string textContent = fileReader.ReadFile(workDirectory + "\\Артериальное давление.txt");

            textContent = fileReader.ReadFile(workDirectory + "\\Температура.txt");
            if (textContent != "")
            {
                //temperature = new List<double>();
                string[] temperatureValues = textContent.Split("\r\n");
                temperature = temperatureValues.Select(i => double.Parse(i)).ToList();
            }
        }

        private void openAtmosphericFile_Click(object sender, RoutedEventArgs e)
        {
            // Загружаем данные об атмосферном давлении.
            string workDirectory = Directory.GetCurrentDirectory();
            string textContent = fileReader.ReadFile(workDirectory + "\\Атмосферное давление.txt");
            if (textContent != "")
            {
                string[] atmosphericValues = textContent.Split("\r\n");
                atmospheric = atmosphericValues.Select(i => double.Parse(i)).ToList();
            }
        }

        private void makeAnalysis_Click(object sender, RoutedEventArgs e)
        {
            // Выполняем корреляционный анализ.
            CorrelationAnalysis correlation = new CorrelationAnalysis();
            correlation.X = pressure.SystolicPressure.Select(i => (double)i).ToList();
            correlation.Y = temperature;
            correlationCoefficient.Content = correlation.GetCorrelationCoefficient();
        }
    }
}
