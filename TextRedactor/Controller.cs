using System;
using FileSystemLibrary;

namespace Labs.TextRedactor
{
    class Controller
    {
        private IUIterface _formUI;
        private IFileSystem _FS;

        public Controller(IUIterface formUI, IFileSystem FS)
        {
            _formUI = formUI;
            _FS = FS;

            formUI.OpenFile += openFileHandler;
            formUI.SaveFile += saveFileHandler;            
        }
        private void openFileHandler(object sender, EventArgs e)
        {
            if (!_FS.ReadFile(_formUI.FilePath))
            {
                throw new Exception("Файл не прочтен");
            }
            _formUI.TextContent = _FS.Content;
        }
        private void saveFileHandler(object sender, EventArgs e)
        {
            try
            {
                _FS.Content = _formUI.TextContent;
                if (!_FS.WriteFile(_formUI.FilePath))
                {
                    throw new Exception("Файл не записан");
                }
            }
            catch(Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }
    }
}
