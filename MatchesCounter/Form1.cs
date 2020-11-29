using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace goshanoob.MatchesCounter
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void countWordsButton_Click(object sender, EventArgs e)
        {
            Vkontate vk = new Vkontate();
            int contex = vk.getTok(this);
            TextEditor text = new TextEditor(audioText.Text);
            Dictionary<string, int> allWords = text.getSort(text.cutWords());
            // Выводится сто слов из рейтинга наиболее употребимых слов, начиная с позиции 100 (в начале рейтинга - союзы и предлоги).
            int firstWord = 100, lastWord = firstWord + 100;
            wordsCounterBox.Text += $"Загружено текстов: {contex} \r\n";
            wordsCounterBox.Text += $"Всего слов: {contex} \r\n";
            for (int i = firstWord; i < lastWord; i++)
            {
                var elem = allWords.ElementAt(i);
                wordsCounterBox.Text += $"# {i}: {elem.Key}: {elem.Value} - " +
                    $"{(float)elem.Value / allWords.Count * 100} %\r\n";
            }
        }
    }
}
