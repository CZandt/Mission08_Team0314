using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission08_Team0314.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team0314.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext _SQLiteContext { get; set; }

        //Constructor
        public HomeController(TaskContext x)
        {
            _SQLiteContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quadrant()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEditTask()
        {
            ViewBag.categories = _SQLiteContext.categories.ToList();
            return View();
        }
        // controlers to edit task and update quadrant view
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = blahContext.Categories.ToList();

            // grabbing a specific movie in this case, by movieid
            var task = blahContext.Responses.Single(x => x.TaskID == taskid);

            return View("AddTask", task);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar1)
        {

            blahContext.Update(ar1);
            blahContext.SaveChanges();

            return RedirectToAction("Quadrant");
        }
        //controlers to delete a task from the quadrant view
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var movie = blahContext.Responses.Single(x => x.TaskID == taskid);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {

            blahContext.Responses.Remove(ar);
            blahContext.SaveChanges();
            return RedirectToAction("Quadrant");
        }

        [HttpPost]
        public IActionResult AddEditTask(Models.Task task)
        {
            _SQLiteContext.Add(task);
            _SQLiteContext.SaveChanges();
            return View("Confirmation", task);
        }

        [HttpGet]
        public IActionResult ShowTasks()
        {
            var tasks = _SQLiteContext.tasks.ToList();

            return View(tasks);
        }
    }
}
