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
    class StudentSort 
    {
        public bool Decrease { get; set; }
        public bool Byname { get; set; }
        public bool Bysurname { get; set; }
        public bool Bydate { get; set; }
        public bool Bygroup { get; set; }
        public StudentSort()
        {
        }

        
        public void Sort(ObservableCollection<Student> students)
        {
            List<Student> studentlist = students.ToList<Student>();
            List<Student> sortedlist = new List<Student>();
            if(!Decrease)
            {
                if(Byname)
                {
                    studentlist = studentlist.OrderBy(o => o.Name).ToList<Student>();
                }
                if(Bysurname)
                {
                    studentlist = studentlist.OrderBy(o => o.Surname).ToList<Student>();
                }
                if(Bygroup)
                {
                    studentlist = studentlist.OrderBy(o => o.Group).ToList<Student>();
                }
                if(Bydate)
                {
                    studentlist = studentlist.OrderBy(o => o.BirthDate).ToList<Student>();
                }
            }
            else
            {
                if (Byname)
                {
                    studentlist = studentlist.OrderByDescending(o => o.Name).ToList<Student>();
                }
                if (Bysurname)
                {
                    studentlist = studentlist.OrderByDescending(o => o.Surname).ToList<Student>();
                }
                if (Bygroup)
                {
                    studentlist = studentlist.OrderByDescending(o => o.Group).ToList<Student>();
                }
                if (Bydate)
                {
                    studentlist = studentlist.OrderByDescending(o => o.BirthDate).ToList<Student>();
                }
            }
            students.Clear();
            for (int i = 0; i < studentlist.Count; i++)
            {
                students.Add(studentlist[i]);
            }
        }
    }
}
