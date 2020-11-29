using System;
using System.Collections.Generic;
using System.Linq;

namespace goshanoob.MatchesCounter
{
    internal class TextEditor
    {
        private string text;

        public TextEditor(string text)
        {
            this.text = text;
        }
        public string[] cutWords()
        {
            // Символы, по которым определяем границы слов (сами смволы не нужны, поэтому без ругелярок)
            char[] sep = new char[] { ',', ' ', '\"', '.', '»', '«', ':', '-' };
            //string[] words = text.Split(sep);
            text = text.Replace("\r\n", " ").ToLower();
            return text.Split(sep, StringSplitOptions.RemoveEmptyEntries); //вернули массив слов без пустых элементов
        }

        /* Метод подсчёта числа повторений слов в тексте и сортировки*/
        public Dictionary<string, int> getSort(string[] words)
        {
            // Словарь из пар "слово - количество вхождений".
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string word2 in words)
            {
                if (dic.ContainsKey(word2))
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
}
