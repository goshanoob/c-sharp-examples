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
    internal class Vkontate
    {
        public int getTok(Form1 form)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var api = new VkApi(services);

            // Авторизируемся для получения токена
            api.Authorize(new ApiAuthParams
            {
                // Можно использовать токен, если есть, или использовать логин
                //AccessToken = "" 
                Login = "goshanoob@mail.ru",
                Password = "Gea0pcgF41"
            });
            //MessageBox.Show(api.Token);

            // Запрос к аудио по идентификатору группы или пользователя OwnerId, Count - объем выборки
            var audios = api.Audio.Get(new AudioGetParams { Count = 6000 });
            string text = "";
            int empt = 0; // счетчик аудио без текста
            foreach (var song in audios)
            {
                if (song.LyricsId == null)
                {
                    text += "Без текста\r\n";
                    empt++;
                    continue;
                }
                text += api.Audio.GetLyrics((long)song.LyricsId).Text + "\r\n";
            }

            form.audioText.Text = text.Replace("\n", "\r\n");
            return audios.Count - empt;
        }
    }
}
