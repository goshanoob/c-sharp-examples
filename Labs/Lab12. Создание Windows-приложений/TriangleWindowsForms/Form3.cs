using System;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form3 : Form
    {
        public string[] Result
        {
            set
            {
                perim.Text = value[0];
                plosh.Text = value[1];
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
