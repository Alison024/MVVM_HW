using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM.Infrastructure
{
    class StudentSort : INotifyPropertyChanged, IComparer<Student>
    {
        private bool decrease;
        private bool byname;
        private bool bysurname;
        private bool bydate;
        private bool bygroup;
        private ObservableCollection<Student> students;

        public StudentSort(ObservableCollection<Student> students)
        {
            this.students = students;
        }

        public bool Decrease
        {
            get
            {
                return decrease;
            }
            set
            {
                decrease = value;
                Sort();
                Notify();
            }
        }
        public bool ByName
        {
            get
            {
                return byname;
            }
            set
            {
                byname = value;
                Sort();
                Notify();
            }
        }
        public bool BySurname
        {
            get
            {
                return bysurname;
            }
            set
            {
                bysurname = value;
                Sort();
                Notify();
            }
        }
        public bool ByDate
        {
            get
            {
                return bydate;
            }
            set
            {
                bydate = value;
                Sort();
                Notify();
            }
        }
        public bool ByGroup
        {
            get
            {
                return bygroup ;
            }
            set
            {
                bygroup = value;
                Sort();
                Notify();
            }
        }


        protected void Notify([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public int Compare(Student x,Student y)
        {
            int tmp = 0;
            if (ByName == true)
            {
                if(String.Compare(x.Name,y.Name)>1 && String.Compare(x.Name, y.Name)!=0)
                {
                    tmp = 1;
                }
                else tmp = -1; 
            }
            else if(BySurname==true)
            {
                if (String.Compare(x.Surname, y.Surname) > 1 && String.Compare(x.Surname, y.Surname) != 0)
                {
                    tmp = 1;
                }
                else tmp = -1; 
            }
            else if (ByDate == true)
            {
                if (x.BirthDate > y.BirthDate && x.BirthDate != y.BirthDate)
                {
                    tmp = 1;
                }
                else tmp = -1;
            }
            else if (ByGroup == true)
            {
                if (String.Compare(x.Group, y.Group) > 1 && String.Compare(x.Group, y.Group) != 0)
                {
                    tmp = 1;
                }
                else tmp = -1;
            }

            if (Decrease == false)
            {
                return tmp;
            }
            else return -tmp;
        }
        public void Sort()
        {
            List<Student> studentlist = students.ToList<Student>();
            studentlist.Sort(Compare);
            students.Clear();
            for(int i =0;i<studentlist.Count;i++)
            {
                students.Add(studentlist[i]);
            }
        }
    }
}
