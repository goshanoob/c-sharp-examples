using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Pyatnashki
{
    public partial class Form1 : Form
    {
        Tags tag = new Tags(3, 3);

        Button[] _formTags;

        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetMove(sender, e);
        }
        private void SetMove(object sender, EventArgs e)
        {
            tag.SetMove(((Button)sender).Location.Y / 100 - 1, ((Button)sender).Location.X / 100 - 2);
            int i = 0; int j = 0;
            foreach (Button f in _formTags)
            {
                if (tag.TagMatrix[i, j] == 0)
                {
                    f.Enabled = false;
                }
                else
                {
                    f.Enabled = true;
                }
                f.Text = tag.TagMatrix[i, j++].ToString();


                if (j == 3)
                {
                    ++i;
                    j = 0;
                }


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int k = 0;
            _formTags = new Button[9];
            foreach (Control element in Controls)
            {
                Button tag = element as Button;
                if (tag != null && Regex.IsMatch(tag.Name, @"tag\d+"))
                {
                    _formTags[k++] = tag;
                    tag.Click += SetMove;
                }
            }
            Array.Sort(_formTags, new SortByName());
        }

        public class SortByName : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Button button1 = (Button)x;
                Button button2 = (Button)y;
                return String.Compare(button1.Name, button2.Name);
            }
        }
    }
}
