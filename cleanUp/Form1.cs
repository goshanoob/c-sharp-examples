using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        // создание объекта для сортировки
        Sorting sorting = new Sorting();

        public Form1()
        {
            InitializeComponent();
        }

        /* Обработчик события загрузки формы */
        private void Form1_Load(object sender, EventArgs e)
        {
            // чтение содержимого каталого по умолчанию
            sorting.ReadCatalogue(this);
            this.textBox1.Text = sorting.root;
        }

        /* Обработчик нажатия кнопи для чтения рабочего каталога */
        private void button1_Click(object sender, EventArgs e)
        {
            sorting.ReadCatalogue(this);
        }

        /* Методы доступа к элементам формы */
        public ListBox getListBox(char a)
        {
            if (a == '1')
                return listBox1;
            return listBox2;
        }

        public TextBox getTextBox()
        {
            return textBox1;
        }

        // Для вывода сообщений
        public Label getLabel()
        {
            return label1;
        }

        /* Обработчик нажатия кнопки для смены рабочего каталога */
        private void button4_Click(object sender, EventArgs e)
        {
            sorting.ChangeCatalogue(this);
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sorting.ExampleSort(this);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
