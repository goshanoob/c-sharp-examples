using System;
using System.Collections.Generic;
using System.Text;

namespace Blood_Pressure_and_Weather
{
    internal class Presenter
    {
        FileReader _fileReader; 
        MainWindow _mainWindow; 
        public Presenter(FileReader fileReader, MainWindow mainWindow)
        {
            _fileReader = fileReader;
            _mainWindow = mainWindow;

        }
    }
}
