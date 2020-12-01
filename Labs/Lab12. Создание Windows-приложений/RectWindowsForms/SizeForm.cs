using System;
using System.Windows.Forms;

namespace RectWindowsForms
{
    public partial class SizeForm : Form
    {
        public double A { get;  set; } 
        public double B { get;  set; } 
        public byte[] Colors { get; set; }
        public SizeForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            A = double.Parse(sizeA.Text);
            B = double.Parse(sizeB.Text);
            Colors = new byte[3];
            if (redFlag.Checked) 
                Colors[0] = 1;
            if (greenFlag.Checked) 
                Colors[1] = 1;
            if (blueFlag.Checked) 
                Colors[2] = 1;
        }
    }
}
