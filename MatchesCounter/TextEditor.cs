using System;
using System.Collections.Generic;
using System.Linq;

namespace goshanoob.MatchesCounter
{
    // Класс TextEditor нужен для работы с текстом. Класс содержит закрытое поле для хранения текста.
    // Конструктор класса позволяет создать объект, инициализировав закрытое поле. Доступный метод CutWords()
    // разбивиет текст по словам и возвращает строковый массив без пустых элементов. Метод GetSort() принимает
    // в качестве аргумента массив слов, преобразует его в словарь Dictionary<>, который содержит в качестве
    // ключей сами слова, а в качестве значений - количество повторений слов в массиве. Метод возвращает
    // коллекцию Dictionary.
    internal class TextEditor
    {
        private string _text;

        public TextEditor(string text)
        {
            _text = text;
        }
        public string[] CutWords()
        {
            char[] separators = new char[] { ',', ' ', '\"', '.', '»', '«', ':', '-' };
            _text = _text.Replace("\r\n", " ").ToLower();
            return _text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        public Dictionary<string, int> GetSort(string[] words)
        {
            // Словарь из пар "слово - количество вхождений".
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }
            // Сортировка по числу посторений слова и возвращение в исходный тип.
            dictionary = dictionary.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return dictionary;
        }
    }
}
