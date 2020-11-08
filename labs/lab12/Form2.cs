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
    public partial class Form2 : Form
    {
        public double a { private set;  get; }
        public double b { private set; get; }
        public double c { private set; get; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Double.Parse(textBox1.Text);
            b = Double.Parse(textBox2.Text);
            c = Double.Parse(textBox3.Text);
        }
    }
}
