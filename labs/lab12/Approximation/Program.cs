using FileSystemLibrary;
using System;
using System.IO;
using System.Windows.Forms;

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
            /*
            try
            {
                FileSystem fileSystemPoints = new FileSystem();
                InputPoints IP = new InputPoints();
                string currentDirectory = Directory.GetCurrentDirectory();
                fileSystemPoints.Content = IP.F1;
                fileSystemPoints.WriteFile(currentDirectory + @"\testF1.txt");
                fileSystemPoints.Content = IP.F2;
                fileSystemPoints.WriteFile(currentDirectory + @"\testF2.txt");
                fileSystemPoints.Content = IP.F3;
                fileSystemPoints.WriteFile(currentDirectory + @"\testF3.txt");
                fileSystemPoints.Content = IP.F4;
                fileSystemPoints.WriteFile(currentDirectory + @"\testF4.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */

            FileSystem fileSystem = new FileSystem();
            MainForm form = new MainForm();
            Presenter presenter = new Presenter(fileSystem, form);

            Application.Run(form);
        }
    }
}
