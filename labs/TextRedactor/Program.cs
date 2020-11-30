using FileSystemLibrary;
using System;
using System.Windows.Forms;

namespace Labs.TextRedactor
{
    // Незаконченная программа для редактирования текстовых документов.

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();
            FileSystem fileSystem = new FileSystem();

            Controller control = new Controller(mainForm, fileSystem);

            Application.Run(mainForm);
        }
    }
}
