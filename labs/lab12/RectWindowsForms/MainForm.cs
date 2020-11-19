using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RectWindowsForms
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void sizwToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitToolMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void paintMenu_Click(object sender, EventArgs e)
        {
            PrintRect(new Rect());
        }

        internal void PrintRect(Rect rect)
        {
            if (rect.A > Size.Width || rect.B > Size.Height)
            {
                MessageBox.Show("Размер прямоугольника превышает размер окна");
                return;
            }
            List<Color> colors = new List<Color>();
            colors.Add(Color.Blue);
            colors.Add(Color.Green);
           
            //string color;
            Graphics lines = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush, 3);
            int k = 0;
            pen.Color = colors[k++];
            if (k >= colors.Count) k = 0;
            

            lines.DrawLine(pen, 10, 30, (float)rect.A+10, 30);
            lines.DrawLine(pen, 10, (float)rect.B + 30, (float)rect.A + 10, (float)rect.B + 30);

            pen.Color = colors[k++];
            if (k >= colors.Count) k = 0;

            lines.DrawLine(pen, (float)rect.A+10, 30, (float)rect.A+10, (float)rect.B+30);

            pen.Color = colors[k++];
            if (k >= colors.Count) k = 0;
            lines.DrawLine(pen, 10, 30, 10, (float)rect.B+30);
        }
    }
}
