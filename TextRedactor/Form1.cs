using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FileSystemLibrary;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        TextRedactor redactor = new TextRedactor();
        public MainForm()
        {
            InitializeComponent();
        }

        private void FormRedactor_Load(object sender, EventArgs e)
        {
            this.Text += " Новый файл";
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            this.Text += "*";
            redactor.Text = textBox.Text;
            this.symbolCount.Text = redactor.GetSymbolCount().ToString();

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                //fd.Filter = "*.txt";
                redactor.GetText(fd.FileName);
                textBox.Text = redactor.Text;
            }
            
        }

        private void fileMenuOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
