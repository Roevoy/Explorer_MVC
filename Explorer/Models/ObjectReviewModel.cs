using Microsoft.VisualBasic;

namespace BD_E2_MVC.Models
{
    public class ObjectReviewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string Description { get; set; } = "No description.";
        public string Content { get; set; } = string.Empty;
        public List<string> files { get; set; } = new List<string>();
        public List<string> folders { get; set; } = new List<string>();
        public ObjectReviewModel() { }
        public ObjectReviewModel(string name, string path, string type)
        { 
            this.Type = type;
            this.Name = name;
            this.Path = path;
            if (type == "file") Content = File.ReadAllText(path);
            else if (type == "folder")
            {
                folders.AddRange(Directory.GetDirectories(path));
                files.AddRange(Directory.GetFiles(path));
            }
        }
    }
}

