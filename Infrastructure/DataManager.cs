using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVM.Model;
using MVVM.Repositories;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace MVVM.Infrastructure
{
    class DataManager
    {
        private string path;
        private JsonRepository repository;
        public DataManager()
        {
            repository = new JsonRepository();
        }

        public void OpenFile(ObservableCollection<Student> students)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog()==true)
            {
                path = openFileDialog.FileName;
                students.Clear();
                students = repository.ReadAll(path);
            }
        }

        public void SaveFile(ObservableCollection<Student> students)
        {
            if(path==null)
            {
                path = "json.txt";
                File.Create(path);
            }
            repository.SaveAll(students, path);
        }
    }
}
