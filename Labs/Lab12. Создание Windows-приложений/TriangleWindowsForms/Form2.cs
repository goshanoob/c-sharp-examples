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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            A = Double.Parse(boxA.Text);
            B = Double.Parse(boxB.Text);
            C = Double.Parse(boxC.Text);
            if (!checkPerim.Checked)
                CalcPerim = false;
            if (!checkPlosh.Checked)
                CalcPlosh = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
