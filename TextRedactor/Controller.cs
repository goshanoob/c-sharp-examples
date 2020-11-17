using System;
using System.Text;

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
            formUI.ContentChanged += changedContentHandler;
            
        }
        private void openFileHandler(object sender, EventArgs e)
        {
            _FS fileSystem = new _FS(_formUI.FilePath);
            if (!_FS.ReadFile())
            {
                throw new Exception("Файл не прочтен");
            }
            _formUI.TextContent = _FS.Content;
        }
        private void saveFileHandler(object sender, EventArgs e)
        {
            _FS.Content = _formUI.TextContent;
            if (!_FS.WriteFile())
            {
                throw new Exception("Файл не записан");
            }
        }
        private void changedContentHandler(object sender, EventArgs e)
        {

        }
    }
}
