using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;

namespace Blood_Pressure_and_Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileReader fileReader = new FileReader();
        private BloodPressure pressure;
        public MainWindow()
        {
            InitializeComponent();
            

            //Presenter presenter = new Presenter(mainWindow, fileReader);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string workDirectory = Directory.GetCurrentDirectory();
            string textContent = fileReader.ReadFile(workDirectory+ "\\Артериальное давление.txt");
            if(textContent != "")
            {
                var pressures = Regex.Matches(textContent, @"\d+\/\d+");
                PressureValues.Text =  string.Join("\n", pressures);
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
    }
}
