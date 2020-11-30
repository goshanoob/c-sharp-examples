using FileSystemLibrary;
using System;


namespace Approximation
{
    // Презентер.
    class Presenter
    {
        IFileSystem _FS;
        IUserInterface _UI;
        public Presenter(IFileSystem FS, IUserInterface UI)
        {
            _FS = FS;
            _UI = UI;
            _UI.OpenFile += OpenFileHandler;
        }

        public void OpenFileHandler(object sender, EventArgs e)
        {
            if (_FS.ReadFile(_UI.FilePath))
            {
                _UI.TextContent = _FS.Content;
            }
        }
    }
}
