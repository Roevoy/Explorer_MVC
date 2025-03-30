namespace BD_E2_MVC.Models
{
    public class SearchModel
    {
        public List<string> FoundFiles { get; set; }
        public List<string> FoundFolders { get; set; }
        public SearchModel(List<string> FoundFiles, List<string> FoundFolders) 
        {
            this.FoundFiles = FoundFiles;
            this.FoundFolders = FoundFolders;
        }
    }
}
