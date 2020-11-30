using System.Collections.Generic;
using System.IO;

namespace goshanoob.CleanUpApp
{
    // Класс реализующий сортировку файлов. В классе определены два свойства, конструктор и метод PutInOrder().
    // Метод возвращает коллекцию Dictionary, в которой ключом является категория файлов, а значеним - список соответствующих категории файлов.
   
    internal class FileSorter
    {
        // Каталог сортировки файлов.
        public string RootPath { get; set; }
        // Массив имен файлов.
        public string[] FilesList { get; set; }

        public FileSorter(string rootPath, string[] files)
        {
            RootPath = rootPath;
            FilesList = files;
        }

        public Dictionary<string, List<string>> PutInOrder()
        {
            // Метод сортировки файлов по категориям.
            Dictionary<string, List<string>> sortedFiles = new Dictionary<string, List<string>>();
            // Добавление категорий.
            string[] categories = new string[] {
                "Текстовые документы",
                "Многостраничные документы",
                "Исполняемые и пакетные файлы",
                "Изображения",
                "Исходный код",
                "Музыка",
                "Видео",
                "Архивы",
                "Торренты",
                "Офисные документы",
                "Прочие"
            };
            foreach (string category in categories)
            {
                sortedFiles.Add(category, new List<string>());
            }

            // Распределение файлов по категориям.
            string extension;
            foreach (string file in FilesList)
            {
                extension = Path.GetExtension(file);
                switch (extension.ToLower())
                {
                    case ".rtf":
                    case ".doc":
                    case ".docx":
                    case ".docm":
                    case ".txt": sortedFiles["Текстовые документы"].Add(file); break;
                    case ".pdf":
                    case ".djvu": sortedFiles["Многостраничные документы"].Add(file); break;
                    case ".msi":
                    case ".bat":
                    case ".exe": sortedFiles["Исполняемые и пакетные файлы"].Add(file); break;
                    case ".jpg":
                    case ".jpeg":
                    case ".gif":
                    case ".png": sortedFiles["Изображения"].Add(file); break;
                    case ".cs":
                    case ".cpp":
                    case ".html":
                    case ".php":
                    case ".py":
                    case ".svg":
                    case ".x3d":
                    case ".wrl":
                    case ".css":
                    case ".xml":
                    case ".xslt":
                    case ".js": sortedFiles["Исходный код"].Add(file); break;
                    case ".mp3":
                    case ".ogg":
                    case ".flac":
                    case ".wav": sortedFiles["Музыка"].Add(file); break;
                    case ".mp4":
                    case ".avi":
                    case ".mkv":
                    case ".sfx":
                    case ".flv": sortedFiles["Видео"].Add(file); break;
                    case ".tar":
                    case ".gz":
                    case ".zip":
                    case ".rar": sortedFiles["Архивы"].Add(file); break;
                    case ".torrent": sortedFiles["Торренты"].Add(file); break;
                    case ".ppt":
                    case ".pptx":
                    case ".xls":
                    case ".xlsx": sortedFiles["Офисные документы"].Add(file); break;
                    default: sortedFiles["Прочие"].Add(file); break;
                }
            }
            return sortedFiles;
        }
    }
}