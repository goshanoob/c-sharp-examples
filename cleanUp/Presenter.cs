using System;
using System.Collections.Generic;

namespace goshanoob.CleanUpApp
{
    // Назначение Презентера в шаблоне проектирования MVP - по запросу Отображения обновлять Модель и
    // изменять Отображение в соответстивии с Моделью. Взаимодействие с Отображением осуществляется
    // через экземпляр интерфейса, который Отображение реализует. В данном приложении Отображение - это 
    // форма WindowsForms, имеющая два события изменения рабочего каталога и запрос на сортировку. Отображение
    // предоставляет доступ к свойствам CataloguePath (рабочий каталог), FilesList (список файлов каталога),
    // FilesInOrder (отсортированный список файлов по категориям).
    // Моделью приложения является каталог файловой системы. У соответствующего экземпляра класса доступны 
    // методы получения списка файлов в каталоге, создания подкаталога и переноса файлов в подкаталог.
    // Методы-обработчики событий Презентера позволяют изменить рабочий каталог, а также отсортировать
    // файлы в рабочем каталоге в подкаталоги.
    internal class Presenter
    {
        private IUserInterface _UI;
        private FileSystemDirectory _FSDirectory;
        public Presenter(IUserInterface UI, FileSystemDirectory FSDirectory)
        {
            _UI = UI;
            _FSDirectory = FSDirectory;
            _UI.CatalogueChanged += CatalogueChangedHandler;
            _UI.SortRequested += SortRequestedHandler;
        }

        public void CatalogueChangedHandler(object sender, EventArgs e)
        {
            try
            {
                _UI.FilesList = _FSDirectory.GetFilesList(_UI.CataloguePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SortRequestedHandler(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, List<string>>.KeyCollection catigories = _UI.FilesInOrder.Keys;
                foreach (string catigory in catigories)
                {
                    if (_UI.FilesInOrder[catigory].Count == 0)
                        continue;
                    _FSDirectory.CreateDirectory(_UI.CataloguePath, catigory);
                    foreach (string file in _UI.FilesInOrder[catigory])
                    {
                        _FSDirectory.MoveFile(file, _UI.CataloguePath + "\\" + catigory);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
