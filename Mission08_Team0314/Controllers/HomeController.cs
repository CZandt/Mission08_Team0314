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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Quadrant()
        {
            return View();
        }

        public IActionResult AddTask()
        {
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
