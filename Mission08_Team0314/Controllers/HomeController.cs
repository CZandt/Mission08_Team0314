using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var tasks = _SQLiteContext.tasks
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
        }
        //add new task
        [HttpGet]
        public IActionResult AddEditTask()
        {
            ViewBag.categories = _SQLiteContext.categories.ToList();

            return View(new Models.Task());
        }
        [HttpPost]
        public IActionResult AddEditTask(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _SQLiteContext.Add(task);
                _SQLiteContext.SaveChanges();
                return View("Confirmation", task);
            }
            else
            {
                ViewBag.categories = _SQLiteContext.categories.ToList();
                return View(task);
            }
        }
        // controlers to edit task and update quadrant view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _SQLiteContext.categories.ToList();

            // grabbing a specific task in this case, by taskid
            var task = _SQLiteContext.tasks.Single(x => x.TaskID == id);

            return View("AddEditTask", task);
        }
        [HttpPost]
        public IActionResult Edit(Models.Task T1)
        {

            _SQLiteContext.Update(T1);
            _SQLiteContext.SaveChanges();

            return RedirectToAction("Quadrant");
        }
        //controlers to delete a task from the quadrant view
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _SQLiteContext.tasks.Single(x => x.TaskID == id);

            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(Models.Task T1)
        {

            _SQLiteContext.tasks.Remove(T1);
            _SQLiteContext.SaveChanges();
            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult ShowTasks()
        {
            var tasks = _SQLiteContext.tasks.ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Test(int id)
        {
            var task = _SQLiteContext.tasks.Single(x => x.TaskID == id);

            // task.Completed = true;
            task.Completed = true;

            _SQLiteContext.Update(task);
            _SQLiteContext.SaveChanges();

            return RedirectToAction("Quadrant");
        }
    }
}
