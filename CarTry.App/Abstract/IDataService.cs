using CarTry.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTry.App.Abstract
{
    interface IDataService<T>
    {
        List<T> LoadXMLData(string path);
        void SaveXMLData(string path, List<T> list);
        List<string> LoadJsonData(string fileName);
        void SaveJsonData(string path, List<T> list);

    }
}
