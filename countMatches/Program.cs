using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Abstractions;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;


namespace WindowsFormsApp5
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
            
            
        }

    }

    /* Класс для работы с текстом */
    class TextEditor
    {
        string text;

        public TextEditor(string text)
        {
            this.text = text;
        }

        /*
        public string Text()
        {
            get { return text; }
        }*/

        /* Метод для извлечения слов из текста*/
        public string[] cutWords()
        {
            // Символы, по которым определяем границы слов (сами смволы не нужны, поэтому без ругелярок)
            char[] sep = new char[] { ',', ' ', '\"', '.', '»' , '«', ':', '-' };
            //string[] words = text.Split(sep);
            text = text.Replace("\r\n", " ").ToLower();
            return text.Split(sep, StringSplitOptions.RemoveEmptyEntries); //вернули массив слов без пустых элементов
        }

        /* Метод подсчёта числа повторений слов в тексте и сортировки*/
        public Dictionary<string, int> getSort(string[] words)
        {
            // Словарь из пар "слово - количество вхождений"
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string word2 in words)
            {
                if(dic.ContainsKey(word2))
                {
                    dic[word2]++;
                }
                else
                {
                    dic.Add(word2, 1);
                }
            }
            // сортировка по значению (число вхождений) и возвращение в исходный тип
            dic = dic.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return dic;
        }
    }

    /* Класс для работы с API VK (VKNet)*/
    class Vkontate
    {
        /* Метод подключения */
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
                Login = "your_login",
                Password = "***"
            });
            //MessageBox.Show(api.Token);

            // Запрос к аудио по идентификатору группы или пользователя OwnerId, Count - объем выборки
            var audios = api.Audio.Get(new AudioGetParams { Count = 6000 });
            string text = "";
            int empt = 0; // счетчик аудио без текста
            foreach(var song in audios)
            {
                if (song.LyricsId == null)
                {
                    text += "Без текста\r\n";
                    empt++;
                    continue;
                }
                text += api.Audio.GetLyrics((long)song.LyricsId).Text+ "\r\n";
            }
            
            form.TextBox1.Text = text.Replace("\n", "\r\n");
            return audios.Count-empt;
        }
    }

    /* Класс для работы с формой*/
    class enterInBox
    {
        Form form;
        static TextBox txtBox;
        int createdCount = 0;


        public enterInBox(Form forma)
        {
            this.form = forma;
        }

        public TextBox createTextBox(int c1, int c2)
        {
            txtBox = new TextBox();
            txtBox.Multiline = true;
            //txtBox.AutoSize = true;
            txtBox.Bounds = new System.Drawing.Rectangle(c1, c2, 300, 500);
            form.Controls.Add(txtBox);
            createdCount++;
            return txtBox;
        }

        public void showWords(string[] words)
        {
            txtBox.Clear();
            foreach (string word in words)
            {
                txtBox.Text += word + "\r\n";

            }
        }

        public int CreatedCount
        {
            get { return createdCount; }
        }

    }
}