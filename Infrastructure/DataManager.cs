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
                List<Student> studentlist= repository.ReadAll(openFileDialog.FileName);
                for(int i = 0;i<studentlist.Count;i++)
                {
                    students.Add(studentlist[i]);
                }
                
            }
        }

        public void SaveFile(ObservableCollection<Student> students)
        {
            if(path==null)
            {
                path = "json.txt";
                if(!File.Exists(path))
                {
                    File.Create(path);
                    //Процесс не может получить доступ к файлу "D:\Projects\Visual Studio\Shag\С#\DZ_WPF5_MVVM\MVVM\MVVM\bin\Release\json.txt",
                    //так как этот файл используется другим процессом.'
                }
            }
            repository.SaveAll(students, path);
        }
    }
}
