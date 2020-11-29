using System.IO;

namespace goshanoob.CleanUpApp
{
    // Класс FileSystemDirectory служит для работы с каталогом файловой системы. В нем определены три доступных отовсюду метода.
    // Метод GetFilesList() возвращает массив файлов в рабочем каталоге.
    // Метод CreateDirectories() для создания каталога принимает два парамета: абсолютный путь к каталогу, в котором
    // следует создать подкаталог, и название подкаталога.
    // Метод MoveFiles() перемещает файл, переданный первым параметром, в директорию, переданную вторым.
    internal class FileSystemDirectory
    {
        public string[] GetFilesList(string root)
        {
            return Directory.GetFiles(root);
        }
        public void CreateDirectory(string root, string directory)
        {
            string path = root + "\\" + directory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public void MoveFile(string filePath, string destinationFolder)
        {
            if (File.Exists(filePath) && Directory.Exists(destinationFolder) &&
                !File.Exists(destinationFolder + "\\" + Path.GetFileName(filePath)))
            {
                File.Move(filePath, destinationFolder + "\\" + Path.GetFileName(filePath));
            }
        }
    }
}