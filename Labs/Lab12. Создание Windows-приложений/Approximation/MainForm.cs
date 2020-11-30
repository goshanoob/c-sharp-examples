using System;
using System.Drawing;
using System.Windows.Forms;

namespace Approximation
{
    public interface IUserInterface
    {
        event EventHandler OpenFile;
        string FilePath { get; set; }
        string TextContent { get; set; }
    }
    public partial class MainForm : Form, IUserInterface
    {
        public event EventHandler OpenFile;
        public string FilePath { get; set; }
        public string TextContent { get; set; }

        private const float a = 0, b = 0;

        Approximation approximation;
        public MainForm()
        {
            InitializeComponent();
        }

        private void coefficientsMenu_Click(object sender, EventArgs e)
        {
            if (FilePath == null)
            {
                DialogResult result = MessageBox.Show("Вы не выбрали файл, содержащий входные данные. Задать их по умолнчанию?", "Ошибка", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    approximation = new Approximation(new double[,] { { 1, 1 } ,{ 2, 4 }, { 3, 9 },
                        { 4, 16 },{ 5, 25 } }, a, b);
                }
                else
                {
                    return;
                }
            }
            MessageBox.Show($"Коэффициенты a = {approximation.A},\n b = {approximation.B}" +
                $",\n c = {approximation.C}");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void showMenu_Click(object sender, EventArgs e)
        {
            // Здесь требуется исправить обозначения, перенести оси правее и освободить ресурсы.
            Graphics plot = CreateGraphics();
            // Оси системы координат.
            Pen pen = new Pen(Color.Black);
            float h = Height - 20, w = Width - 50,
                beginH = 50, beginW = 10;
            plot.DrawLine(pen, 10, 400, 880, 400); // горизонтальная ось
            plot.DrawLine(pen, 50, 30, 50, 470); // вертикальная ось
            // Отрезки осей
            for (int i = 0; i < h / 20; ++i)
            {
                plot.DrawLine(pen, 45, 40 + i * 20, 55, 40 + i * 20);
                plot.DrawLine(pen, 10 + i * 20, 395, 10 + i * 20, 405);
            }
            pen.Color = Color.Red;
            double[,] points = approximation.GetPoints(0.1, 20);
            for (int i = 0; i < points.GetLength(0) - 1; ++i)
            {
                plot.DrawLine(pen, (float)points[i, 0] * 20 + 50, 400 - (float)points[i, 1] * 20,
                    (float)points[i + 1, 0] * 20 + 50, 400 - (float)points[i + 1, 1] * 20);
            }
            Brush brush = new SolidBrush(Color.Green);
            for (int i = 0; i < approximation.InputPoints.GetLength(0) - 1; ++i)
            {
                plot.FillEllipse(brush, (float)approximation.InputPoints[i, 0] * 20 - 2.5f + 50,
                    400 - (float)approximation.InputPoints[i, 1] * 20 - 2.5f, 5, 5);
            }
            plot.Dispose();
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = dialog.FileName;
                OpenFile?.Invoke(this, EventArgs.Empty);
                approximation = new Approximation(ConvertToPoints(), a, b);
            }
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            Form about = new About();
            about.Show();
        }

        private double[,] ConvertToPoints()
        {
            string[] points = TextContent.Split('\n');
            double[,] M = new double[points.Length, 2];
            int k = 0;
            foreach (string i in points)
            {
                string[] coord = i.Split('\t');
                M[k, 0] = double.Parse(coord[0]);
                M[k++, 1] = double.Parse(coord[1]);
            }
            return M;
        }
    }
}
