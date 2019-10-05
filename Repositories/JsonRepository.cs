using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace MVVM.Repositories
{
    class JsonRepository<T>
    {
        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                if (File.Exists(path) && path.Contains(".txt"))
                {
                    path = value;
                }
            }
        }
        public JsonRepository(string path = null)
        {
            if(File.Exists(path) && path.Contains(".txt"))
            {
                Path = path;
            }else if(path == null)
            {
                path = "json.txt";
                if(!File.Exists(path))
                {
                    File.Create(path);
                }
            }
        }
        public void SaveAll(IEnumerable<T> collection)
        {
            T[] arr = collection.ToArray<T>();
            string json = JsonConvert.SerializeObject(arr);
            File.WriteAllText(Path, json);
        }
        public IEnumerable<T> ReadAll()
        {
            string json = File.ReadAllText(Path);
            var students = JsonConvert.DeserializeObject(json);
            return (IEnumerable<T>)students;
        }
    }
}
