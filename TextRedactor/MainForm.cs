using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FileSystemLibrary;

namespace Labs.TextRedactor
{
    public interface IUIterface
    {
        event EventHandler openFile;
        event EventHandler saveFile;
        event EventHandler textChanged;
    }


    public partial class MainForm : Form, IUIterface
    {
        public event EventHandler textChanged;
        public event EventHandler openFile;
        public event EventHandler saveFils;

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
            textChanged(sender, e);

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

        private void openButton_Click_1(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
