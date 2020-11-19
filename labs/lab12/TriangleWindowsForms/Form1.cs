using System;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        Triangle _triangle;
        string _perimResult = "", _ploshResult = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void InpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _perimResult = "";
            _ploshResult = "";
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
                _triangle = new Triangle(form2.A, form2.B, form2.C);
            if (form2.CalcPerim) _perimResult = _triangle.CalcPerim().ToString();
            if (form2.CalcPlosh) _ploshResult = _triangle.CalcPlosh().ToString();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_triangle == null)
            {
                MessageBox.Show("Вы не задали стороны треугольника");
                return;
            }
            Form3 form3 = new Form3();
            if (_perimResult != "")
                _perimResult = "Периметр треугольника равен: " + _perimResult;
            if (_ploshResult != "")
                _ploshResult = "Площадь треугольника равна: " + _ploshResult;
            form3.Result = new string[] {_perimResult, _ploshResult};
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
