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
        }
        

        /* Метод для работы с формой */
        public void ReadCatalogue(Form1 form)
        {
            // получить из формы элементы Список и Текстовое поле
            ListBox listBox = form.getListBox('1');
            TextBox textBox = form.getTextBox();
            listBox.Items.Clear();

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
        public Dictionary<string, List<string>> Sort()
        {
            Dictionary<string,List<string>> sortingFiles = new Dictionary<string, List<string>>();
            string extension;

            /* Создание категорий файлов */
            sortingFiles.Add("Текстовые документы", new List<string>());
            sortingFiles.Add("Многостраничные документы", new List<string>());
            sortingFiles.Add("Исполняемые и пакетные файлы", new List<string>());
            sortingFiles.Add("Изображения", new List<string>());
            sortingFiles.Add("Исходный код", new List<string>());
            sortingFiles.Add("Музыка", new List<string>());
            sortingFiles.Add("Видео", new List<string>());
            sortingFiles.Add("Архивы", new List<string>());
            sortingFiles.Add("Торренты", new List<string>());
            sortingFiles.Add("Офисные документы", new List<string>());
            sortingFiles.Add("Прочие", new List<string>());
           
            foreach (string file in files)
            {
                extension = Path.GetExtension(file);
                switch (extension.ToLower())
                {
                    case ".msi":
                    case ".bat":
                    case ".exe": sortingFiles["Исполняемые и пакетные файлы"].Add(file); break;
                    case ".rtf":
                    case ".doc":
                    case ".docx":
                    case ".docm":
                    case ".txt": sortingFiles["Текстовые документы"].Add(file); break;
                    case ".jpg":
                    case ".jpeg":
                    case ".gif":
                    case ".png": sortingFiles["Изображения"].Add(file); break;
                    case ".pdf":
                    case ".djvu": sortingFiles["Многостраничные документы"].Add(file); break;
                    case ".cs": 
                    case ".cpp": 
                    case ".html": 
                    case ".php": 
                    case ".py": 
                    case ".svg": 
                    case ".x3d": 
                    case ".wrl": 
                    case ".css": 
                    case ".xml": 
                    case ".xslt": 
                    case ".js": sortingFiles["Исходный код"].Add(file); break;
                    case ".mp3":
                    case ".ogg":
                    case ".flac":
                    case ".wav": sortingFiles["Музыка"].Add(file); break;
                    case ".mp4":
                    case ".avi":
                    case ".mkv":
                    case ".sfx":
                    case ".flv": sortingFiles["Видео"].Add(file); break;
                    case ".tar": 
                    case ".gz": 
                    case ".zip": 
                    case ".rar": sortingFiles["Архивы"].Add(file); break;
                    case ".torrent": sortingFiles["Торренты"].Add(file); break;
                    case ".ppt": 
                    case ".pptx": 
                    case ".xls": 
                    case ".xlsx": sortingFiles["Офисные документы"].Add(file); break;
                    default: sortingFiles["Прочие"].Add(file); break;
                }
            }
            return sortingFiles;
        }

        /* Метод вывода предварительной сортировки */
        public void ExampleSort(Form1 form)
        {
            Dictionary<string, List<string>> soirtinfFiles = Sort();
            ListBox listBox = form.getListBox('2');
            Dictionary<string, List<string>>.KeyCollection catigories = soirtinfFiles.Keys;

            listBox.Items.Clear();
            foreach (string catigorie in catigories)
            {
                listBox.Items.Add(catigorie+" ("+ soirtinfFiles[catigorie].Count + "):");
                foreach (string file in soirtinfFiles[catigorie])
                {
                    listBox.Items.Add(file);
                }
                listBox.Items.Add("\r\n");


            }
        }

        /* Метод действительной сортировки */
        public void MakeSort()
        {
            Dictionary<string, List<string>> soirtinfFiles = Sort();
            Dictionary<string, List<string>>.KeyCollection catigories = soirtinfFiles.Keys;
            string path;
            foreach (string catigorie in catigories)
            {
                if (soirtinfFiles[catigorie].Count == 0) continue;

                path = root + "\\" + catigorie;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (string file in soirtinfFiles[catigorie])
                {
                    /* здесь перемещение файлов */
                    if (File.Exists(file) && !File.Exists(path+"\\"+ Path.GetFileName(file)))
                    {
                        File.Move(file, path + "\\" + Path.GetFileName(file));
                    }

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

            ReadCatalogue(form);
        }

        /* Метод логирования перемещений */
        public void WriteNote(string path1, string path2)
        {

        }

    }

    
}
