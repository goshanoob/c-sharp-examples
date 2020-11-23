using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Pyatnashki
{
    public partial class Form1 : Form
    {
        int rowCount;
        int colCount;
        Tags tag;
        Button[] _formTags;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация игрового поля
            rowCount = 5;
            colCount = 5;
            tag = new Tags(rowCount, colCount);
            int k = 0;
            _formTags = new Button[rowCount * colCount];
            foreach (Control element in Controls)
            {
                // выборка только пятнашек из всех элементов управления (по имени)
                Button tag = element as Button;
                if (tag != null && Regex.IsMatch(tag.Name, @"tag\d+"))
                {
                    _formTags[k++] = tag;
                    tag.Click += SetMove;
                }
            }
            Array.Sort(_formTags, new SortByName()); // сортировка кнопок по имени
            tag.Shaffle(); // перемешивание пятнашек
            MakeLabels(); // изменение подписей кнопок
        }
        private void SetMove(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(Regex.Replace(((Button)sender).Name, @"[^\d]*", "")) - 1;
            tag.SetMove(number / rowCount, number % colCount);
            //tag.SetMove(((Button)sender).Location.Y / 100 - 1, ((Button)sender).Location.X / 100 - 2); // определять позицию пятнишки по координатам - не надежно
            MakeLabels();
            TestResult();
        }

        private void MakeLabels()
        {
            int i = 0; int j = 0;
            foreach (Button f in _formTags)
            {
                f.Visible = tag.TagMatrix[i, j] == 0 ? false : true;
                f.Text = tag.TagMatrix[i, j++].ToString();
                if (j == colCount)
                {
                    ++i;
                    j = 0;
                }
            }
        }

        private void TestResult()
        {
            if (tag.TestResult())
            {
                MessageBox.Show("Вы выиграли!");
                tag.Shaffle();
                MakeLabels();
            }
        }
        public class SortByName : IComparer
        {
            // сортировка по имени кнопок
            int IComparer.Compare(object x, object y)
            {
                Button button1 = (Button)x;
                Button button2 = (Button)y;
                int number1 = Convert.ToInt32(Regex.Replace(button1.Name, @"[^\d]*", ""));
                int number2 = Convert.ToInt32(Regex.Replace(button2.Name, @"[^\d]*", ""));
                if (number1 < number2) return -1;
                if (number1 > number2) return 1;
                return 0;
            }
        }

        private void shuffleTags_Click(object sender, EventArgs e)
        {
            tag.Shaffle();
            MakeLabels();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
