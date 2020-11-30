using System;
using System.Windows.Forms;

namespace goshanoob.MatchesCounter
{
    // Программа испольует внешнюю библиотеку VKNet для работы с API VK. Описан класс Vkontakte для
    // работы с библиотекой: загрузки текстов песен из профиля пользователя.
    // Недоработки: необходимо использовать уже полученный токен вместо повторной авторизации; предусмотреть
    // возможность неправильного ввода пароля и вывод сообщений об ошибках.
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

            Form1 form = new Form1();
            Vkontakte VK = new Vkontakte();
            Presenter presenter = new Presenter(form, VK);

            Application.Run(form);
        }
    }
}