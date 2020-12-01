using System;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form2 : Form
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public bool CalcPerim { get; private set; } = true;
        public bool CalcPlosh { get; private set; } = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A = double.Parse(boxA.Text);
            B = double.Parse(boxB.Text);
            C = double.Parse(boxC.Text);
            if (!checkPerim.Checked)
                CalcPerim = false;
            if (!checkPlosh.Checked)
                CalcPlosh = false;
        }
    }
}
