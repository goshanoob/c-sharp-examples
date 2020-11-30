using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace goshanoob.MatchesCounter
{
    // Интерфейс содержит одно событие запроса текстовой информации, а также 4 свойства: логин, пароль,
    // текст и количество текстов.
    public interface IUserInterface
    {
        event EventHandler TextRequested;
        string Login { get; set; }
        string Password { get; set; }
        string SongsText { get; set; }
        int SongsCount { get; set; }
    }

    // Класс формы наследует от интерфейса IUserInterface и реализует его события и свойства. В обработчике
    // события формы countWordsButton_Click() генерируется событие TextRequested, затем используются методы
    // экземпляра класса TextEditor для работы с полученным текстом. Результаты работы выводятся на форму:
    // все тексты, а также "рейтинг употребимости" каждого слова.
    public partial class Form1 : Form, IUserInterface
    {
        public event EventHandler TextRequested;
        public string Login { get; set; }
        public string Password { get; set; }
        public string SongsText { get; set; }
        public int SongsCount { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void countWordsButton_Click(object sender, EventArgs e)
        {
            Login = loginBox.Text;
            Password = passwordBox.Text;
            if (TextRequested != null)
            {
                TextRequested(sender, e);
                TextEditor text = new TextEditor(SongsText);
                Dictionary<string, int> allWords = text.GetSort(text.CutWords());
                audioText.Text = SongsText.Replace("\n", "\r\n"); ;
                // Выводится сто слов из рейтинга наиболее употребимых слов, начиная с позиции 100 (в начале рейтинга - союзы и предлоги).
                int firstWord = 100, lastWord = firstWord + 100;
                wordsCounterBox.Text += $"Загружено текстов: {SongsCount} \r\n";
                wordsCounterBox.Text += $"Всего слов: {allWords.Count} \r\n";
                for (int i = firstWord; i < lastWord; i++)
                {
                    var elem = allWords.ElementAt(i);
                    wordsCounterBox.Text += $"# {i}: {elem.Key}: {elem.Value} - " +
                        $"{(float)elem.Value / allWords.Count * 100} %\r\n";
                }
            }
        }
    }
}
