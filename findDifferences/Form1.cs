using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Threading;



namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        public List<int> pointsX = new List<int>();
        public List<int> pointsY = new List<int>();

        Bitmap scr1;
        Bitmap scr2;

        bool str = true;
        System.Windows.Forms.Timer timing;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализцация таймера
            timing.Tick += new EventHandler(ChangePictures);
            timing.Interval = 500;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            drawing();
        }


        public void drawing()
        {
            for (int i = 0; i < pointsX.Count; i++)
            {
                Cursor.Position = new Point(pointsX[i], pointsY[i]);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
                //System.Threading.Thread.Sleep(2000);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//make left button up
                System.Threading.Thread.Sleep(500);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            pointsX.Clear();
            pointsY.Clear(); // очистить расставленные точки
            timing.Stop(); // отключить таймер
            SavePictures(); // вырезать и сохранить изображения
        }

        /* Метод вырезки изображений и сохранения на диске */
        public void SavePictures()
        {
            /* Координаты изображения на экране для вырезки*/
            int x1, y1, h1, w1, x2, y2, h2, w2;
            x1 = 758; // координата x левого верхнего угла изображения на экране
            y1 = 263; // координата y левого верхнего угла изображения на экране
            x2 = 1100; // координата x правого нижнего угла изображения на экране
            y2 = 263; // координата y правого нижнего угла изображения на экране
            h1 = 748 - y1; // вертикальный размер вырезаемого изображения
            w1 = 1088 - x1; // горизонтальный размер вырезаемого изображения
            h2 = h1;
            w2 = w1;

            scr1 = new Bitmap(w1, h1);
            scr2 = new Bitmap(w2, h2);

            Graphics g = Graphics.FromImage(scr1);
            g.CopyFromScreen(x1, y1, 0, 0, new Size(w1, h1));
            scr1.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/one.jpg", ImageFormat.Jpeg);

            g = Graphics.FromImage(scr2);
            g.CopyFromScreen(x2, y2, 0, 0, new Size(w2, h2));
            scr2.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/two.jpg", ImageFormat.Jpeg);

            pictureBox1.Height = h1;
            pictureBox1.Width = w1;
        }

        private void ChangePictures()
        {
            /* Мигалка */
            if (str)
            {
                pictureBox1.BackgroundImage = scr1;
            } else
            {
                pictureBox1.BackgroundImage = scr2;
            }
            /*
            for (int i = 0; i < pointsX.Count; i++)
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawEllipse(new Pen(Brushes.Red), pointsX[i] - 758, pointsY[i] - 263, 30, 30);
            }
            */
            str = !str;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x = this.PointToClient(Cursor.Position).X;
            int y = this.PointToClient(Cursor.Position).Y;
            pointsX.Add(758+x-130);
            pointsY.Add(263+y-20);
        }
    }
}
