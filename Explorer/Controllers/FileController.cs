using Microsoft.AspNetCore.Mvc;
using BD_E2_MVC.Models;

namespace BD_E2_MVC.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult Create() { return View(); }

        [HttpGet]
        public async Task<IActionResult> Index(string name, string path)
        {
            ObjectReviewModel model = new ObjectReviewModel(name, path, "file");
            if (System.IO.File.Exists(path))
            {
                await Task.Run(() => model.Content = System.IO.File.ReadAllText(path)); 
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(string name, string path)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(path))
            {
                ModelState.AddModelError("", "File name or path cannot be empty.");
                return View();
            }
            try
            {
                FileModel file = new FileModel(name, path);
                return View(file);
            }
            catch (UnauthorizedAccessException ex)
            {
                ModelState.AddModelError("", "You have no rights for creating.");
                return View();
            }
        }
    

    }
}