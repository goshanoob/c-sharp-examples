using System;
using System.Windows.Forms;

namespace goshanoob.CleanUpApp
{
    // Программа соритировки документов в папки по категориям. Шаблон проектирования MVP. Отображение - форма WindowsForms.
    // Модель - каталог файловой системы (класс FileSystemDirectory). Презентер - класс Presenter. Для сортировки
    // используется класс FileSorter.

    public class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 programForm = new Form1();
            FileSystemDirectory FSDirectory = new FileSystemDirectory();
            Presenter presenter = new Presenter(programForm, FSDirectory);

            Application.Run(programForm);
        }
    }
}
