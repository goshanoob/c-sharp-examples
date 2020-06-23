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

        public string[] cutWords()
        {
            char[] sep = new char[] { ',', ' ', '\"', '.', '»' , '«', ':', '-' };
            //string[] words = text.Split(sep);
            text = text.Replace("\r\n", " ").ToLower();
            return text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        }

        public Dictionary<string, int> getSort(string[] words)
        {
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
            
            dic = dic.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return dic;
        }


    }

    class Vkontate
    {
       
        public int getTok(Form1 form)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();

            var api = new VkApi(services);

            // Авторизируемся для получения токена валидного для вызова методов Audio / Messages
            api.Authorize(new ApiAuthParams
            {
                AccessToken = ""
                /*Login = "goshanoob@mail.ru",
                Password = ""*/
            });
            //MessageBox.Show(api.Token);
            var audios = api.Audio.Get(new AudioGetParams { Count = 6000, OwnerId = -160498600 });
            string lal = "";
            int empt = 0;
            foreach(var song in audios)
            {
                if (song.LyricsId == null)
                {
                    lal += "Без текста\r\n";
                    empt++;
                    continue;
                }
                lal += api.Audio.GetLyrics((long)song.LyricsId).Text+ "\r\n";
            }
           /* long number = (long)audios[3].LyricsId;
            string lal = api.Audio.GetLyrics(number).Text;*/
            
            form.TextBox1.Text = lal.Replace("\n", "\r\n");
            return audios.Count-empt;
        }
    }
}