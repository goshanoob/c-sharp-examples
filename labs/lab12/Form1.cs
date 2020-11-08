using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        Triangle triangle;
        public Form1()
        {
            InitializeComponent();
        }

        private void InpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            if (form2.ShowDialog() == DialogResult.OK) triangle = new Triangle(form2.a, form2.b, form2.c);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            
            form3.Result = new string[] {"Периметр треугольника равен: "+ triangle.CalcPerim(),
                "Площадь треугольника равна: "+triangle.CalcPlosh() };
            form3.ShowDialog();
        }
    }
}
