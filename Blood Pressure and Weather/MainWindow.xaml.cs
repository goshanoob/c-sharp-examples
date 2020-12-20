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
        MainWindow mainWindow;
        FileReader fileReader = new FileReader();
        public MainWindow()
        {
            InitializeComponent();
            

            //Presenter presenter = new Presenter(mainWindow, fileReader);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string workDirectory = Directory.GetCurrentDirectory();
            string pressures = fileReader.ReadFile(workDirectory+ "\\Артериальное давление.txt");
            if(pressures != "")
            {
                var values = Regex.Matches(pressures, @"\d+\/\d+");
                PressureValues.Text =  string.Join("\n", values);

            }

        }
    }
}
