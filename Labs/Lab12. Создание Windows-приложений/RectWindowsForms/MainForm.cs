using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RectWindowsForms
{
    public partial class MainForm : Form
    {
        Rect rect;
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
            PrintRect(rect);
        }

        internal void PrintRect(Rect rect)
        {
            const byte originX = 10, originY = 30; // координаты начала рисунка
            if (rect.A + originX > Size.Width || rect.B + originY > Size.Height)
            {
                MessageBox.Show("Размер прямоугольника превышает размер окна");
                return;
            }
            // преобразование составляющих в цвета
            List<Color> colors = new List<Color>() { Color.Black };
            if (rect[0] == 1)
            {
                colors[0] = Color.Red;
            }
            if (rect[1] == 1)
            {
                colors.Add(Color.Green);
            }
            if (rect[2] == 1)
            {
                colors.Add(Color.Blue);
            }
            // рисование прямоугольника
            Graphics lines = CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush, 3);
            float a = (float)rect.A, b = (float)rect.B;
            float x = a + originX, y = b + originY; // координата x правого верхнего и y правого нижнего углов
            int k = 0;
            ChangeColor();
            lines.DrawLine(pen, originX, originY, x, originY);
            lines.DrawLine(pen, originX, y, x, y);
            ChangeColor();
            lines.DrawLine(pen,x, originY, x, y);
            ChangeColor();
            lines.DrawLine(pen, originX, originY, originX, y);
            void ChangeColor()
            {
                // смена цвета по кругу
                pen.Color = colors[k++];
                if (k >= colors.Count) k = 0;
            }
        }

        private void sizeMenu_Click(object sender, EventArgs e)
        {
            SizeForm sizeForm = new SizeForm();
            if (sizeForm.ShowDialog() == DialogResult.OK)
            {
                rect = new Rect(sizeForm.A, sizeForm.B, sizeForm.Colors);
            }
        }
    }
}
