using BD_E2_MVC.Models;
using Microsoft.AspNetCore.Mvc;
namespace BD_E2_MVC.Controllers
{
    public class FolderController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string path)
        {
            if ((string.IsNullOrEmpty(name)) || (string.IsNullOrEmpty(path)))
            {
                ModelState.AddModelError("", "Folder name or path can't be empty.");
                return View();
            }
            FolderModel folder = new FolderModel(name, path);
            return View(folder);
        }
        //public IActionResult Create(string name = "AgentFolder", string path = "C:\\Users\\Public")
        //{
        //    FolderModel folder = new FolderModel(name, path);
        //    return View(folder);
        //}
    }
}
