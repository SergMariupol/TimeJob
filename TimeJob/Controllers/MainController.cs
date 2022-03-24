using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeJob.Data.Interfaces;
using TimeJob.Data.Models;
using TimeJob.ViewModels;

namespace TimeJob.Controllers
{
    public class MainController : Controller
    {
        private readonly IAllTaskJob _allTask;
        public MainController(IAllTaskJob IAllTask)
        {
            _allTask = IAllTask;
        }

        public IActionResult Index()
        {
            MainViewModel Main = new MainViewModel();
            Main.AllTask = _allTask.Task;
            Main.AllProject = _allTask.Project;
            Main.AllTaskComment = _allTask.TaskComments;
            
            return View(Main);
        }

        [HttpPost]
        public IActionResult Index(MainViewModel info)
        {
            IEnumerable<TaskJob> AllTask = _allTask.Task.Where(x => x.StartDate >= info.Start && x.CancelDate <= info.Start.AddDays(1) && x.ProjectId == info.ProjectFact);
            MainViewModel Main = new MainViewModel();
            Main.AllTask = AllTask;
            Main.AllProject = _allTask.Project;
            return View(Main);
        }

        public IActionResult CreateTask()
        {
            MainViewModel Main = new MainViewModel();
            return View(Main);
        }

        [HttpPost]
        public IActionResult CreateTask(MainViewModel Main)
        {
            Main.TaskComment = new TaskComments();
            if (ModelState.IsValid)
            {                
                if (Main.CommentFile != null)
                {                 
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(Main.CommentFile.OpenReadStream()))
                    { 
                        imageData = binaryReader.ReadBytes((int)Main.CommentFile.Length);
                    }
                    // установка массива байтов
                    Main.TaskComment.Content = imageData;
                }
                else
                {
                    Main.TaskComment.Content = Encoding.Default.GetBytes(Main.CommentText);
                }

                _allTask.CreateTask(Main);             
                return RedirectToAction("Index");
            }
            return View(Main);
        }
      
        public IActionResult EditTask(MainViewModel IdTask)
        {
            MainViewModel Main = new MainViewModel();
            Main.AllTask = _allTask.Task.Where(x => x.id == IdTask.IdEditTask);
            return View(Main);
        }

        [HttpPost]
        public IActionResult EditTaskK(MainViewModel Edit)
        {


            _allTask.EditTask(Edit.Task);

            return RedirectToAction("Index");
        }
    }   
}
