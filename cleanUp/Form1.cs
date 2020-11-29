using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace goshanoob.CleanUpApp
{
    public interface IUserInterface
    {
        // Интрефейс описывает события изменения рабочего каталога, запроса на сортировку, 
        // а также свойства: путь к каталогу, список файлов в каталоге и отсортированные по категориям 
        // файлы в параметризированной коллекции Dictionary.
        event EventHandler CatalogueChanged;
        event EventHandler SortRequested;
        string CataloguePath { get; set; }
        string[] FilesList { get; set; }
        Dictionary<string, List<string>> FilesInOrder { get; set; }
    }
    public partial class Form1 : Form, IUserInterface
    {
        // По умолчанию работаем с домашним каталогом пользователя.
        private readonly string _rootPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public event EventHandler CatalogueChanged;
        public event EventHandler SortRequested;
        public string CataloguePath { get; set; }
        public string[] FilesList { get; set; }
        public Dictionary<string, List<string>> FilesInOrder { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void changeCatalogueButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = _rootPath;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                CataloguePath = folder.SelectedPath;
                catalogueTextBox.Text = CataloguePath;
                statusLabel.Text = "Изменили рабочий каталог";
                ReadCatalogue(sender, e);
            }
        }
        private void ReadCatalogue(object sender, EventArgs e)
        {
            // Чтение каталога.
            CatalogueChanged?.Invoke(sender, EventArgs.Empty);
            // Вывод списка файлов каталога на форму.
            filesListBox.Items.Clear();
            foreach (string file in FilesList)
            {
                filesListBox.Items.Add(file);
            }
        }
        private void updateFileListButton_Click(object sender, EventArgs e)
        {
            ReadCatalogue(sender, e);
        }
        private void sortButton_Click(object sender, EventArgs e)
        {
            Sort();
            SortRequested?.Invoke(sender, EventArgs.Empty);
        }
        private void testSortButton_Click(object sender, EventArgs e)
        {
            Sort();
        }
        private void Sort()
        {
            FileSorter sortingFiles = new FileSorter(CataloguePath, FilesList);
            // Сортировка файлов.
            FilesInOrder = sortingFiles.PutInOrder();
            Dictionary<string, List<string>>.KeyCollection catigories = FilesInOrder.Keys;
            // Вывод сортированных файлов на форму.
            sortedListBox.Items.Clear();
            foreach (string catigory in catigories)
            {
                sortedListBox.Items.Add($"{catigory} ({FilesInOrder[catigory].Count}):");
                foreach (string file in FilesInOrder[catigory])
                {
                    sortedListBox.Items.Add(file);
                }
                sortedListBox.Items.Add("\r\n");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Чтение содержимого каталого по умолчанию.
            catalogueTextBox.Text = _rootPath;
            CataloguePath = _rootPath;
            ReadCatalogue(sender, e);
        }

        // Доступный метод, возвращающий строковый массив с именами категорий.
        public string[] GetFoldersName()
        {
            Dictionary<string, List<string>>.KeyCollection catigories = FilesInOrder.Keys;
            var a = from string key in catigories
                    where FilesInOrder[key].Count > 0
                    select key;
            string[] catigoriesName = new string[a.Count()];
            int i = 0;
            foreach (string k in a)
            {
                catigoriesName[i++] = k;
            }
            return catigoriesName;
        }
    }
}
