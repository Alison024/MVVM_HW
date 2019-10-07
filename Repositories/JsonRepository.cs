﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using MVVM.Infrastructure;
using MVVM.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM.Repositories
{
    class JsonRepository:IRepository<Student>
    {
        public JsonRepository(){ }

        public void SaveAll(ObservableCollection<Student> collection,string path)
        {
            Student[] arr = collection.ToArray<Student>();
            string json = JsonConvert.SerializeObject(arr);
            File.WriteAllText(path, json);
        }

        public ObservableCollection<Student> ReadAll(string path)
        {
            string json = File.ReadAllText(path);
            var students = JsonConvert.DeserializeObject(json);
            ObservableCollection<Student> jsonstudents = new ObservableCollection<Student>((List<Student>)students);//ошибка с конвертацией из Json в List<T>
            //Не удалось привести тип объекта Newtonsoft.Json.Linq.JArray к типу System.Collections.Generic.List1[MVVM.Model.Student]
            return jsonstudents;
        }


    }
}
