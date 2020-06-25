using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        TextBox txtB;

        /* Поведение формы */
        private void button1_Click(object sender, EventArgs e)
        {
            Vkontate vk = new Vkontate();
            int contex = vk.getTok(this);
            
            TextEditor text = new TextEditor(textBox1.Text);
            enterInBox ent = new enterInBox(this);
            string[] coord = textBox2.Text.Split(';');
            if (txtB==null)
            {
                txtB = ent.createTextBox(Int32.Parse(coord[0]), Int32.Parse(coord[1]));
            }
            
            Dictionary<string, int> dic = text.getSort(text.cutWords());
            var top = dic.Take(10);
            int a = 100, b = a + 100;
            int count = dic.Count;
            txtB.Text += "Загружено текстов: " + contex + "\r\n";
            txtB.Text += "Всего слов: " + count + "\r\n";
            for (int i = a; i < b; i++)
            {
                var elem = dic.ElementAt(i);
                txtB.Text += "#"+i+": "+elem.Key + ": " + elem.Value +" - "+ (float)elem.Value/count*100 + "%\r\n";
            }



        }
        public TextBox TextBox1
        {
            get
            {
                return textBox1;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /*
        private string myText;

        public string MyText
        {
            get
            {
                return textBox1.Text;
            }


        }

        public RichTextBox RichTextBox1
        {
            get
            {
                return richTextBox1;
            }
        }*/
    }
}
