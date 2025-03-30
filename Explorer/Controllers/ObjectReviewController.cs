using Microsoft.AspNetCore.Mvc;
using BD_E2_MVC.Models;
using System.Threading.Tasks.Dataflow;

namespace BD_E2_MVC.Controllers
{
    public class ObjectReview : Controller
    {
        [HttpGet]
        public IActionResult Index(string name, string path, string type)
        {
            ObjectReviewModel model = new ObjectReviewModel(name, path, type);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveChanges(ObjectReviewModel model)
        {
            if ((!string.IsNullOrEmpty(model.Path)) && (model.Type == "file"))
            {
                string[] dirrectory = model.Path.Split("\\");
                dirrectory[^1] = model.Name;
                await Task.Run(() => System.IO.File.Delete(model.Path));
                await Task.Run(() => model.Path = String.Join("\\", dirrectory));
                await Task.Run(() => System.IO.File.WriteAllText(model.Path, model.Content));
            }
            else if (model.Type == "folder")
            {
                string oldPath = model.Path;
                string[] dirrectory = model.Path.Split("\\");
                dirrectory[^1] = model.Name;
                await Task.Run(() => model.Path = String.Join("\\", dirrectory));
                await Task.Run(() => Directory.Move(oldPath, model.Path));
            }
            return RedirectToAction("Index", model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string path, string type)
        {
            if (string.IsNullOrEmpty(path))
            {
                return NotFound("Path is required.");
            }
            try
            {
                if (type == "file" && System.IO.File.Exists(path))
                {
                    await Task.Run(() => System.IO.File.Delete(path));
                }
                
                else if (type == "folder"  && Directory.Exists(path))
                {
                    await Task.Run(() => Directory.Delete(path, true));  
                }
                else
                {
                    return NotFound("File or folder not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return RedirectToAction("Index", "Search");
        }
    }
}
