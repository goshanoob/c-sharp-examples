using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Blood_Pressure_and_Weather
{
    internal class FileReader
    {
        public string ReadFile(string fileName)
        {
            string textContent = "";
            if (File.Exists(fileName))
            {
                StreamReader stream = new StreamReader(fileName);
                textContent = stream.ReadToEnd();
                stream.Close();
            }
            return textContent;
        }
    }
}
