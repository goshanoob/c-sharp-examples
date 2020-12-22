using System.Windows;

namespace Blood_Pressure_and_Weather
{
    /// <summary>
    /// Логика взаимодействия для GraphWindow.xaml
    /// </summary>
    public partial class GraphWindow : Window
    {
        internal Graph GraphData { get; set; }
        public GraphWindow()
        {
            InitializeComponent();
            GraphData = (Graph)DataContext;
        }
    }
}
