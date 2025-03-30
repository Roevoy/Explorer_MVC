using System.Drawing;
using System.Xml.Linq;

namespace BD_E2_MVC.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public string Path { get; set; } 
        public FileModel(string name, string path) 
        {
            this.Name = name;
            this.Path = path;
            File.Create(path + "/" + name);
        }
    }
}
