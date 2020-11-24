using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemLibrary;
/* Презентер */

namespace Approximation
{
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
