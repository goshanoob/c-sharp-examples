using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Abstractions;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;


namespace goshanoob.MatchesCounter
{
    // Класс Vkontacte для работы с API VK.
    // Закрытое поле класса содержит ссылку на экземпляр класса из бибилиотеки для работы с API VK.
    // Свойство SongsCount возвращает количество загруженных треков.
    // Метод GetEnter() позволяет авторизоваться в социальной сети по логину и паролю, переданным в качесте
    // аргументов. Метод GetAudio() возвращает тексты песен.
    internal class Vkontakte
    {
        private VkApi _api;
        public int SongsCount { get; private set; }
        public void GetEnter(string login, string password)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            _api = new VkApi(services);

            // Авторизируемся для получения токена.
            _api.Authorize(new ApiAuthParams
            {
                // Если токен уже получен, то можно использовать его.
                // Здесь используется логин для авторизации.
                //AccessToken = "", 
                Login = login,
                Password = password
            });
            // MessageBox.Show(api.Token);
        }

        public string GetAudio()
        {
            // Запрос к аудио по идентификатору группы или пользователя OwnerId, Count - максимальный объем выборки.
            var audios = _api.Audio.Get(new AudioGetParams { Count = 6000 });
            string text = "";
            // Счетчик аудио без текста.
            int empt = 0; 
            foreach (var song in audios)
            {
                if (song.LyricsId == null)
                {
                    text += "Без текста\r\n";
                    empt++;
                    continue;
                }
                text += _api.Audio.GetLyrics((long)song.LyricsId).Text + "\r\n";
            }
            SongsCount = audios.Count - empt;
            return text;
        }
    }
}
