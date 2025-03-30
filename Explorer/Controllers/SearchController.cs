using Microsoft.AspNetCore.Mvc;
using BD_E2_MVC.Models;
using System.IO;

namespace BD_E2_MVC.Controllers
{

    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Find() { return View(); }

        [HttpPost]
        public IActionResult Find(string name, string path)
        {
            try
            {
                string[] subdirrectoriesArray = Directory.GetDirectories(path, "", SearchOption.AllDirectories);
                List<string> subdirrectories = subdirrectoriesArray.ToList();
                subdirrectories.Add(path);
                List<string> probableFiles = new List<string>();
                List<string> probableFolders = new List<string>();

                if (subdirrectories.Count > 0)
                {
                    foreach (string directory in subdirrectories)
                    {
                        if (directory.Split("\\")[^1].Contains(name)) probableFolders.Add(directory); 
                        List<string> filesInTheDirrectory = new List<string>();
                        string[] filesInTheDirrectoryArray = Directory.GetFiles(directory);
                        if (filesInTheDirrectoryArray.Length > 0)
                        {
                            filesInTheDirrectory.AddRange(filesInTheDirrectoryArray);
                            foreach (string filePath in filesInTheDirrectory)
                            {
                                if (filePath.Split("\\")[^1].Contains(name))probableFiles.Add(filePath);
                            }
                        }
                    }
                    return View(new SearchModel(probableFiles, probableFolders));
                }
                return View();
                    
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult FindByContent() { return View(); }

        [HttpPost]
        public IActionResult FindByContent(string name, string path)
        {
            string[] subdirrectoriesArray = Directory.GetDirectories(path, "", SearchOption.AllDirectories);
            List<string> subdirrectories = subdirrectoriesArray.ToList();
            subdirrectories.Add(path);
            List<string> probableFiles = new List<string>();
            if (subdirrectories.Count > 0)
            {
                foreach (string directory in subdirrectories)
                {
                    List<string> filesInTheDirrectory = new List<string>();
                    string[] filesInTheDirrectoryArray = Directory.GetFiles(directory);
                    if (filesInTheDirrectoryArray.Length > 0)
                    {
                        filesInTheDirrectory.AddRange(filesInTheDirrectoryArray);
                        foreach (string filePath in filesInTheDirrectory)
                        {
                            string fileContent = System.IO.File.ReadAllText(filePath);
                            if (fileContent.Contains(name)) probableFiles.Add(filePath);
                        }
                    }
                }
                SearchModel model = new SearchModel(probableFiles, null);
                return View(model);
            }
            return View();
        }
    }
}

