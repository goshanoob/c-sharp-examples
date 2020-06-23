using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp4
{
    public class Sorting
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           // Application.Run(new FolderBrowserDialogExampleForm());
        }


        /* Каталог для сортировки файлов*/
        public string root;
        /* Массив имен файлов */
        public string[] files;
        /* Поддерживаемые расширения */
        public string[] extentions;

        /* Форма для работы */
        //public Form form;
        
        /* Конструктор */
        public Sorting()
        {
            root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //extentions = Regex.Split(form.getTextBox().Text, @"\s*,", RegexOptions.IgnoreCase);
            //extentions = {"", "", "", "" };
        }
        

        /* Метод для работы с формой */
        public void ReadCatalogue(Form1 form)
        {
            // получить из формы элементы Список и Тестовое поле
            ListBox listBox = form.getListBox('1');
            TextBox textBox = form.getTextBox();

            // поулчение список файлов в рабочей папке
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            files = Directory.GetFiles(root);

            // вывод имен файлов
            foreach (string i in files)
            {
                listBox.Items.Add(Path.GetFileName(i));
            }

        }


        /* Метод сортировки */
        public List<List<string>> Sort()
        {
            List<List<string>> soirtingFiles = new List<List<string>>();
            string extension;

            byte N = 5; // количество изветсных расширений
            for (byte i = 0; i < N; i++)
            {
                soirtingFiles.Add(new List<string>());
            }
           
            foreach (string file in files)
            {
                extension = Path.GetExtension(file);
                switch (extension)
                {
                    case ".exe": soirtingFiles[0].Add(file); break;
                    case ".doc":
                    case ".txt": soirtingFiles[1].Add(file); break;
                    case ".jpg":
                    case ".jpeg":
                    case ".gif":
                    case ".png": soirtingFiles[2].Add(file); break;
                    case ".pdf":
                    case ".djvu": soirtingFiles[3].Add(file); break;
                }
            }
            return soirtingFiles;
        }

        /* Метод вывода предворительной сортировки */
        public void ExampleSort(Form1 form)
        {
            List<List<string>> soirtinfFiles = Sort();
            ListBox listBox = form.getListBox('2');
            foreach (List<string> catigories in soirtinfFiles)
            {
                //listBox.Items.Add("Исполняемые файлы:");
                foreach (string file in catigories)
                {
                    listBox.Items.Add(file);
                }
                    
            }
        }

        /* Метод действительной сортировки */
        public void MakeSort(Form form)
        {
            List<List<string>> soirtinfFiles = Sort();
            foreach (List<string> catigories in soirtinfFiles)
            {
                //listBox.Items.Add("Исполняемые файлы:");
                foreach (string file in catigories)
                {
                    /* здесь перемещение файлов */ 
                }

            }
        }


        /* Метод смены текущего рабочего каталога*/
        public void ChangeCatalogue(Form1 form)
        {
            Label label = form.getLabel();
            TextBox textBox = form.getTextBox();
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = root;
        
            folder.ShowDialog();
            root = folder.SelectedPath;
            textBox.Text = root;
            label.Text = "Изменили рабочий каталог";
        }
    }

    
}
