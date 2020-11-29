using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace goshanoob.CleanUpApp
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

            Form1 programForm = new Form1();
            FileSystemDirectory FSDirectory = new FileSystemDirectory();
            Presenter presenter = new Presenter(programForm, FSDirectory);

            Application.Run(programForm);
        }
    }
}
