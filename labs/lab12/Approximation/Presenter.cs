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
        FileSystem _FS;
        MainForm _UI;
        public Presenter(FileSystem FS, MainForm UI)
        {
            _FS = FS;
            _UI = UI;
        }



    }
}
