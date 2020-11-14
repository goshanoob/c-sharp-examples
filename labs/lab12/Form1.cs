using System;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        Triangle triangle;
        string perimResult = "", ploshResult = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void InpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perimResult = "";
            ploshResult = "";
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
                triangle = new Triangle(form2.a, form2.b, form2.c);
            if (form2.CalcPerim) perimResult = triangle.CalcPerim().ToString();
            if (form2.CalcPlosh) ploshResult = triangle.CalcPlosh().ToString();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (triangle == null)
            {
                MessageBox.Show("Вы не задали стороны треугольника");
                return;
            }
            Form3 form3 = new Form3();
            if (perimResult != "")
                perimResult = "Периметр треугольника равен: " + perimResult;
            if (ploshResult != "")
                ploshResult = "Площадь треугольника равна: " + ploshResult;
            form3.Result = new string[] {perimResult, ploshResult};
            form3.ShowDialog();
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InpToolStripMenuItem_Click(sender, e);
        }

        private void calcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CalcToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
