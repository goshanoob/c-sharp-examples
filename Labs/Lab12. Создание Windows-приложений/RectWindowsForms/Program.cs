using System;
using System.Windows.Forms;

// Из лабораторной работы 12. Создание Windows-приложений. Задача 2.

namespace RectWindowsForms
{
    // Программа для рисования разноцветного прямоугольника. Пользователь задает ширину и высоту прямоугольника и
    // сочетание из трёх цветов для его изображения. Для описания прямоугольника реализован класс Rect.
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
            Application.Run(new MainForm());
        }
    }
}
