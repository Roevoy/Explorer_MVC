namespace BD_E2_MVC.Models
{
    public class FolderModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public FolderModel(string name, string path)
        {
            this.Name = name;
            this.Path = path;
            Directory.CreateDirectory(path + "/" + name);
        }
    }
}
