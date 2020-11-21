using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TreeSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TreeSystem tree;
        private void calcButton_Click(object sender, EventArgs e)
        {
            // очистка 
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            Graphics grath = CreateGraphics();
            grath.Clear(Form1.DefaultBackColor);
            int k = 0, f = 0;
            int[] a = baseNumbers.Text.Split(' ').Select(x => Int32.Parse(x)).ToArray();
            tree = new TreeSystem(a);
            List<int> ends = tree.GetEnds();
            foreach (int i in ends)
            {
                listBox1.Items.Add(i);
            }
            List<List<int>> adjac = tree.GetAdjac();
            List<List<int>> supp = tree.GetSupp();
            foreach (List<int> i in adjac)
            {
                listBox2.Items.Add("Массив номеров смежных элементов у " + k++ + ": " + string.Join(", ", i));
                listBox3.Items.Add("Массив несущей цепочки элемента у " + f + ": " + string.Join(", ", supp[f++]));
            }
            drawTree(sender,e);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void drawTree(object sender, EventArgs e)
        {
            Graphics grath = CreateGraphics();
            float x = 840, y = 40, d = 20;
            Pen pen = new Pen(Color.Black);
            Font font = new Font("Arial", 10);
            SolidBrush brushString = new SolidBrush(Color.White);
            SolidBrush brushStroke = new SolidBrush(Color.Black);
            DrowBranch(1, x, y, x, y);
            void DrowBranch(int i, float cx, float cy, float c0x, float c0y)
            {
                grath.DrawLine(pen, cx, cy, c0x, c0y+d/2);
                grath.FillEllipse(brushString, cx - d / 2, cy - d / 2, d, d);
                grath.DrawEllipse(pen, cx - d / 2, cy - d / 2, d, d);
                grath.DrawString(i.ToString(), font, brushStroke, cx - d / 3, cy - d / 3);
                for (int j = 1; j <= tree.Adjac[i][0]; ++j)
                {
                    var k = 500 / (tree.Adjac[i][0] + 1)*j;
                    DrowBranch(tree.Adjac[i][j], cx - 250 + k, cy + 30, cx, cy);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            baseNumbers.Text = ((Label)sender).Text;
            calcButton_Click(sender,e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label5_Click(sender, e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label5_Click(sender, e);
        } 
    }
}
