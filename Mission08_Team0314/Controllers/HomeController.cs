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
