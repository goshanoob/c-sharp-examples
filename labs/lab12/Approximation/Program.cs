using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemLibrary;

namespace Approximation
{
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

            MainForm form = new MainForm();
            FileSystem fileSystem = new FileSystem();
            Presenter presenter = new Presenter(fileSystem, form);

            
            Application.Run(form);
        }
    }
}
