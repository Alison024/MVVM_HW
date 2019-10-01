using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace MVVM.Model
{
    class Student:INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private DateTime birthdate;
        private string group;
        
        public Student() { }
        public Student(string name, string surname,DateTime dt,string group)
        {
            this.name = name;
            this.surname = surname;
            birthdate = dt;
            this.group = group;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                Notify();
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                Notify();
            }
        }

        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
                Notify();
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
                Notify();
            }
        }

        protected void Notify([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
