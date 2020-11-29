using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace goshanoob.DifferencesFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        // Импорт системной библиотеки для управления мышью.
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        // Поля-списки для хранения отмеченных координат.
        private List<int> _pointsX = new List<int>();
        private List<int> _pointsY = new List<int>();
        // Поля для хранения изображений для анимации.
        private Bitmap _pictureLeft, _pictureRight;
        // Изображения сменяются по таймеру.
        private Timer timer = new Timer();
        // Поле-переключатель изображений.
        private bool _isLeftPicture = true;
        // Левый верхний угол изображения в игре.
        private const int originX = 545, originY = 223;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Интервал таймера.
            const int interval = 500;
            timer.Tick += (send, even) =>
            {
                pictureBox.BackgroundImage = _isLeftPicture ? _pictureRight : _pictureLeft;
                _isLeftPicture = !_isLeftPicture;
            };
            timer.Interval = interval;
        }
        private void makeScreenButton_Click(object sender, EventArgs e)
        {
            _pointsX.Clear();
            _pointsY.Clear();
            timer.Stop();
            CutImages();
            timer.Start();
        }
        private void CutImages()
        {
            // Координаты изображений на экране для вырезки.
            int x1, y1, h1, w1, x2, y2, h2, w2;
            // Координаты x и y левого верхнего угла первого изображения.
            x1 = originX;
            y1 = originY;
            // Координаты x и y левого верхнего угла второго изображения.
            x2 = 895;
            y2 = y1;
            // Ширина высота вырезаемых изображений.
            h1 = 503;
            w1 = 344;
            h2 = h1;
            w2 = w1;

            _pictureLeft = new Bitmap(w1, h1);
            _pictureRight = new Bitmap(w2, h2);

            Graphics g;
            using (g = Graphics.FromImage(_pictureLeft))
            {
                g.CopyFromScreen(x1, y1, 0, 0, new Size(w1, h1));
            }
            using (g = Graphics.FromImage(_pictureRight))
            {
                g.CopyFromScreen(x2, y2, 0, 0, new Size(w2, h2));
            }
            pictureBox.Height = h1;
            pictureBox.Width = w1;
        }
        private void makeClicksButton_Click(object sender, EventArgs e)
        {
            // Пауза между кликами мышью в мс.
            const int pause = 500;
            for (int i = 0; i < _pointsX.Count; i++)
            {
                Cursor.Position = new Point(_pointsX[i], _pointsY[i]);
                // Эмулируем зажатие левой кнопки мыши, а затем отпускание.
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                // Добавить паузу между кликами.
                System.Threading.Thread.Sleep(pause);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Корректирующие значения относительно левого верхнего угла формы.
            int deltaX = pictureBox.Location.X, deltaY = pictureBox.Location.Y;
            int x = PointToClient(Cursor.Position).X;
            int y = PointToClient(Cursor.Position).Y;
            _pointsX.Add(originX + x - deltaX);
            _pointsY.Add(originY + y - deltaY);
        }
    }
}