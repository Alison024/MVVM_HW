using MVVM.Infrastructure;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM.ViewModel
{
     class MainViewModel
    {
        private DataManager _dm;
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        
        public MainViewModel()
        {
            DateTime bd = new DateTime(2000, 8, 24);
            _dm = new DataManager();
            Students = new ObservableCollection<Student>() { new Student("Andrey","Ublin",bd,"IN-101")};
            AddCommand = new RelayCommand(x =>
            {
                Students.Add(new Student("Null", "Null",new DateTime(1, 1, 1),"Null"));
            });
            RemoveCommand = new RelayCommand(x => Students.Remove(SelectedStudent), x => Students.Count > 0 && SelectedStudent != null);
            OpenCommand = new RelayCommand(x => _dm.OpenFile(Students));
            SaveCommand = new RelayCommand(x => _dm.SaveFile(Students));
        }
    }
}
