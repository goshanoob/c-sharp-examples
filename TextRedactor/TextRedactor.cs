using System;
using FileSystemLibrary;

namespace Labs.TextRedactor
{
    public interface IRedactor
    {
        long SymbolCount { get; set; }
        string GetText(string file);
        void SaveText();
        long GetSymbolCount();
    }

    public class TextRedactor : IRedactor
    {
        private string _fileName;
        public string Text { get; set; } = "";
        public long SymbolCount { get; set; } = 0;
        public TextRedactor()
        {

        }
        public TextRedactor(string fileName): this (fileName, "")
        {
            _fileName = fileName;
        }
        public TextRedactor(string fileName, string text)
        {
            _fileName = fileName;
            Text = text;
        }
        public string GetText(string fileName)
        {
            FileSystem fs = new FileSystem(fileName);
            if (!fs.ReadFile())
            {
                throw new Exception("Файл не прочтен");
            }
            Text = fs.Content;
            GetSymbolCount();
            return fs.Content;
        }

        public void SaveText()
        {
            FileSystem fs = new FileSystem(_fileName);
            fs.Content = Text;
            if (!fs.WriteFile())
            {
                throw new Exception("Файл не записан");
            }
        }

        public long GetSymbolCount()
        {
            SymbolCount = Text.Length;
            return SymbolCount;
        }

    }
}
