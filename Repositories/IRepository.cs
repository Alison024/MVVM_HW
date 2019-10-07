using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Repositories
{
    interface IRepository<T>
    {
         void SaveAll(ObservableCollection<T> obj,string path);
         ObservableCollection<T> ReadAll(string path);
    }
}
