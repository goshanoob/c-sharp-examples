using System;
using System.Windows.Forms;

namespace goshanoob.DifferencesFinder
{
    // Программа поиска отличий в игре "Где отличие?" во Вконтакте. Закрытый метод CutImages() класса формы
    // делает скришот экрана, а затем вырезает два изображения с отличиями. Класс формы содержит таймер,
    // который позволяет периодически сменять изобаржения, создавая анимацию и облегчая поиск отличий.
    // Закрытые поля-списки хранят координаты отмеченных на изображении отличий. В обработчике makeClicksButton_Click()
    // эмулируется клик левой кнопки мыши в соответствующих координатах на экране.
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
            Application.Run(new Form1());
        }
    }
}