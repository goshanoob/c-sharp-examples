using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
            int k = 0;
            int[] a = baseNumbers.Text.Split(' ').Select(x => Int32.Parse(x)).ToArray();
            tree = new TreeSystem(a);
            List<int> ends = tree.GetEnds();
            foreach(int i in ends)
            {
                listBox1.Items.Add(i);
            }

            List<List<int>> adjac = tree.GetAdjac();
            foreach (List<int> i in adjac)
            {
                listBox2.Items.Add("Массив номеров смежных элементов у " + k++ +": " + string.Join(", ", i));
            }


            List<List<int>> supp = tree.GetSupp();
        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void drawTree(object sender, EventArgs e)
        {
            Graphics grath = CreateGraphics();
            float x = 840, y = 30, width = 20, height = 20;
            Pen pen = new Pen(Color.Black);
            //grath.DrawEllipse(pen, x, y, width, height);
            /*for(int i = 1; i < tree.Bases[0]; ++i)
            {
                y += 30;
                x -= 100;
                for(int j = 0; j < tree.Adjac[i][0]; ++j)
                {
                    
                    grath.DrawEllipse(pen, x, y, width, height);
                }
            }*/
            recurs(1, 0);
            void recurs(int i, int k)
            {
                
                grath.DrawEllipse(pen, x-100*k, y+30*k, width, height);
                for (int j = 1; j <= tree.Adjac[i][0]; ++j)
                {
                    x += 30;
                    recurs(tree.Adjac[i][j], ++k);
                }
                
            }
            
        }
    }
}
