using System;

namespace goshanoob.MatchesCounter
{
    // Класс Презентера. В шаблоне проектирования MVP Презентер по запросу Отображения может обновлять Модель, а также
    // изменять Отображение в соответствии с Моделью. Взаимодействие с Отображением осуществляется
    // через экземпляр типа интерфейса, который Отображение реализует. 
    // В данном приложении Отображение - это форма WindowsForms, имеющая одно событие запроса текста и несколько свойств. 
    // Моделью приложения является API Вконтакте. Для этого слоя описан класс Vkontakte. Класс имеет методы подключения 
    // к API и запроса текстов из аудиозаписей пользователя. Необходима авторизация.
    // Метод-обработчик событий Презентера вызывает методы Модели и модифицирует свойства Отображения.
    internal class Presenter
    {
        IUserInterface _UI;
        Vkontakte _VK;
        public Presenter(IUserInterface UI, Vkontakte VK)
        {
            _UI = UI;
            _VK = VK;
            _UI.TextRequested += (sender, e) =>
            {
                try
                {
                    _VK.GetEnter(_UI.Login, _UI.Password);
                    _UI.SongsText = _VK.GetAudio();
                    _UI.SongsCount = _VK.SongsCount;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };
        }
    }
}
