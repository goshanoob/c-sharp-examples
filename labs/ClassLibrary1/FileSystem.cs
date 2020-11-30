using System;
using System.IO;
using System.Text;

namespace FileSystemLibrary
{
    public interface IFileSystem
    {
        string Content { get; set; }
        bool ReadFile(string filePath);
        bool ReadFile(string filePath, Encoding encoding);
        bool WriteFile(string filePath);
        bool WriteFile(string filePath, Encoding encoding);
    }

    // Класс для работы с файловой системой. Класс реализует интерфейс IFileSystem.
    public class FileSystem : IFileSystem
    {
        // Кодировка файла по умолчанию.
        private Encoding defaultEnconding = Encoding.UTF8;
        // Содержимое файла.
        public string Content { get; set; } 
        public bool ReadFile(string filePath)
        {
            if (ReadFile(filePath, defaultEnconding)) return true;
            return false;
        }
        public bool ReadFile(string filePath, Encoding encoding)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    StreamReader reader = new StreamReader(filePath, encoding);
                    Content = reader.ReadToEnd();
                    reader.Close();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw new Exception("Ошибка при чтении файла");
            }
        }

        public bool WriteFile(string filePath)
        {
            if (WriteFile(filePath, defaultEnconding)) return true;
            return false;
        }
        public bool WriteFile(string filePath, Encoding encoding)
        {
            try
            {
                StreamWriter writer = new StreamWriter(
                    new FileStream(filePath, FileMode.Create),
                    encoding);
                writer.Write(Content);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при записи файла");
            }
        }
    }
}
