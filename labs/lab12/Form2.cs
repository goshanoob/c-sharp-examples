﻿using System;
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
        public double a { get; private set; }
        public double b { get; private set; }
        public double c { get; private set; }
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
            a = Double.Parse(boxA.Text);
            b = Double.Parse(boxB.Text);
            c = Double.Parse(boxC.Text);
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
